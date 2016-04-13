using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;//DllImport
namespace Monocle
{
    class CPPDLL
    {
        [DllImport("GimbleDll.dll")]
        public static extern void ShowDlg();


       //[DllImport("GimbleDll.dll")]
       //public static extern void testFun(ref string str);


    }
}
