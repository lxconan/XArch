using System;
using System.IO;
using System.Linq;

namespace XArch.CIL
{
    static class DosHeaderExtensions
    {
        static readonly byte[] expectedDosStubHeader =
        {
            0x0E, 0x1F, 0xBA, 0x0E, 0x00, 0xB4, 0x09, 0xCD, 0x21, 0xB8, 0x01, 0x4C, 0xCD, 0x21,
            0x54, 0x68, 0x69, 0x73, 0x20, 0x70, 0x72, 0x6F, 0x67, 0x72, 0x61, 0x6D, 0x20, 0x63,
            0x61, 0x6E, 0x6E, 0x6F, 0x74, 0x20, 0x62, 0x65, 0x20, 0x72, 0x75, 0x6E, 0x20, 0x69,
            0x6E, 0x20, 0x44, 0x4F, 0x53, 0x20, 0x6D, 0x6F, 0x64, 0x65, 0x2E, 0x0D, 0x0D, 0x0A,
            0x24, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };
        
        public static BinaryReader ReadMsDosSignature(this BinaryReader reader)
        {
            ushort signature = reader.ReadUInt16();
            if (signature != 0x5a4d)
            {
                throw new BadImageFormatException("Invalid MS-DOS file header.");
            }

            return reader;
        }

        public static BinaryReader AdvancedDosStub(this BinaryReader reader, bool validate = true)
        {
            const int expectedCount = 64;
            byte[] dosStubHeader = reader.ReadBytes(expectedCount);
            if (dosStubHeader.Length != expectedCount)
            {
                throw new BadImageFormatException(
                    "Invalid MS-DOS Stub header. End of stream reached.");
            }

            return validate && !expectedDosStubHeader.SequenceEqual(dosStubHeader)
                ? throw new BadImageFormatException("Invalid MS-DOS Stub header.")
                : reader;
        }
    }
}