namespace XArch.CIL
{
    public class Instruction
    {
        public Instruction(IlOpcode opcode, IlOperand operand)
        {
            Opcode = opcode;
            Operand = operand;
        }

        public IlOpcode Opcode { get; }
        public IlOperand Operand { get; }
    }
}