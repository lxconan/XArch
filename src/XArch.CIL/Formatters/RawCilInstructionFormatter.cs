using System;
using System.Collections.Generic;
using System.Linq;

namespace XArch.CIL.Formatters
{
    public class RawCilInstructionFormatter
    {
        public IEnumerable<string> Format(IEnumerable<ICilInstruction> instructions)
        {
            if (instructions == null) {throw new ArgumentNullException(nameof(instructions)); }
            return instructions.Select(Format);
        }

        public string Format(ICilInstruction instruction)
        {
            if (instruction == null) { throw new ArgumentNullException(nameof(instruction)); }

            string opcodeName = instruction.OpcodeName.PadRight(12);
            string operandRawValue = string.Join(
                " ",
                instruction.OperandValue.Select(b => b.ToString("x2")));

            return $"IL_{instruction.Offset:x4} {opcodeName}{operandRawValue}";
        } 
    }
}