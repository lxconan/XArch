using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace XArch.CIL
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CilPEFileHeader
    {
        readonly ushort machine;
        readonly ushort numberOfSections;
        readonly int timeDateStamp;
        readonly ushort optionalHeaderSize;
        readonly ushort characteristics;

        public CilPEFileHeader(BinaryReader reader)
        {
            reader
                .ReadUInt16(out machine, 0x14c, nameof(machine))
                .ReadUInt16(out numberOfSections, null, nameof(numberOfSections))
                .ReadInt32(out timeDateStamp, null, nameof(timeDateStamp))
                .AdvancedBytes(8)
                .ReadUInt16(out optionalHeaderSize, null, nameof(optionalHeaderSize))
                .ReadUInt16(out characteristics, null, nameof(characteristics));
        }

        public ushort OptionalHeaderSize => optionalHeaderSize;
    }
}