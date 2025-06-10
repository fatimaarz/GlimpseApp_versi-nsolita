using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GlimpseApp
{
    public class FotosScrollForm : Form
    {
        public FotosScrollForm()
        {
            this.Text = "Galería Glimpse";
            this.Size = new Size(1200, 800); // Tamaño general del formulario
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Panel contenedor (como un marco para el scroll de imágenes)
            Panel contenedor = new Panel()
            {
                Size = new Size(525, 650), // Solo ocupa parte del formulario
                Location = new Point(130, 100), // Posición: puedes ajustarla
                BackColor = Color.White,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // FlowLayoutPanel con scroll vertical dentro del contenedor
            FlowLayoutPanel panelScroll = new FlowLayoutPanel()
            {
                Size = new Size(600, this.Height -40), // Tamaño del panel de scroll
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = this.BackColor,
                BorderStyle = BorderStyle.None,
            };
            this.Controls.Add(panelScroll);

            // Cargar imágenes desde carpeta "imagenes"
            string rutaImagenes = Path.Combine(Application.StartupPath, @"..\..\imagenes");
            rutaImagenes = Path.GetFullPath(rutaImagenes);

            if (Directory.Exists(rutaImagenes))
            {
                string[] archivos = Directory.GetFiles(rutaImagenes, "*.jpg");

                foreach (string archivo in archivos)
                {
                    PictureBox pic = new PictureBox()
                    {
                        Image = Image.FromFile(archivo),
                        Size = new Size(250,270),// ← tamaño uniforme para 2 columnas
                        Margin = new Padding(7),
                        BorderStyle = BorderStyle.None
                    };
                    panelScroll.Controls.Add(pic);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la carpeta 'imagenes'.");
            }

            // Agregar el panel de scroll dentro del contenedor
            contenedor.Controls.Add(panelScroll);
            this.Controls.Add(contenedor);

            // Puedes agregar más elementos al formulario (por ejemplo, íconos, título, botón "+", etc.)
        }
    }
}
