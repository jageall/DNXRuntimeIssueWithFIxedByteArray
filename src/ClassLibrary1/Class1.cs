using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct RuntimeIssue 
    {
        [FieldOffset(0)]
        public fixed byte Bytes[4];
        [FieldOffset(0)]
        public Int32 Data;
     }
}
