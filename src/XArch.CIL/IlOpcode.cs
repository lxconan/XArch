using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace XArch.CIL
{
    public class IlOpcode
    {
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        internal static readonly IReadOnlyDictionary<OpcodeValue, IlOpcode> OpcodeTable =
            new Dictionary<OpcodeValue, IlOpcode>
            {
                {
                    new OpcodeValue(0x00),
                    new IlOpcode(
                        new OpcodeValue(0x00),
                        "nop",
                        "Do nothing (No operation).",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x01),
                    new IlOpcode(
                        new OpcodeValue(0x01),
                        "break",
                        "Inform a debugger that a breakpoint has been reached.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x02),
                    new IlOpcode(
                        new OpcodeValue(0x02),
                        "ldarg.0",
                        "Load argument 0 onto the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x03),
                    new IlOpcode(
                        new OpcodeValue(0x03),
                        "ldarg.1",
                        "Load argument 1 onto the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x04),
                    new IlOpcode(
                        new OpcodeValue(0x04),
                        "ldarg.2",
                        "Load argument 2 onto the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x05),
                    new IlOpcode(
                        new OpcodeValue(0x05),
                        "ldarg.3",
                        "Load argument 3 onto the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x06),
                    new IlOpcode(
                        new OpcodeValue(0x06),
                        "ldloc.0",
                        "Load local variable 0 onto stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x07),
                    new IlOpcode(
                        new OpcodeValue(0x07),
                        "ldloc.1",
                        "Load local variable 1 onto stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x08),
                    new IlOpcode(
                        new OpcodeValue(0x08),
                        "ldloc.2",
                        "Load local variable 2 onto stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x09),
                    new IlOpcode(
                        new OpcodeValue(0x09),
                        "ldloc.3",
                        "Load local variable 3 onto stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x0A),
                    new IlOpcode(
                        new OpcodeValue(0x0A),
                        "stloc.0",
                        "Pop a value from stack into local variable 0.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x0B),
                    new IlOpcode(
                        new OpcodeValue(0x0B),
                        "stloc.1",
                        "Pop a value from stack into local variable 1.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x0C),
                    new IlOpcode(
                        new OpcodeValue(0x0C),
                        "stloc.2",
                        "Pop a value from stack into local variable 2.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x0D),
                    new IlOpcode(
                        new OpcodeValue(0x0D),
                        "stloc.3",
                        "Pop a value from stack into local variable 3.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x0E),
                    new IlOpcode(
                        new OpcodeValue(0x0E),
                        "ldarg.s",
                        "Load argument numbered num onto the stack, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteVar)
                },
                {
                    new OpcodeValue(0x0F),
                    new IlOpcode(
                        new OpcodeValue(0x0F),
                        "ldarga.s",
                        "Fetch the address of argument argNum, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteVar)
                },
                {
                    new OpcodeValue(0x10),
                    new IlOpcode(
                        new OpcodeValue(0x10),
                        "starg.s",
                        "Store value to the argument numbered num, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteVar)
                },
                {
                    new OpcodeValue(0x11),
                    new IlOpcode(
                        new OpcodeValue(0x11),
                        "ldloc.s",
                        "Load local variable of index indx onto stack, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteVar)
                },
                {
                    new OpcodeValue(0x12),
                    new IlOpcode(
                        new OpcodeValue(0x12),
                        "ldloca.s",
                        "Load address of local variable with index indx, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteVar)
                },
                {
                    new OpcodeValue(0x13),
                    new IlOpcode(
                        new OpcodeValue(0x13),
                        "stloc.s",
                        "Pop a value from stack into local variable indx, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteVar)
                },
                {
                    new OpcodeValue(0x14),
                    new IlOpcode(
                        new OpcodeValue(0x14),
                        "ldnull",
                        "Push a null reference on the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x15),
                    new IlOpcode(
                        new OpcodeValue(0x15),
                        "ldc.i4.m1",
                        "Push -1 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x16),
                    new IlOpcode(
                        new OpcodeValue(0x16),
                        "ldc.i4.0",
                        "Push 0 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x17),
                    new IlOpcode(
                        new OpcodeValue(0x17),
                        "ldc.i4.1",
                        "Push 1 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x18),
                    new IlOpcode(
                        new OpcodeValue(0x18),
                        "ldc.i4.2",
                        "Push 2 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x19),
                    new IlOpcode(
                        new OpcodeValue(0x19),
                        "ldc.i4.3",
                        "Push 3 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x1A),
                    new IlOpcode(
                        new OpcodeValue(0x1A),
                        "ldc.i4.4",
                        "Push 4 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x1B),
                    new IlOpcode(
                        new OpcodeValue(0x1B),
                        "ldc.i4.5",
                        "Push 5 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x1C),
                    new IlOpcode(
                        new OpcodeValue(0x1C),
                        "ldc.i4.6",
                        "Push 6 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x1D),
                    new IlOpcode(
                        new OpcodeValue(0x1D),
                        "ldc.i4.7",
                        "Push 7 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x1E),
                    new IlOpcode(
                        new OpcodeValue(0x1E),
                        "ldc.i4.8",
                        "Push 8 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x1F),
                    new IlOpcode(
                        new OpcodeValue(0x1F),
                        "ldc.i4.s",
                        "Push num onto the stack as int32, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteInteger)
                },
                {
                    new OpcodeValue(0x20),
                    new IlOpcode(
                        new OpcodeValue(0x20),
                        "ldc.i4",
                        "Push num of type int32 onto the stack as int32.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordInteger)
                },
                {
                    new OpcodeValue(0x21),
                    new IlOpcode(
                        new OpcodeValue(0x21),
                        "ldc.i8",
                        "Push num of type int64 onto the stack as int64.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.QwordInteger)
                },
                {
                    new OpcodeValue(0x22),
                    new IlOpcode(
                        new OpcodeValue(0x22),
                        "ldc.r4",
                        "Push num of type float32 onto the stack as F.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordFloat)
                },
                {
                    new OpcodeValue(0x23),
                    new IlOpcode(
                        new OpcodeValue(0x23),
                        "ldc.r8",
                        "Push num of type float64 onto the stack as F.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.QwordFloat)
                },
                {
                    new OpcodeValue(0x25),
                    new IlOpcode(
                        new OpcodeValue(0x25),
                        "dup",
                        "Duplicate the value on the top of the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x26),
                    new IlOpcode(
                        new OpcodeValue(0x26),
                        "pop",
                        "Pop value from the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x27),
                    new IlOpcode(
                        new OpcodeValue(0x27),
                        "jmp",
                        "Exit current method and jump to the specified method.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordMethod)
                },
                {
                    new OpcodeValue(0x28),
                    new IlOpcode(
                        new OpcodeValue(0x28),
                        "call",
                        "Call method described by method.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordMethod)
                },
                {
                    new OpcodeValue(0x29),
                    new IlOpcode(
                        new OpcodeValue(0x29),
                        "calli",
                        "Call method indicated on the stack with arguments described by callsitedescr.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordSignature)
                },
                {
                    new OpcodeValue(0x2A),
                    new IlOpcode(
                        new OpcodeValue(0x2A),
                        "ret",
                        "Return from method, possibly with a value.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x2B),
                    new IlOpcode(
                        new OpcodeValue(0x2B),
                        "br.s",
                        "Branch to target, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x2C),
                    new IlOpcode(
                        new OpcodeValue(0x2C),
                        "brfalse.s",
                        "Branch to target if value is zero (false), short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x2D),
                    new IlOpcode(
                        new OpcodeValue(0x2D),
                        "brtrue.s",
                        "Branch to target if value is non-zero (true), short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x2E),
                    new IlOpcode(
                        new OpcodeValue(0x2E),
                        "beq.s ",
                        "Branch to target if equal, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x2F),
                    new IlOpcode(
                        new OpcodeValue(0x2F),
                        "bge.s ",
                        "Branch to target if greater than or equal to, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x30),
                    new IlOpcode(
                        new OpcodeValue(0x30),
                        "bgt.s ",
                        "Branch to target if greater than, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x31),
                    new IlOpcode(
                        new OpcodeValue(0x31),
                        "ble.s",
                        "Branch to target if less than or equal to, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x32),
                    new IlOpcode(
                        new OpcodeValue(0x32),
                        "blt.s",
                        "Branch to target if less than, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x33),
                    new IlOpcode(
                        new OpcodeValue(0x33),
                        "bne.un.s",
                        "Branch to target if unequal or unordered, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x34),
                    new IlOpcode(
                        new OpcodeValue(0x34),
                        "bge.un.s",
                        "Branch to target if greater than or equal to (unsigned or unordered), short form",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x35),
                    new IlOpcode(
                        new OpcodeValue(0x35),
                        "bgt.un.s",
                        "Branch to target if greater than (unsigned or unordered), short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x36),
                    new IlOpcode(
                        new OpcodeValue(0x36),
                        "ble.un.s",
                        "Branch to target if less than or equal to (unsigned or unordered), short form",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x37),
                    new IlOpcode(
                        new OpcodeValue(0x37),
                        "blt.un.s",
                        "Branch to target if less than (unsigned or unordered), short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0x38),
                    new IlOpcode(
                        new OpcodeValue(0x38),
                        "br",
                        "Branch to target.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x39),
                    new IlOpcode(
                        new OpcodeValue(0x39),
                        "brfalse",
                        "Branch to target if value is zero (false).",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x3A),
                    new IlOpcode(
                        new OpcodeValue(0x3A),
                        "brtrue",
                        "Branch to target if value is non-zero (true).",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x3B),
                    new IlOpcode(
                        new OpcodeValue(0x3B),
                        "beq",
                        "Branch to target if equal.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x3C),
                    new IlOpcode(
                        new OpcodeValue(0x3C),
                        "bge",
                        "Branch to target if greater than or equal to.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x3D),
                    new IlOpcode(
                        new OpcodeValue(0x3D),
                        "bgt",
                        "Branch to target if greater than.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x3E),
                    new IlOpcode(
                        new OpcodeValue(0x3E),
                        "ble",
                        "Branch to target if less than or equal to.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x3F),
                    new IlOpcode(
                        new OpcodeValue(0x3F),
                        "blt",
                        "Branch to target if less than.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x40),
                    new IlOpcode(
                        new OpcodeValue(0x40),
                        "bne.un",
                        "Branch to target if unequal or unordered.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x41),
                    new IlOpcode(
                        new OpcodeValue(0x41),
                        "bge.un",
                        "Branch to target if greater than or equal to (unsigned or unordered).",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x42),
                    new IlOpcode(
                        new OpcodeValue(0x42),
                        "bgt.un",
                        "Branch to target if greater than (unsigned or unordered).",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x43),
                    new IlOpcode(
                        new OpcodeValue(0x43),
                        "ble.un",
                        "Branch to target if less than or equal to (unsigned or unordered).",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x44),
                    new IlOpcode(
                        new OpcodeValue(0x44),
                        "blt.un",
                        "Branch to target if less than (unsigned or unordered).",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0x45),
                    new IlOpcode(
                        new OpcodeValue(0x45),
                        "switch",
                        "Jump to one of n values.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordSwitch)
                },
                {
                    new OpcodeValue(0x46),
                    new IlOpcode(
                        new OpcodeValue(0x46),
                        "ldind.i1",
                        "Indirect load value of type int8 as int32 on the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x47),
                    new IlOpcode(
                        new OpcodeValue(0x47),
                        "ldind.u1",
                        "Indirect load value of type unsigned int8 as int32 on the stack",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x48),
                    new IlOpcode(
                        new OpcodeValue(0x48),
                        "ldind.i2",
                        "Indirect load value of type int16 as int32 on the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x49),
                    new IlOpcode(
                        new OpcodeValue(0x49),
                        "ldind.u2",
                        "Indirect load value of type unsigned int16 as int32 on the stack",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x4A),
                    new IlOpcode(
                        new OpcodeValue(0x4A),
                        "ldind.i4",
                        "Indirect load value of type int32 as int32 on the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x4B),
                    new IlOpcode(
                        new OpcodeValue(0x4B),
                        "ldind.u4",
                        "Indirect load value of type unsigned int32 as int32 on the stack",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x4C),
                    new IlOpcode(
                        new OpcodeValue(0x4C),
                        "ldind.i8",
                        "Indirect load value of type int64 as int64 on the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x4D),
                    new IlOpcode(
                        new OpcodeValue(0x4D),
                        "ldind.i",
                        "Indirect load value of type native int as native int on the stack",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x4E),
                    new IlOpcode(
                        new OpcodeValue(0x4E),
                        "ldind.r4",
                        "Indirect load value of type float32 as F on the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x4F),
                    new IlOpcode(
                        new OpcodeValue(0x4F),
                        "ldind.r8",
                        "Indirect load value of type float64 as F on the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x50),
                    new IlOpcode(
                        new OpcodeValue(0x50),
                        "ldind.ref",
                        "Indirect load value of type object ref as O on the stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x51),
                    new IlOpcode(
                        new OpcodeValue(0x51),
                        "stind.ref",
                        "Store value of type object ref (type O) into memory at address",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x52),
                    new IlOpcode(
                        new OpcodeValue(0x52),
                        "stind.i1",
                        "Store value of type int8 into memory at address",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x53),
                    new IlOpcode(
                        new OpcodeValue(0x53),
                        "stind.i2",
                        "Store value of type int16 into memory at address",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x54),
                    new IlOpcode(
                        new OpcodeValue(0x54),
                        "stind.i4",
                        "Store value of type int32 into memory at address",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x55),
                    new IlOpcode(
                        new OpcodeValue(0x55),
                        "stind.i8",
                        "Store value of type int64 into memory at address",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x56),
                    new IlOpcode(
                        new OpcodeValue(0x56),
                        "stind.r4",
                        "Store value of type float32 into memory at address",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x57),
                    new IlOpcode(
                        new OpcodeValue(0x57),
                        "stind.r8",
                        "Store value of type float64 into memory at address",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x58),
                    new IlOpcode(
                        new OpcodeValue(0x58),
                        "add",
                        "Add two values, returning a new value.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x59),
                    new IlOpcode(
                        new OpcodeValue(0x59),
                        "sub",
                        "Subtract value2 from value1, returning a new value.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x5A),
                    new IlOpcode(
                        new OpcodeValue(0x5A),
                        "mul",
                        "Multiply values.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x5B),
                    new IlOpcode(
                        new OpcodeValue(0x5B),
                        "div",
                        "Divide two values to return a quotient or floating-point result.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x5C),
                    new IlOpcode(
                        new OpcodeValue(0x5C),
                        "div.un",
                        "Divide two values, unsigned, returning a quotient.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x5D),
                    new IlOpcode(
                        new OpcodeValue(0x5D),
                        "rem",
                        "Remainder when dividing one value by another.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x5E),
                    new IlOpcode(
                        new OpcodeValue(0x5E),
                        "rem.un",
                        "Remainder when dividing one unsigned value by another.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x5F),
                    new IlOpcode(
                        new OpcodeValue(0x5F),
                        "and",
                        "Bitwise AND of two integral values, returns an integral value.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x60),
                    new IlOpcode(
                        new OpcodeValue(0x60),
                        "or",
                        "Bitwise OR of two integer values, returns an integer.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x61),
                    new IlOpcode(
                        new OpcodeValue(0x61),
                        "xor",
                        "Bitwise XOR of integer values, returns an integer.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x62),
                    new IlOpcode(
                        new OpcodeValue(0x62),
                        "shl",
                        "Shift an integer left (shifting in zeros), return an integer.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x63),
                    new IlOpcode(
                        new OpcodeValue(0x63),
                        "shr",
                        "Shift an integer right (shift in sign), return an integer.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x64),
                    new IlOpcode(
                        new OpcodeValue(0x64),
                        "shr.un",
                        "Shift an integer right (shift in zero), return an integer.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x65),
                    new IlOpcode(
                        new OpcodeValue(0x65),
                        "neg",
                        "Negate value.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x66),
                    new IlOpcode(
                        new OpcodeValue(0x66),
                        "not",
                        "Bitwise complement (logical not).",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x67),
                    new IlOpcode(
                        new OpcodeValue(0x67),
                        "conv.i1",
                        "Convert to int8, pushing int32 on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x68),
                    new IlOpcode(
                        new OpcodeValue(0x68),
                        "conv.i2",
                        "Convert to int16, pushing int32 on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x69),
                    new IlOpcode(
                        new OpcodeValue(0x69),
                        "conv.i4",
                        "Convert to int32, pushing int32 on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x6A),
                    new IlOpcode(
                        new OpcodeValue(0x6A),
                        "conv.i8",
                        "Convert to int64, pushing int64 on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x6B),
                    new IlOpcode(
                        new OpcodeValue(0x6B),
                        "conv.r4",
                        "Convert to float32, pushing F on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x6C),
                    new IlOpcode(
                        new OpcodeValue(0x6C),
                        "conv.r8",
                        "Convert to float64, pushing F on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x6D),
                    new IlOpcode(
                        new OpcodeValue(0x6D),
                        "conv.u4",
                        "Convert to unsigned int32, pushing int32 on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x6E),
                    new IlOpcode(
                        new OpcodeValue(0x6E),
                        "conv.u8",
                        "Convert to unsigned int64, pushing int64 on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x6F),
                    new IlOpcode(
                        new OpcodeValue(0x6F),
                        "callvirt",
                        "Call a method associated with an object.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordMethod)
                },
                {
                    new OpcodeValue(0x70),
                    new IlOpcode(
                        new OpcodeValue(0x70),
                        "cpobj",
                        "Copy a value type from src to dest.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x71),
                    new IlOpcode(
                        new OpcodeValue(0x71),
                        "ldobj",
                        "Copy the value stored at address src to the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x72),
                    new IlOpcode(
                        new OpcodeValue(0x72),
                        "ldstr",
                        "Push a string object for the literal string.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordString)
                },
                {
                    new OpcodeValue(0x73),
                    new IlOpcode(
                        new OpcodeValue(0x73),
                        "newobj",
                        "Allocate an uninitialized object or value type and call ctor.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordMethod)
                },
                {
                    new OpcodeValue(0x74),
                    new IlOpcode(
                        new OpcodeValue(0x74),
                        "castclass",
                        "Cast obj to class.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x75),
                    new IlOpcode(
                        new OpcodeValue(0x75),
                        "isinst",
                        "Test if obj is an instance of class, returning null or an instance of that class or interface.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x76),
                    new IlOpcode(
                        new OpcodeValue(0x76),
                        "conv.r.un",
                        "Convert unsigned integer to floating-point, pushing F on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x79),
                    new IlOpcode(
                        new OpcodeValue(0x79),
                        "unbox",
                        "Extract a value-type from obj, its boxed representation.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x7A),
                    new IlOpcode(
                        new OpcodeValue(0x7A),
                        "throw",
                        "Throw an exception.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x7B),
                    new IlOpcode(
                        new OpcodeValue(0x7B),
                        "ldfld",
                        "Push the value of field of object (or value type) obj, onto the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordField)
                },
                {
                    new OpcodeValue(0x7C),
                    new IlOpcode(
                        new OpcodeValue(0x7C),
                        "ldflda",
                        "Push the address of field of object obj on the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordField)
                },
                {
                    new OpcodeValue(0x7D),
                    new IlOpcode(
                        new OpcodeValue(0x7D),
                        "stfld",
                        "Replace the value of field of the object obj with value.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordField)
                },
                {
                    new OpcodeValue(0x7E),
                    new IlOpcode(
                        new OpcodeValue(0x7E),
                        "ldsfld",
                        "Push the value of the static field on the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordField)
                },
                {
                    new OpcodeValue(0x7F),
                    new IlOpcode(
                        new OpcodeValue(0x7F),
                        "ldsflda",
                        "Push the address of the static field, field, on the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordField)
                },
                {
                    new OpcodeValue(0x80),
                    new IlOpcode(
                        new OpcodeValue(0x80),
                        "stsfld",
                        "Replace the value of the static field with val.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordField)
                },
                {
                    new OpcodeValue(0x81),
                    new IlOpcode(
                        new OpcodeValue(0x81),
                        "stobj",
                        "Store a value of type typeTok at an address.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x82),
                    new IlOpcode(
                        new OpcodeValue(0x82),
                        "conv.ovf.i1.un",
                        "Convert unsigned to an int8 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x83),
                    new IlOpcode(
                        new OpcodeValue(0x83),
                        "conv.ovf.i2.un",
                        "Convert unsigned to an int16 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x84),
                    new IlOpcode(
                        new OpcodeValue(0x84),
                        "conv.ovf.i4.un",
                        "Convert unsigned to an int32 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x85),
                    new IlOpcode(
                        new OpcodeValue(0x85),
                        "conv.ovf.i8.un",
                        "Convert unsigned to an int64 (on the stack as int64) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x86),
                    new IlOpcode(
                        new OpcodeValue(0x86),
                        "conv.ovf.u1.un",
                        "Convert unsigned to an unsigned int8 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x87),
                    new IlOpcode(
                        new OpcodeValue(0x87),
                        "conv.ovf.u2.un",
                        "Convert unsigned to an unsigned int16 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x88),
                    new IlOpcode(
                        new OpcodeValue(0x88),
                        "conv.ovf.u4.un",
                        "Convert unsigned to an unsigned int32 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x89),
                    new IlOpcode(
                        new OpcodeValue(0x89),
                        "conv.ovf.u8.un",
                        "Convert unsigned to an unsigned int64 (on the stack as int64) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x8A),
                    new IlOpcode(
                        new OpcodeValue(0x8A),
                        "conv.ovf.i.un",
                        "Convert unsigned to a native int (on the stack as native int) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x8B),
                    new IlOpcode(
                        new OpcodeValue(0x8B),
                        "conv.ovf.u.un",
                        "Convert unsigned to a native unsigned int (on the stack as native int) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0x8C),
                    new IlOpcode(
                        new OpcodeValue(0x8C),
                        "box",
                        "Convert a boxable value to its boxed form",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x8D),
                    new IlOpcode(
                        new OpcodeValue(0x8D),
                        "newarr",
                        "Create a new array with elements of type etype.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x8E),
                    new IlOpcode(
                        new OpcodeValue(0x8E),
                        "ldlen",
                        "Push the length (of type native unsigned int) of array on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x8F),
                    new IlOpcode(
                        new OpcodeValue(0x8F),
                        "ldelema",
                        "Load the address of element at index onto the top of the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0x90),
                    new IlOpcode(
                        new OpcodeValue(0x90),
                        "ldelem.i1",
                        "Load the element with type int8 at index onto the top of the stack as an int32.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x91),
                    new IlOpcode(
                        new OpcodeValue(0x91),
                        "ldelem.u1",
                        "Load the element with type unsigned int8 at index onto the top of the stack as an int32.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x92),
                    new IlOpcode(
                        new OpcodeValue(0x92),
                        "ldelem.i2",
                        "Load the element with type int16 at index onto the top of the stack as an int32.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x93),
                    new IlOpcode(
                        new OpcodeValue(0x93),
                        "ldelem.u2",
                        "Load the element with type unsigned int16 at index onto the top of the stack as an int32.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x94),
                    new IlOpcode(
                        new OpcodeValue(0x94),
                        "ldelem.i4",
                        "Load the element with type int32 at index onto the top of the stack as an int32.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x95),
                    new IlOpcode(
                        new OpcodeValue(0x95),
                        "ldelem.u4",
                        "Load the element with type unsigned int32 at index onto the top of the stack as an int32.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x96),
                    new IlOpcode(
                        new OpcodeValue(0x96),
                        "ldelem.i8",
                        "Load the element with type int64 at index onto the top of the stack as an int64.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x97),
                    new IlOpcode(
                        new OpcodeValue(0x97),
                        "ldelem.i",
                        "Load the element with type native int at index onto the top of the stack as a native int.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x98),
                    new IlOpcode(
                        new OpcodeValue(0x98),
                        "ldelem.r4",
                        "Load the element with type float32 at index onto the top of the stack as an F",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x99),
                    new IlOpcode(
                        new OpcodeValue(0x99),
                        "ldelem.r8",
                        "Load the element with type float64 at index onto the top of the stack as an F.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x9A),
                    new IlOpcode(
                        new OpcodeValue(0x9A),
                        "ldelem.ref",
                        "Load the element at index onto the top of the stack as an O. The type of the O is the same as the element type of the array pushed on the CIL stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x9B),
                    new IlOpcode(
                        new OpcodeValue(0x9B),
                        "stelem.i",
                        "Replace array element at index with the i value on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x9C),
                    new IlOpcode(
                        new OpcodeValue(0x9C),
                        "stelem.i1",
                        "Replace array element at index with the int8 value on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x9D),
                    new IlOpcode(
                        new OpcodeValue(0x9D),
                        "stelem.i2",
                        "Replace array element at index with the int16 value on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x9E),
                    new IlOpcode(
                        new OpcodeValue(0x9E),
                        "stelem.i4",
                        "Replace array element at index with the int32 value on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0x9F),
                    new IlOpcode(
                        new OpcodeValue(0x9F),
                        "stelem.i8",
                        "Replace array element at index with the int64 value on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0xA0),
                    new IlOpcode(
                        new OpcodeValue(0xA0),
                        "stelem.r4",
                        "Replace array element at index with the float32 value on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0xA1),
                    new IlOpcode(
                        new OpcodeValue(0xA1),
                        "stelem.r8",
                        "Replace array element at index with the float64 value on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0xA2),
                    new IlOpcode(
                        new OpcodeValue(0xA2),
                        "stelem.ref",
                        "Replace array element at index with the ref value on the stack.",
                        IlOpcodeType.ObjectModelInstruction)
                },
                {
                    new OpcodeValue(0xA3),
                    new IlOpcode(
                        new OpcodeValue(0xA3),
                        "ldelem",
                        "Load the element at index onto the top of the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0xA4),
                    new IlOpcode(
                        new OpcodeValue(0xA4),
                        "stelem",
                        "Replace array element at index with the value on the stack",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0xA5),
                    new IlOpcode(
                        new OpcodeValue(0xA5),
                        "unbox.any",
                        "Extract a value-type from obj, its boxed representation",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0xB3),
                    new IlOpcode(
                        new OpcodeValue(0xB3),
                        "conv.ovf.i1",
                        "Convert to an int8 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xB4),
                    new IlOpcode(
                        new OpcodeValue(0xB4),
                        "conv.ovf.u1",
                        "Convert to an unsigned int8 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xB5),
                    new IlOpcode(
                        new OpcodeValue(0xB5),
                        "conv.ovf.i2",
                        "Convert to an int16 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xB6),
                    new IlOpcode(
                        new OpcodeValue(0xB6),
                        "conv.ovf.u2",
                        "Convert to an unsigned int16 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xB7),
                    new IlOpcode(
                        new OpcodeValue(0xB7),
                        "conv.ovf.i4",
                        "Convert to an int32 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xB8),
                    new IlOpcode(
                        new OpcodeValue(0xB8),
                        "conv.ovf.u4",
                        "Convert to an unsigned int32 (on the stack as int32) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xB9),
                    new IlOpcode(
                        new OpcodeValue(0xB9),
                        "conv.ovf.i8",
                        "Convert to an int64 (on the stack as int64) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xBA),
                    new IlOpcode(
                        new OpcodeValue(0xBA),
                        "conv.ovf.u8",
                        "Convert to an unsigned int64 (on the stack as int64) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xC2),
                    new IlOpcode(
                        new OpcodeValue(0xC2),
                        "refanyval",
                        "Push the address stored in a typed reference.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0xC3),
                    new IlOpcode(
                        new OpcodeValue(0xC3),
                        "ckfinite",
                        "Throw ArithmeticException if value is not a finite number.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xC6),
                    new IlOpcode(
                        new OpcodeValue(0xC6),
                        "mkrefany",
                        "Push a typed reference to ptr of type class onto the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0xD0),
                    new IlOpcode(
                        new OpcodeValue(0xD0),
                        "ldtoken",
                        "Convert metadata token to its runtime representation.",
                        IlOpcodeType.ObjectModelInstruction,
                        operandType: IlOperandType.DwordToken)
                },
                {
                    new OpcodeValue(0xD1),
                    new IlOpcode(
                        new OpcodeValue(0xD1),
                        "conv.u2",
                        "Convert to unsigned int16, pushing int32 on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xD2),
                    new IlOpcode(
                        new OpcodeValue(0xD2),
                        "conv.u1",
                        "Convert to unsigned int8, pushing int32 on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xD3),
                    new IlOpcode(
                        new OpcodeValue(0xD3),
                        "conv.i",
                        "Convert to native int, pushing native int on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xD4),
                    new IlOpcode(
                        new OpcodeValue(0xD4),
                        "conv.ovf.i",
                        "Convert to a native int (on the stack as native int) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xD5),
                    new IlOpcode(
                        new OpcodeValue(0xD5),
                        "conv.ovf.u",
                        "Convert to a native unsigned int (on the stack as native int) and throw an exception on overflow.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xD6),
                    new IlOpcode(
                        new OpcodeValue(0xD6),
                        "add.ovf",
                        "Add signed integer values with overflow check.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xD7),
                    new IlOpcode(
                        new OpcodeValue(0xD7),
                        "add.ovf.un",
                        "Add unsigned integer values with overflow check.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xD8),
                    new IlOpcode(
                        new OpcodeValue(0xD8),
                        "mul.ovf",
                        "Multiply signed integer values. Signed result shall fit in same size",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xD9),
                    new IlOpcode(
                        new OpcodeValue(0xD9),
                        "mul.ovf.un",
                        "Multiply unsigned integer values. Unsigned result shall fit in same size",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xDA),
                    new IlOpcode(
                        new OpcodeValue(0xDA),
                        "sub.ovf",
                        "Subtract native int from a native int. Signed result shall fit in same size",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xDB),
                    new IlOpcode(
                        new OpcodeValue(0xDB),
                        "sub.ovf.un",
                        "Subtract native unsigned int from a native unsigned int. Unsigned result shall fit in same size.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xDC),
                    new IlOpcode(
                        new OpcodeValue(0xDC),
                        "endfinally",
                        "End finally clause of an exception block.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xDD),
                    new IlOpcode(
                        new OpcodeValue(0xDD),
                        "leave",
                        "Exit a protected region of code.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.DwordBrTarget)
                },
                {
                    new OpcodeValue(0xDE),
                    new IlOpcode(
                        new OpcodeValue(0xDE),
                        "leave.s",
                        "Exit a protected region of code, short form.",
                        IlOpcodeType.BaseInstruction,
                        operandType: IlOperandType.ByteBrTarget)
                },
                {
                    new OpcodeValue(0xDF),
                    new IlOpcode(
                        new OpcodeValue(0xDF),
                        "stind.i",
                        "Store value of type native int into memory at address",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xE0),
                    new IlOpcode(
                        new OpcodeValue(0xE0),
                        "conv.u",
                        "Convert to native unsigned int, pushing native int on stack.",
                        IlOpcodeType.BaseInstruction)
                },
                {
                    new OpcodeValue(0xFE, 0x00),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x00),
                        "arglist",
                        "Return argument list handle for the current method.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x01),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x01),
                        "ceq",
                        "Push 1 (of type int32) if value1 equals value2, else push 0.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x02),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x02),
                        "cgt",
                        "Push 1 (of type int32) if value1 > value2, else push 0.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x03),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x03),
                        "cgt.un",
                        "Push 1 (of type int32) if value1 > value2, unsigned or unordered, else push 0.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x04),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x04),
                        "clt",
                        "Push 1 (of type int32) if value1 < value2, else push 0.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x05),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x05),
                        "clt.un",
                        "Push 1 (of type int32) if value1 < value2, unsigned or unordered, else push 0.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x06),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x06),
                        "ldftn",
                        "Push a pointer to a method referenced by method, on the stack.",
                        IlOpcodeType.BaseInstruction,
                        2,
                        operandType: IlOperandType.DwordMethod)
                },
                {
                    new OpcodeValue(0xFE, 0x07),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x07),
                        "ldvirtftn",
                        "Push address of virtual method on the stack.",
                        IlOpcodeType.ObjectModelInstruction,
                        2,
                        operandType: IlOperandType.DwordMethod)
                },
                {
                    new OpcodeValue(0xFE, 0x08),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x08),
                        "ldarg",
                        "Load argument numbered num onto the stack.",
                        IlOpcodeType.BaseInstruction,
                        2,
                        operandType: IlOperandType.WordVar)
                },
                {
                    new OpcodeValue(0xFE, 0x0A),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x0A),
                        "ldarga",
                        "Fetch the address of argument argNum.",
                        IlOpcodeType.BaseInstruction,
                        2,
                        operandType: IlOperandType.WordVar)
                },
                {
                    new OpcodeValue(0xFE, 0x0B),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x0B),
                        "starg",
                        "Store value to the argument numbered num.",
                        IlOpcodeType.BaseInstruction,
                        2,
                        operandType: IlOperandType.WordVar)
                },
                {
                    new OpcodeValue(0xFE, 0x0C),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x0C),
                        "ldloc",
                        "Load local variable of index indx onto stack.",
                        IlOpcodeType.BaseInstruction,
                        2,
                        operandType: IlOperandType.WordVar)
                },
                {
                    new OpcodeValue(0xFE, 0x0D),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x0D),
                        "ldloca",
                        "Load address of local variable with index indx.",
                        IlOpcodeType.BaseInstruction,
                        2,
                        operandType: IlOperandType.WordVar)
                },
                {
                    new OpcodeValue(0xFE, 0x0E),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x0E),
                        "stloc",
                        "Pop a value from stack into local variable indx.",
                        IlOpcodeType.BaseInstruction,
                        2,
                        operandType: IlOperandType.WordVar)
                },
                {
                    new OpcodeValue(0xFE, 0x0F),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x0F),
                        "localloc",
                        "Allocate space from the local memory pool.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x11),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x11),
                        "endfilter",
                        "End an exception handling filter clause.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x12),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x12),
                        "unaligned.",
                        "Subsequent pointer instruction might be unaligned.",
                        IlOpcodeType.PrefixToInstruction,
                        2,
                        operandType: IlOperandType.ByteInteger)
                },
                {
                    new OpcodeValue(0xFE, 0x13),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x13),
                        "volatile.",
                        "Subsequent pointer reference is volatile.",
                        IlOpcodeType.PrefixToInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x14),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x14),
                        "tail.",
                        "Subsequent call terminates current method",
                        IlOpcodeType.PrefixToInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x15),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x15),
                        "initobj",
                        "Initialize the value at address dest.",
                        IlOpcodeType.ObjectModelInstruction,
                        2,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0xFE, 0x16),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x16),
                        "constrained.",
                        "Call a virtual method on a type constrained to be type T",
                        IlOpcodeType.PrefixToInstruction,
                        2,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0xFE, 0x17),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x17),
                        "cpblk",
                        "Copy data from memory to memory.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x18),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x18),
                        "initblk",
                        "Set all bytes in a block of memory to a given byte value.",
                        IlOpcodeType.BaseInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x19),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x19),
                        "no.",
                        "The specified fault check(s) normally performed as part of the execution of the subsequent instruction can/shall be skipped.",
                        IlOpcodeType.PrefixToInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x1A),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x1A),
                        "rethrow",
                        "Rethrow the current exception.",
                        IlOpcodeType.ObjectModelInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x1C),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x1C),
                        "sizeof",
                        "Push the size, in bytes, of a type as an unsigned int32.",
                        IlOpcodeType.ObjectModelInstruction,
                        2,
                        operandType: IlOperandType.DwordType)
                },
                {
                    new OpcodeValue(0xFE, 0x1D),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x1D),
                        "refanytype",
                        "Push the type token stored in a typed reference.",
                        IlOpcodeType.ObjectModelInstruction,
                        2)
                },
                {
                    new OpcodeValue(0xFE, 0x1E),
                    new IlOpcode(
                        new OpcodeValue(0xFE, 0x1E),
                        "readonly.",
                        "Specify that the subsequent array address operation performs no type check at runtime, and that it returns a controlled-mutability managed pointer",
                        IlOpcodeType.PrefixToInstruction,
                        2)
                }
            };

        static readonly Lazy<HashSet<byte>> ValidFirstBytes = new Lazy<HashSet<byte>>(
            () => OpcodeTable.Keys
                .Select(k => k.FirstByte)
                .Aggregate(
                    new HashSet<byte>(),
                    (set, b) =>
                    {
                        set.Add(b);
                        return set;
                    }));

        static readonly Lazy<HashSet<byte>> ValidSecondBytes = new Lazy<HashSet<byte>>(
            () => OpcodeTable.Keys
                .Where(k => k.Size == 2)
                .Select(k => k.SecondByte)
                .Aggregate(
                    new HashSet<byte>(),
                    (set, b) =>
                    {
                        set.Add(b);
                        return set;
                    }));
        
        static readonly Lazy<Dictionary<IlOperandType, int>> OperandSize = new Lazy<Dictionary<IlOperandType, int>>(
            () =>
            {
                Type enumType = typeof(IlOperandType);
                Array enumValues = enumType.GetEnumValues();
                var result = new Dictionary<IlOperandType, int>();
                foreach (object enumValue in enumValues)
                {
                    MemberInfo memberInfo = enumType.GetMember(enumValue.ToString()).First();
                    var sizeAttribute = memberInfo.GetCustomAttribute<OperandTypeSizeAttribute>();
                    result.Add((IlOperandType)enumValue, sizeAttribute.Size);
                }

                return result;
            });

        public static bool IsValidFirstByte(byte firstByte)
        {
            return ValidFirstBytes.Value.Contains(firstByte);
        }

        public static IlOpcode GetOpcode(OpcodeValue value)
        {
            return OpcodeTable.TryGetValue(value, out IlOpcode code) ? code : null;
        }

        public static bool IsValidSecondByte(byte secondByte)
        {
            return ValidSecondBytes.Value.Contains(secondByte);
        }

        IlOpcode(
            OpcodeValue raw,
            string name,
            string description,
            IlOpcodeType type,
            int size = 1,
            IlOperandType operandType = IlOperandType.None)
        {
            Size = size;
            Raw = raw;
            Name = name;
            Description = description;
            Type = type;
            OperandType = operandType;
        }

        public int Size { get; }
        public OpcodeValue Raw { get; }
        public string Name { get; }
        public string Description { get; }
        public IlOpcodeType Type { get; }
        public IlOperandType OperandType { get; }

        public int GetOperandSize() { return OperandSize.Value[OperandType]; }
    }
}