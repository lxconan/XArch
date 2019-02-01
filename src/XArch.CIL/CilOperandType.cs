namespace XArch.CIL
{
    public enum CilOperandType
    {
        [CilOperandTypeSize(4)]
        DwordBrTarget = 0,
        [CilOperandTypeSize(4)]
        DwordField = 1,
        [CilOperandTypeSize(4)]
        DwordInteger = 2,
        [CilOperandTypeSize(8)]
        QwordInteger = 3,
        [CilOperandTypeSize(4)]
        DwordMethod = 4,
        [CilOperandTypeSize(0)]
        None = 5,
        [CilOperandTypeSize(8)]
        QwordFloat = 7,
        [CilOperandTypeSize(4)]
        DwordSignature = 9,
        [CilOperandTypeSize(4)]
        DwordString = 10,
        // The switch operand is a dynamic length table. Whose length is determined by first 4 bytes
        [CilOperandTypeSize(-1)]
        DwordSwitch = 11,
        [CilOperandTypeSize(4)]
        DwordToken = 12,
        [CilOperandTypeSize(4)]
        DwordType = 13,
        [CilOperandTypeSize(2)]
        WordVar = 14,
        [CilOperandTypeSize(1)]
        ByteBrTarget = 15,
        [CilOperandTypeSize(1)]
        ByteInteger = 16,
        [CilOperandTypeSize(4)]
        DwordFloat = 17,
        [CilOperandTypeSize(1)]
        ByteVar = 18
    }
}