using System.Diagnostics.CodeAnalysis;

namespace XArch.CIL
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public enum Machine : ushort
    {
        Unknown = 0x0,
        AM33 = 0x1d3,
        X64 = 0x8664,
        ARM = 0x1c0,
        ARM64 = 0xaa64,
        ARMNT = 0x1c4,
        EBC = 0xebc,
        I386 = 0x14c,
        IA64 = 0x200,
        M32R = 0x9041,
        MIPS16 = 0x266,
        MIPSFPU = 0x366,
        MIPSFPU16 = 0x466,
        POWERPC = 0x1f0 ,
        POWERPCFP =0x1f1,
        R4000 = 0x166,
        RISCV32 = 0x5032,
        RISCV64 = 0x5064,
        RISCV128 = 0x5128,
        SH3 = 0x1a2,
        SH3DSP = 0x1a3,
        SH4 = 0x1a6,
        SH5 = 0x1a8,
        THUMB = 0x1c2,
        WCEMIPSV2 = 0x169
    }
}