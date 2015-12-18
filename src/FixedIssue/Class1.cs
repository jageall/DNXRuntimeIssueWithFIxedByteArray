using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ClassLibrary1;
using Xunit;

namespace FixedIssue
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Class1
    {
        [Fact]
        public void Test()
        {
            unsafe
            {
                var entry = new RuntimeIssue {Data = 0x12345678};
                Assert.Equal(0x34, entry.Bytes[0]);
                Assert.Equal(0x12, entry.Bytes[1]);
                Assert.Equal(0x00, entry.Bytes[2]);
                Assert.Equal(0x00, entry.Bytes[3]);
                
            }
        }

        [Fact]
        public void ThisWorks()
        {
            unsafe
            {
                var entry = new PefectlyFine { Data = 0x12345678 };
                Assert.Equal(0x78, entry.Bytes[0]);
                Assert.Equal(0x56, entry.Bytes[1]);
                Assert.Equal(0x34, entry.Bytes[2]);
                Assert.Equal(0x12, entry.Bytes[3]);

            }
        }


        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct PefectlyFine
        {
            [FieldOffset(0)]
            public fixed byte Bytes[4];
            [FieldOffset(0)]
            public Int32 Data;
        }

        [Fact]
        public void AlsoFine()
        {
            var entry = new RuntimeIssue { Data = 0x12345678 };
            Assert.Equal(0x78, ClassLibrary2.Class1.Foo(entry, 0));
            Assert.Equal(0x56, ClassLibrary2.Class1.Foo(entry, 1));
            Assert.Equal(0x34, ClassLibrary2.Class1.Foo(entry, 2));
            Assert.Equal(0x12, ClassLibrary2.Class1.Foo(entry, 3));
        }


    }
}
