using System;
using System.IO;

namespace XArch.CIL
{
    public class InstructionReader
    {
        readonly Stream stream;

        public InstructionReader(Stream stream)
        {
            this.stream = stream;
        }
        
        public Instruction Read()
        {
            int firstByteRead = stream.ReadByte();
            if (firstByteRead == -1) { return null; }

            byte firstByte = (byte)firstByteRead;

            IlOpcode opcode;
            if (firstByte != 0xfe)
            {
                if (!IlOpcode.IsValidFirstByte(firstByte))
                {
                    throw new BadImageFormatException(
                        $"Invalid opcode first byte {firstByte:x2}");
                }

                opcode = IlOpcode.GetOpcode(new OpcodeValue(firstByte));
            }
            else
            {
                int secondByteRead = stream.ReadByte();
                if (secondByteRead == -1)
                {
                    throw new BadImageFormatException(
                        $"The first byte of opcode is {firstByte:x2} without second byte.");
                }

                byte secondByte = (byte) secondByteRead;

                if (!IlOpcode.IsValidSecondByte(secondByte))
                {
                    throw new BadImageFormatException(
                        $"Unknown opcode {firstByte:x2} {secondByte:x2}.");
                }

                opcode = IlOpcode.GetOpcode(new OpcodeValue(firstByte, secondByte));
            }

            int size = opcode.GetOperandSize();
            if (size == 0)
            {
                return new Instruction(opcode, new IlOperand(Array.Empty<byte>(), opcode.OperandType));
            }
            
            byte[] buffer = new byte[8];
            int sizeRead = stream.Read(buffer, 0, size);
            if (sizeRead != size)
            {
                throw new BadImageFormatException(
                    $"The opcode \"{opcode.Name}\" requires {opcode.OperandType}. But the stream has reach to the end.");
            }
            
            return new Instruction(opcode, new IlOperand(buffer, opcode.OperandType));
        }
    }
}