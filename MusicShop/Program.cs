using System;
using System.Windows.Forms;

namespace MusicShop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormSplash());
        }
    }
}