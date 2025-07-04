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
            this.BackgroundImage = Image.FromFile("fondo .jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.Text = "Galería Glimpse";
            this.Size = new Size(1200, 800); // Tamaño general del formulario
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Imagenes
            PictureBox imgSuperiorIzquierda = new PictureBox();
            imgSuperiorIzquierda.Image = Image.FromFile("Tendencias.jpg"); // Cambia el nombre
            imgSuperiorIzquierda.SizeMode = PictureBoxSizeMode.StretchImage;
            imgSuperiorIzquierda.Size = new Size(185, 30); // Ajusta tamaño como desees
            imgSuperiorIzquierda.Location = new Point(90, 100);
            imgSuperiorIzquierda.BackColor = Color.Transparent;
            this.Controls.Add(imgSuperiorIzquierda);

            PictureBox img2 = new PictureBox();
            img2.Image = Image.FromFile("Inicio.jpg"); 
            img2.SizeMode = PictureBoxSizeMode.StretchImage;
            img2.Size = new Size(20, 20); 
            img2.Location = new Point(37, 280); 
            img2.BackColor = Color.Transparent;
            this.Controls.Add(img2);

            PictureBox img3 = new PictureBox();
            img3.Image = Image.FromFile("Boton2.jpg");
            img3.SizeMode = PictureBoxSizeMode.StretchImage;
            img3.Size = new Size(20, 20);
            img3.Location = new Point(37, 320);
            img3.BackColor = Color.Transparent;
            this.Controls.Add(img3);

            PictureBox img4 = new PictureBox();
            img4.Image = Image.FromFile("Boton3.jpg");
            img4.SizeMode = PictureBoxSizeMode.StretchImage;
            img4.Size = new Size(20, 20);
            img4.Location = new Point(38, 360);
            img4.BackColor = Color.Transparent;
            this.Controls.Add(img4);

            PictureBox img5 = new PictureBox();
            img5.Image = Image.FromFile("Boton4.jpg");
            img5.SizeMode = PictureBoxSizeMode.StretchImage;
            img5.Size = new Size(20, 20);
            img5.Location = new Point(40, 400);
            img5.BackColor = Color.Transparent;
            this.Controls.Add(img5);

            PictureBox img6 = new PictureBox();
            img6.Image = Image.FromFile("Usuarios.jpg");
            img6.SizeMode = PictureBoxSizeMode.StretchImage;
            img6.Size = new Size(42, 150);
            img6.Location = new Point(28, 580);
            img6.BackColor = Color.Transparent;
            this.Controls.Add(img6);

            PictureBox img7 = new PictureBox();
            img7.Image = Image.FromFile("Logo.jpg");
            img7.SizeMode = PictureBoxSizeMode.StretchImage;
            img7.Size = new Size(80, 65);
            img7.Location = new Point(10, 20);
            img7.BackColor = Color.Transparent;
            this.Controls.Add(img7);

            PictureBox img8 = new PictureBox();
            img8.Image = Image.FromFile("Calendario.jpg");
            img8.SizeMode = PictureBoxSizeMode.StretchImage;
            img8.Size = new Size(450, 255);
            img8.Location = new Point(730, 160);
            img8.BackColor = Color.Transparent;
            this.Controls.Add(img8);


            // Panel contenedor (como un marco para el scroll de imágenes)
            Panel contenedor = new Panel()
            {
                Size = new Size(525, 580), // Solo ocupa parte del formulario
                Location = new Point(130, 150), // Posición: puedes ajustarla
                BackColor = Color.White,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // FlowLayoutPanel con scroll vertical dentro del contenedor
            FlowLayoutPanel panelScroll = new FlowLayoutPanel()
            {
                Size = new Size(600, this.Height -100), // Tamaño del panel de scroll
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = this.BackColor,
                BorderStyle = BorderStyle.None,
            };
            this.Controls.Add(panelScroll);

            Panel lineaScroll = new Panel()
            {
                BackColor = Color.FromArgb(216,191,216),// Rosado claro bonito
                Width = 5, // Grosor medio
                Height = panelScroll.Height -300,
                Location = new Point(panelScroll.Right + 80, panelScroll.Top + 250) // 3 cm ≈ 30px a la derecha
            };
            this.Controls.Add(lineaScroll);
            lineaScroll.BringToFront();

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
