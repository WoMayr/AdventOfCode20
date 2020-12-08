using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Handheld_Halting
{
    public enum OperationType
    {
        Jump,
        Accumulator,
        Noop
    }

    public static class OperationTypeHelper
    {
        public static OperationType FromString(string operation) => operation switch
        {
            "acc" => OperationType.Accumulator,
            "jmp" => OperationType.Jump,
            "nop" => OperationType.Noop,
            _ => throw new Exception($"Unknown operation type: \"{operation}\"")
        };
    }
}
