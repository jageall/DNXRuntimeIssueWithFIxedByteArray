using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ClassLibrary2
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Class1
    {
        public static byte Foo(RuntimeIssue issue, int index)
        {
            unsafe
            {
                return issue.Bytes[index];
            }
        }
    }
}
