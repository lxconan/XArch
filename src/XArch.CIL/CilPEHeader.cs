using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace XArch.CIL
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CilPEHeader
    {
        public CilPEHeader(BinaryReader reader)
        {
            reader.ReadPESignature();
            FileHeader = new CilPEFileHeader(reader);
            OptionalHeader = new CilOptionalHeader(reader, FileHeader.OptionalHeaderSize);
        }

        public CilPEFileHeader FileHeader { get; }
        public CilOptionalHeader OptionalHeader { get; }
    }
}