using System;
using System.IO;

namespace XArch.CIL
{
    public class CilOptionalHeader
    {
        public CilOptionalHeader(BinaryReader reader, int optionalHeaderSize)
        {
            if (optionalHeaderSize < 0xe0)
            {
                throw new BadImageFormatException(
                    $"The optional header size is too small: {optionalHeaderSize}");
            }

            reader.AdvancedBytes(optionalHeaderSize);
        }
    }
}