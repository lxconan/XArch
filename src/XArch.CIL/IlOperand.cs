namespace XArch.CIL
{
    public class IlOperand
    {
        public IlOperand(byte[] value, IlOperandType type)
        {
            Value = value;
            Type = type;
        }

        public byte[] Value { get; }
        public IlOperandType Type { get; }
    }
}