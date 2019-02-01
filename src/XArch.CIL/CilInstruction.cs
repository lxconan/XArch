using System;
using System.Linq;

namespace XArch.CIL
{
    class CilInstruction : ICilInstruction
    {
        internal CilInstruction(CilOpcode opcode, int offset)
            : this(opcode, null, 0, offset)
        {
        }
        
        internal CilInstruction(
            CilOpcode opcode,
            byte[] operandValue,
            int operandSize,
            int offset)
        {
            OpcodeValue = opcode.Raw;
            OpcodeName = opcode.Name;
            OpcodeDescription = opcode.Description;
            OperandType = opcode.OperandType;
            Offset = offset;

            if (operandSize > 0)
            {
                OperandValue = new byte[operandSize];
                Buffer.BlockCopy(operandValue, 0, OperandValue, 0, operandSize);
            }
            else
            {
                OperandValue = operandValue ?? Array.Empty<byte>();
            }

            Length = opcode.Size + operandSize;
        }

        public int Offset { get; }
        public CilOpcodeValue OpcodeValue { get; }
        public string OpcodeName { get; }
        public string OpcodeDescription { get; }
        public int Length { get; }
        public CilOperandType OperandType { get; }
        public byte[] OperandValue { get; }
    }
}