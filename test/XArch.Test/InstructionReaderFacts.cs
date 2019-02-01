using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using XArch.CIL;
using XArch.CIL.Formatters;
using Xunit;
using Xunit.Abstractions;

namespace XArch.Test
{
    [SuppressMessage("ReSharper", "StringLiteralTypo", Justification = "For opcode string")]
    [SuppressMessage("ReSharper", "CommentTypo", Justification = "For opcode string")]
    public class InstructionReaderFacts
    {
        readonly ITestOutputHelper output;

        public InstructionReaderFacts(ITestOutputHelper output)
        {
            this.output = output;
        }

        static byte[] GivenIlsForSimpleForLoop()
        {
            // This is the ILs for simple loop program.
            //
            // for (int i = 0; i < 10; ++i) {
            //   Console.WriteLine("Hello" + i);
            // }
            //
            // The decompiled code is something like:
            //
            // IL_0000: nop
            // IL_0001: ldc.i4.0
            // IL_0002: stloc.0
            // 
            // IL_0003: br.s IL_0021
            // 
            // IL_0005: nop
            // IL_0006: ldstr "Hello"
            // IL_000b: ldloc.0
            // IL_000c: box [mscorlib]System.Int32
            // IL_0011: call string [mscorlib]System.String::Concat(object, object)
            // IL_0016: call void [mscorlib]System.Console::WriteLine(string)
            // IL_001b: nop
            // IL_001c: nop
            // IL_001d: ldloc.0
            // IL_001e: ldc.i4.1
            // IL_001f: add
            // IL_0020: stloc.0
            // 
            // IL_0021: ldloc.0
            // IL_0022: ldc.i4.s 10
            // IL_0024: clt
            // IL_0026: stloc.1
            // IL_0027: ldloc.1
            // IL_0028: brtrue.s IL_0005
            // 
            // IL_002a: ret
            return new byte[] {
                0x00, 0x16, 0x0a, 0x2b, 0x1c, 0x00, 0x72, 0x01, 0x00, 
                0x00, 0x70, 0x06, 0x8c, 0x15, 0x00, 0x00, 0x01, 0x28, 
                0x0f, 0x00, 0x00, 0x0a, 0x28, 0x10, 0x00, 0x00, 0x0a, 
                0x00, 0x00, 0x06, 0x17, 0x58, 0x0a, 0x06, 0x1f, 0x0a, 
                0xfe, 0x04, 0x0b, 0x07, 0x2d, 0xdb, 0x2a
            };
        }
        
        static byte[] GivenIlsForSimpleForLoopWithUnrecognizedOpcode()
        {
            // This is the ILs for simple loop program.
            //
            // for (int i = 0; i < 10; ++i) {
            //   Console.WriteLine("Hello" + i);
            // }
            //
            // The decompiled code is something like:
            //
            // IL_0000: nop
            // IL_0001: ldc.i4.0
            // IL_0002: stloc.0
            // 
            // IL_0003: br.s IL_0021
            // 
            // IL_0005: nop
            // IL_0006: ldstr "Hello"
            // IL_000b: ldloc.0
            // IL_000c: box [mscorlib]System.Int32
            // IL_0011: call string [mscorlib]System.String::Concat(object, object)
            // IL_0016: call void [mscorlib]System.Console::WriteLine(string)
            // IL_001b: nop
            // IL_001c: nop
            // IL_001d: ldloc.0
            // IL_001e: ldc.i4.1
            // IL_001f: add
            // IL_0020: stloc.0
            // 
            // IL_0021: ldloc.0
            // IL_0022: ldc.i4.s 10
            // IL_0024: clt
            // IL_0026: stloc.1
            // IL_0027: ldloc.1
            // IL_0028: brtrue.s IL_0005
            // 
            // IL_002a: ret
            return new byte[] {
                0x00, 0x16, 0x0a, 0x2b, 0x1c, 0x00, 0x72, 0x01, 0x00, 
                0x00, 0x70, 0x06, 0x8c, 0x15, 0x00, 0x00, 0x01, 0x28, 
                0x0f, 0x00, 0x00, 0x0a, 0x28, 0x10, 0x00, 0x00, 0x0a, 
                0xff, 0x00, 0x06, 0x17, 0x58, 0x0a, 0x06, 0x1f, 0x0a, 
                0xfe, 0x04, 0x0b, 0x07, 0x2d, 0xdb, 0x2a
            };
        }
        
