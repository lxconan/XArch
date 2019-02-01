using System;

namespace XArch.CIL
{
    class CilOperandTypeSizeAttribute : Attribute
    {
        public const int InvalidSize = -1;
        
        public CilOperandTypeSizeAttribute(int size) { Size = size; }
        public CilOperandTypeSizeAttribute() : this(InvalidSize) { }
        
        public int Size { get; }
        public bool IsDynamicSize => Size == InvalidSize;
    }
}