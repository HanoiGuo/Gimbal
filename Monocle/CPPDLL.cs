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


       [DllImport("GimbleDll.dll")]
        public static extern int Entrance_Connect_TCP();

       [DllImport("GimbleDll.dll")]
       public static extern int Entrance_Move(double position, int direction);

       [DllImport("GimbleDll.dll")]
       public static extern int Entrance_Close_TCP();
    }
}
