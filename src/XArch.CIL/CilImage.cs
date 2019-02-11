using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace XArch.CIL
{
    public class CilImage
    {
        readonly BinaryReader reader;

        public static CilImage InitializeFrom(Stream stream)
        {
            var image = new CilImage(stream);
            image.ReadAll();
            return image;
        }

        CilImage(Stream stream)
        {
            if (stream == null) {throw new ArgumentNullException(nameof(stream)); }
            if (!(stream.CanRead && stream.CanSeek))
            {
                throw new NotSupportedException(
                    "The CIL image currently only support seekable stream.");
            }

            reader = new BinaryReader(stream, Encoding.ASCII, true);
        }


        void ReadAll()
        {
            ReadDosHeader();
            ReadPEHeader();
        }

        void ReadPEHeader()
        {
            PEHeader = new CilPEHeader(reader);
        }

        void ReadDosHeader()
        {
            DosHeader = new DosHeader(reader);
            reader.AdvancedDosStub();
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public CilPEHeader PEHeader { get; private set; }
        internal DosHeader DosHeader { get; private set; }
    }
}