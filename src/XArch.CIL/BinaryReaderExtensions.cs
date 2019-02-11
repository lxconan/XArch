using System;
using System.IO;

namespace XArch.CIL
{
    static class BinaryReaderExtensions
    {
        public static BinaryReader AdvancedBytes(this BinaryReader reader, int advancedBytes)
        {
            if (advancedBytes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(advancedBytes));
            }

            if (advancedBytes == 0) { return reader; }

            for (int i = 0; i < advancedBytes; ++i)
            {
                reader.ReadByte();
            }

            return reader;
        }

        public static BinaryReader ReadUInt16(
            this BinaryReader reader,
            out ushort target,
            Action<ushort> validation = null)
        {
            target = 0;
            
            ushort value = reader.ReadUInt16();
            validation?.Invoke(value);
            target = value;
            return reader;
        }
        
        public static BinaryReader ReadInt32(
            this BinaryReader reader,
            out int target,
            Action<int> validation = null)
        {
            target = 0;
            
            int value = reader.ReadInt32();
            validation?.Invoke(value);
            target = value;
            return reader;
        }

        public static BinaryReader ReadUInt16(
            this BinaryReader reader,
            out ushort target,
            ushort? validation = null,
            string fieldName = null)
        {
            return ReadUInt16(
                reader,
                out target,
                validation == null
                    ? (Action<ushort>) null
                    : value => ValidateFieldEqual(
                        validation.Value,
                        value,
                        fieldName,
                        v => v.ToString("x4")));
        }

        public static BinaryReader ReadInt32(
            this BinaryReader reader,
            out int target,
            int? validation = null,
            string fieldName = null)
        {
            return ReadInt32(
                reader,
                out target,
                validation == null
                    ? (Action<int>) null
                    : value => ValidateFieldEqual(
                        validation.Value,
                        value,
                        fieldName,
                        v => v.ToString("x8")));
        }

        static void ValidateFieldEqual<T>(T expected, T actual, string fieldName, Func<T, string> formatter)
            where T : IEquatable<T>
        {
            if (expected.Equals(actual)) return;
            string message = fieldName == null
                ? $"The value {formatter(actual)} does not match the expectation {formatter(expected)}"
                : $"The field \"{fieldName}\" value {formatter(actual)} does not match the expectation {formatter(expected)}";
            throw new BadImageFormatException(message);
        }
    }
}