using System;

namespace XArch.CIL
{
    public struct CilOpcodeValue : IEquatable<CilOpcodeValue>
    {
        public byte FirstByte { get; }
        public byte SecondByte { get; }
        public int Size { get; }

        public CilOpcodeValue(byte firstByte, byte secondByte)
        {
            FirstByte = firstByte;
            SecondByte = secondByte;
            Size = 2;
        }

        public CilOpcodeValue(byte firstByte)
        {
            FirstByte = firstByte;
            SecondByte = 0;
            Size = 1;
        }

        public bool Equals(CilOpcodeValue other)
        {
            return FirstByte == other.FirstByte && SecondByte == other.SecondByte &&
                   Size == other.Size;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is CilOpcodeValue other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = FirstByte.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondByte.GetHashCode();
                hashCode = (hashCode * 397) ^ Size;
                return hashCode;
            }
        }

        public static bool operator ==(CilOpcodeValue left, CilOpcodeValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CilOpcodeValue left, CilOpcodeValue right)
        {
            return !(left == right);
        }
    }
}