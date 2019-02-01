using System;
using System.Collections.Generic;
using System.IO;

namespace XArch.CIL
{
    public class InstructionReader
    {
        const int MultiByteOpcodePrefix = 0xfe;
        const int MaxPossibleOperandNumber = 32768;
        
        readonly Stream stream;
        int instructionOffset;
        
        // Important, this is not thread safe! This is mainly for reducing memory allocation.
        readonly byte[] readBuffer = new byte[MaxPossibleOperandNumber * sizeof(int)];

        public InstructionReader(Stream stream)
        {
            this.stream = stream;
        }

        CilOpcode ReadOpcode()
        {
            int firstByteRead = stream.ReadByte();
            if (firstByteRead == -1) { return null; }
            byte firstByte = (byte)firstByteRead;

            if (IsSingleByteOpcode(firstByte))
            {
                if (!CilOpcode.IsValidFirstByte(firstByte))
                {
                    throw new BadImageFormatException(
                        $"Invalid opcode first byte {firstByte:x2}. {PrintIlOffset()}");
                }

                return CilOpcode.GetOpcode(new CilOpcodeValue(firstByte));
            }
            else
            {
                int secondByteRead = stream.ReadByte();
                if (secondByteRead == -1)
                {
                    throw new BadImageFormatException(
                        $"The first byte of opcode is {firstByte:x2} without second byte. {PrintIlOffset()}");
                }

                byte secondByte = (byte) secondByteRead;

                if (!CilOpcode.IsValidSecondByte(secondByte))
                {
                    throw new BadImageFormatException(
                        $"Unknown opcode {firstByte:x2} {secondByte:x2}. {PrintIlOffset()}");
                }

                return CilOpcode.GetOpcode(new CilOpcodeValue(firstByte, secondByte));
            }
        }
        
        public ICilInstruction Read()
        {   
            CilOpcode opcode = ReadOpcode();
            if (opcode == null) { return null; }

            return IsDynamicInstruction(opcode)
                ? CreateInstructionForDynamicOperands(opcode)
                : CreateInstructionForFixedOperand(opcode);
        }

        static bool IsDynamicInstruction(CilOpcode opcode)
        {
            return opcode.OperandType == CilOperandType.DwordSwitch;
        }

        ICilInstruction CreateInstructionForDynamicOperands(CilOpcode opcode)
        {
            int operandNumber = ReadOperandNumber();
            int operandSize = operandNumber * sizeof(int);
            int bytesRead = stream.Read(readBuffer, 0, operandSize);
            if (bytesRead != operandSize)
            {
                throw new BadImageFormatException(
                    $"The switch opcode requires {operandNumber} operand(s). But stream has reach to the end. {PrintIlOffset()}");
            }

            var instruction = new CilInstruction(
                opcode,
                readBuffer,
                operandSize,
                instructionOffset);
            instructionOffset += opcode.Size + operandSize + sizeof(int);
            return instruction;
        }

        int ReadOperandNumber()
        {
            int sizeRead = stream.Read(readBuffer, 0, sizeof(uint));
            if (sizeRead != sizeof(uint))
            {
                throw new BadImageFormatException(
                    $"The first operand for switch opcode requires 4 bytes. But stream has reach to the end. {PrintIlOffset()}");
            }

            uint operandNumber = BitConverter.ToUInt32(readBuffer, 0);
            
            if (operandNumber > MaxPossibleOperandNumber)
            {
                throw new BadImageFormatException(
                    $"The operand number {operandNumber} appears to be quite large. We have abandoned the process to ensure security. {PrintIlOffset()}");
            }
            
            return (int)operandNumber;
        }

        ICilInstruction CreateInstructionForFixedOperand(CilOpcode opcode)
        {
            int operandSize = opcode.GetOperandSize();
            ICilInstruction result = operandSize == 0
                ? new CilInstruction(opcode, instructionOffset)
                : CreateInstructionWithOperand(opcode, operandSize);

            instructionOffset += opcode.Size + operandSize;
            return result;
        }

        CilInstruction CreateInstructionWithOperand(CilOpcode opcode, int operandSize)
        {
            int sizeRead = stream.Read(readBuffer, 0, operandSize);
            if (sizeRead != operandSize)
            {
                throw new BadImageFormatException(
                    $"The opcode \"{opcode.Name}\" requires {opcode.OperandType}. But the stream has reach to the end. {PrintIlOffset()}");
            }

            var instructionWithOperand = new CilInstruction(
                opcode,
                readBuffer,
                operandSize,
                instructionOffset);
            return instructionWithOperand;
        }

        public IEnumerable<ICilInstruction> ReadToEnd()
        {
            ICilInstruction instruction;
            while ((instruction = Read()) != null)
            {
                yield return instruction;
            }
        }

        string PrintIlOffset() { return $"IL_{instructionOffset:x4}"; }

        static bool IsSingleByteOpcode(byte firstByte) => firstByte != MultiByteOpcodePrefix;
    }
}