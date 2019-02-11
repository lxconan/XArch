using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace XArch.CIL
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DosHeader
    {
        readonly ushort usedBytesInTheLastPage;
        readonly ushort fileSizeInPages;
        readonly ushort numberOfRelocationItems;
        readonly ushort headerSizeInParagraphs;
        readonly ushort minExtraParagraphs;
        readonly ushort maxExtraParagraphs;
        readonly ushort initialRelativeSs;
        readonly ushort initialSp;
        readonly ushort checksum;
        readonly ushort initialIp;
        readonly ushort initialRelativeCs;
        readonly ushort addressOfRelocationTable;
        readonly ushort overlayNumber;
        readonly ushort oemId;
        readonly ushort oemInfo;
        readonly int addressOfNewExeHeader;

        internal DosHeader(BinaryReader reader)
        {
            reader
                .ReadMsDosSignature()
                .ReadUInt16(out usedBytesInTheLastPage, 0x0090, nameof(usedBytesInTheLastPage))
                .ReadUInt16(out fileSizeInPages, 0x0003, nameof(fileSizeInPages))
                .ReadUInt16(out numberOfRelocationItems,0, nameof(numberOfRelocationItems))
                .ReadUInt16(out headerSizeInParagraphs,0x0004, nameof(headerSizeInParagraphs))
                .ReadUInt16(out minExtraParagraphs, 0, nameof(minExtraParagraphs))
                .ReadUInt16(out maxExtraParagraphs ,0xffff, nameof(maxExtraParagraphs))
                .ReadUInt16(out initialRelativeSs, 0, nameof(initialRelativeSs))
                .ReadUInt16(out initialSp,0x00b8, nameof(initialSp))
                .ReadUInt16(out checksum, 0, nameof(checksum))
                .ReadUInt16(out initialIp, 0, nameof(initialIp))
                .ReadUInt16(out initialRelativeCs,0, nameof(initialRelativeCs))
                .ReadUInt16(out addressOfRelocationTable, 0x0040, nameof(addressOfRelocationTable))
                .ReadUInt16(out overlayNumber, 0, nameof(overlayNumber))
                .AdvancedBytes(4 * sizeof(ushort))
                .ReadUInt16(out oemId, 0, nameof(oemId))
                .ReadUInt16(out oemInfo, 0, nameof(oemInfo))
                .AdvancedBytes(10 * sizeof(ushort))
                .ReadInt32(out addressOfNewExeHeader, null, nameof(addressOfNewExeHeader));
        }
        
        public ushort UsedBytesInTheLastPage => usedBytesInTheLastPage;

        public ushort FileSizeInPages => fileSizeInPages;

        public ushort NumberOfRelocationItems => numberOfRelocationItems;

        public ushort HeaderSizeInParagraphs => headerSizeInParagraphs;

        public ushort MinExtraParagraphs => minExtraParagraphs;

        public ushort MaxExtraParagraphs => maxExtraParagraphs;

        public ushort InitialRelativeSS => initialRelativeSs;

        public ushort InitialSP => initialSp;

        public ushort Checksum => checksum;

        public ushort InitialIP => initialIp;

        public ushort InitialRelativeCS => initialRelativeCs;

        public ushort AddressOfRelocationTable => addressOfRelocationTable;

        public ushort OverlayNumber => overlayNumber;

        public ushort OEMId => oemId;

        public ushort OEMInfo => oemInfo;

        public int AddressOfNewExeHeader => addressOfNewExeHeader;
    }
}