        static byte[] GivenIlsForSimpleForLoopWithUnexpectedEOF()
        {
            // This is the ILs for simple loop program.
            //
            // for (int i = 0; i < 10; ++i) {
            //   Console.WriteLine("Hello" + i);
            // }
            //
            // The decompiled code is something like:
            //
            // IL_0000: nop
            // IL_0001: ldc.i4.0
            // IL_0002: stloc.0
            // 
            // IL_0003: br.s IL_0021
            // 
            // IL_0005: nop
            // IL_0006: ldstr "Hello"
            // IL_000b: ldloc.0
            // IL_000c: box [mscorlib]System.Int32
            // IL_0011: call string [mscorlib]System.String::Concat(object, object)
            // IL_0016: call void [mscorlib]System.Console::WriteLine(string)
            // IL_001b: nop
            // IL_001c: nop
            // IL_001d: ldloc.0
            // IL_001e: ldc.i4.1
            // IL_001f: add
            // IL_0020: stloc.0
            // 
            // IL_0021: ldloc.0
            // IL_0022: ldc.i4.s 10
            // IL_0024: clt
            // IL_0026: stloc.1
            // IL_0027: ldloc.1
            // IL_0028: brtrue.s [IL_0005]  # IL_0005 omitted.
            
            return new byte[] {
                0x00, 0x16, 0x0a, 0x2b, 0x1c, 0x00, 0x72, 0x01, 0x00, 
                0x00, 0x70, 0x06, 0x8c, 0x15, 0x00, 0x00, 0x01, 0x28, 
                0x0f, 0x00, 0x00, 0x0a, 0x28, 0x10, 0x00, 0x00, 0x0a, 
                0x00, 0x00, 0x06, 0x17, 0x58, 0x0a, 0x06, 0x1f, 0x0a, 
                0xfe, 0x04, 0x0b, 0x07, 0x2d
            };
        }

        [Fact]
        public void should_decompile_raw_il_instructions()
        {
            byte[] sampleInstructions = GivenIlsForSimpleForLoop();
            
            var reader = new InstructionReader(new MemoryStream(sampleInstructions));
            IEnumerable<ICilInstruction> allInstructions = reader.ReadToEnd();

            var formatter = new RawCilInstructionFormatter();
            IEnumerable<string> printedInstructions = formatter.Format(allInstructions);
            
            Assert.Equal(
                new []
                {
                    "nop            ",
                    "ldc.i4.0       ",
                    "stloc.0        ",
                    "br.s           1c",
                    "nop            ",
                    "ldstr          01 00 00 70",
                    "ldloc.0        ",
                    "box            15 00 00 01",
                    "call           0f 00 00 0a",
                    "call           10 00 00 0a",
                    "nop            ",
                    "nop            ",
                    "ldloc.0        ",
                    "ldc.i4.1       ",
                    "add            ",
                    "stloc.0        ",
                    "ldloc.0        ",
                    "ldc.i4.s       0a",
                    "clt            ",
                    "stloc.1        ",
                    "ldloc.1        ",
                    "brtrue.s       db",
                    "ret            "
                },
                printedInstructions);
        }

        [Fact]
        public void should_throw_if_opcode_unrecognized()
        {
            byte[] sampleInstructions = GivenIlsForSimpleForLoopWithUnrecognizedOpcode();
            
            var reader = new InstructionReader(new MemoryStream(sampleInstructions));
            var error = Assert.Throws<BadImageFormatException>(() => reader.ReadToEnd().ToArray());
            
            Assert.Contains("Invalid opcode", error.Message);
        }

        [Fact]
        public void should_throw_if_unexpect_end_of_stream_reached()
        {
            byte[] sampleInstructions = GivenIlsForSimpleForLoopWithUnexpectedEOF();
            
            var reader = new InstructionReader(new MemoryStream(sampleInstructions));
            var error = Assert.Throws<BadImageFormatException>(() => reader.ReadToEnd().ToArray());
            
            Assert.Contains("stream has reach to the end", error.Message);
        }

        [Fact]
        public void should_decompile_all_public_methods_for_string_type()
        {
            var methods = typeof(string).GetMethods()
                .Where(m => m.MemberType == MemberTypes.Method)
                .Select(m => new
                    {
                        Name = $"{m.Name}({string.Join(", ", m.GetParameters().Select(p => p.ParameterType.FullName))})",
                        Body = m.GetMethodBody()
                    })
                .Where(m => m.Body != null)
                .Select(
                    m => new
                    {
                        m.Name,
                        Reader = new InstructionReader(new MemoryStream(m.Body.GetILAsByteArray()))
                    });

            foreach (var method in methods)
            {
                Exception error = Record.Exception(() => method.Reader.ReadToEnd().ToArray());
                if (error != null) { output.WriteLine(method.Name); }
                Assert.Null(error);
            }
        }
    }
}