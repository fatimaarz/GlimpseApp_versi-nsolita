using System;
using System.Windows.Forms;

namespace GlimpseApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Asegúrate de poner aquí el nombre correcto del formulario que creaste
            Application.Run(new FotosScrollForm());
        }
    }
}

