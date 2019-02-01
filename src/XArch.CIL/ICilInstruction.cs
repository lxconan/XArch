namespace XArch.CIL
{
    public interface ICilInstruction
    {
        int Offset { get; }
        CilOpcodeValue OpcodeValue { get; }
        string OpcodeName { get; }
        CilOperandType OperandType { get; }
        byte[] OperandValue { get; }
        string OpcodeDescription { get; }
        int Length { get; }
    }
}