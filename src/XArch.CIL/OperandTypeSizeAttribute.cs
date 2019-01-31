using System;

namespace XArch.CIL
{
    class OperandTypeSizeAttribute : Attribute
    {
        public OperandTypeSizeAttribute(int size) { Size = size; }
        public int Size { get; }
    }
}