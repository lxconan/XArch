using System.Diagnostics.CodeAnalysis;
using System.IO;
using XArch.CIL;
using Xunit;
using Xunit.Abstractions;

namespace XArch.Test
{
    [SuppressMessage("ReSharper", "StringLiteralTypo", Justification = "For opcode string")]
    public class InstructionReaderFacts
    {
        readonly ITestOutputHelper output;

        public InstructionReaderFacts(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void should_read_instructions_from_method()
        {
            byte[] sampleInstructions =
            {
                0x02, 0x4a, 0x14, 0x28, 0x3a, 0x00, 0x00, 0x0a, 0x14, 0x28, 0xc4, 0x06, 0x00, 0x06,
                0x2a
            };

            var reader = new InstructionReader(new MemoryStream(sampleInstructions));
            Instruction instruction = reader.Read();

            Assert.Equal("ldarg.0", instruction.Opcode.Name);
            Assert.Equal(IlOperandType.None, instruction.Operand.Type);
        }
    }
}