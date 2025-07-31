using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Immersion.Classes
{
    public class PicturePanel : Panel
    {
        private PictureBox pictureBox;
        private Label label;
        private Form pictureForm;
        private string imgPath;

        public PicturePanel(string imagePath)
        {
            if (String.IsNullOrWhiteSpace(imagePath)) 
                imgPath = Path.Combine(Application.StartupPath, "Images", "photo.png");
            else imgPath = imagePath;

            this.Width = 75;
            this.Height = 100;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.Black;


            pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(imgPath);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(Width, Height);
            // Event-Handler an der PictureBox registrieren
            pictureBox.MouseDown += PictureBox_MouseDown;
            this.Controls.Add(pictureBox);

            label = new Label();
            label.Text = Path.GetFileNameWithoutExtension(imgPath);
            label.Dock = DockStyle.Bottom;
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.ForeColor = Color.White;
            label.Font = new Font(label.Font, FontStyle.Bold);
            label.MouseDown += PictureBox_MouseDown;
            this.Controls.Add(label);

            //this.DragEnter += Panel_DragEnter;
            //this.DragDrop += Panel_DragDrop;
            this.MouseDown += Panel_MouseDown;
            this.Click += Panel_Click;

            this.Resize += (s, e) => LayoutControls();
            LayoutControls();
        }

        public string GetImagePath() { return imgPath; }
        private void PictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pb = sender as PictureBox;
                if (pb != null)
                {
                    Panel parentPanel = pb.Parent as Panel; // das PicturePanel
                    if (parentPanel != null)
                    {
                        DoDragDrop(parentPanel, DragDropEffects.Move);
                    }
                }
            }
        }

        private void LayoutControls()
        {
            // Grafik zentrieren
            pictureBox.Location = new Point(
                (this.ClientSize.Width - pictureBox.Width) / 2,
                10);

            // Label zentriert unterhalb
            //label.Location = new Point(
            //    (this.ClientSize.Width - label.Width) / 2,
            //    pictureBox.Bottom + 5);
        }

        //private void Panel_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(typeof(ScreenPanel)))
        //        e.Effect = DragDropEffects.Copy;
        //    else
        //        e.Effect = DragDropEffects.None;
        //}

        //private void Panel_DragDrop(object sender, DragEventArgs e)
        //{
        //    var dragged = e.Data.GetData(typeof(ScreenPanel)) as ScreenPanel;
        //    if (dragged != null)
        //    {
        //        ShowElementOnScreen(dragged.label.Text);
        //    }
        //}

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Copy);
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            pictureForm = new Form();
            pictureForm.WindowState = FormWindowState.Normal;
            pictureForm.StartPosition = FormStartPosition.Manual;

            Rectangle workingArea = Screen.FromControl(this).WorkingArea;
            pictureForm.Location = workingArea.Location;
            pictureForm.Size = new Size(workingArea.Size.Width/2, workingArea.Size.Height/2);

            var picktureBox = new PictureBox();
            pictureBox.BackColor = Color.Black;       // Hintergrund schwarz
            pictureBox.Dock = DockStyle.Fill;          // bildschirmfüllend
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // proportional skalieren
            pictureBox.Image = Image.FromFile("pfad_zum_bild.jpg");

            pictureForm.Show();
        }
    }
}