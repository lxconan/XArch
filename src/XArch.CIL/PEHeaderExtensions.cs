using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace XArch.CIL
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    static class PEHeaderExtensions
    {
        public static BinaryReader ReadPESignature(this BinaryReader reader)
        {
            uint peSignature = reader.ReadUInt32();
            const int expectedSignature = 0x00004550;
            if (peSignature != expectedSignature)
            {
                throw new BadImageFormatException(
                    $"The PE signature is not valid: {peSignature}");
            }

            return reader;
        }
    }
}