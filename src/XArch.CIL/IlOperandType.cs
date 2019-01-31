namespace XArch.CIL
{
    public enum IlOperandType
    {
        [OperandTypeSize(4)]
        DwordBrTarget = 0,
        [OperandTypeSize(4)]
        DwordField = 1,
        [OperandTypeSize(4)]
        DwordInteger = 2,
        [OperandTypeSize(8)]
        QwordInteger = 3,
        [OperandTypeSize(4)]
        DwordMethod = 4,
        [OperandTypeSize(0)]
        None = 5,
        [OperandTypeSize(8)]
        QwordFloat = 7,
        [OperandTypeSize(4)]
        DwordSignature = 9,
        [OperandTypeSize(4)]
        DwordString = 10,
        [OperandTypeSize(4)]
        DwordSwitch = 11,
        [OperandTypeSize(4)]
        DwordToken = 12,
        [OperandTypeSize(4)]
        DwordType = 13,
        [OperandTypeSize(2)]
        WordVar = 14,
        [OperandTypeSize(1)]
        ByteBrTarget = 15,
        [OperandTypeSize(1)]
        ByteInteger = 16,
        [OperandTypeSize(4)]
        DwordFloat = 17,
        [OperandTypeSize(1)]
        ByteVar = 18
    }
}