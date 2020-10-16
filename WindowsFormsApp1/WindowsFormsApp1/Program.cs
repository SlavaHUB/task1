using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using WindowsFormsApp1;
using System.Windows;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using WindowsFormsApp1.ProgramView; // Обращение к service

namespace ConsoleApp6
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainView());
        }
    }
}