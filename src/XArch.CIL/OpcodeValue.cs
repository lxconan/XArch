using System;

namespace XArch.CIL
{
    public struct OpcodeValue : IEquatable<OpcodeValue>
    {
        public byte FirstByte { get; }
        public byte SecondByte { get; }
        public int Size { get; }

        public OpcodeValue(byte firstByte, byte secondByte)
        {
            FirstByte = firstByte;
            SecondByte = secondByte;
            Size = 2;
        }

        public OpcodeValue(byte firstByte)
        {
            FirstByte = firstByte;
            SecondByte = 0;
            Size = 1;
        }

        public bool Equals(OpcodeValue other)
        {
            return FirstByte == other.FirstByte && SecondByte == other.SecondByte &&
                   Size == other.Size;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is OpcodeValue other && Equals(other);
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

        public static bool operator ==(OpcodeValue left, OpcodeValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OpcodeValue left, OpcodeValue right)
        {
            return !(left == right);
        }
    }
}