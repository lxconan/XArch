using System;

namespace XArch.CIL
{
    class CilOperandTypeSizeAttribute : Attribute
    {
        public CilOperandTypeSizeAttribute(int size) { Size = size; }
        public int Size { get; }
        public bool IsDynamicSize => Size == -1;
    }
}