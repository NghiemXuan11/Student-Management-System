using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Interface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new NhapCauHoi());
            // Application.Run(new DANGKY());
           // Application.Run(new MONHOC());
            Application.Run(new DANGNHAP());
            //Application.Run(new LamBaiTracNghiem());
           // Application.Run(new PHIEUCHAMDIEM());
           // Application.Run(new DNPHIEUCHAMDIEM());
           // Application.Run(new MONTHI());
        }
    }
}
