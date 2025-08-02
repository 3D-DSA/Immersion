
using System.Windows.Forms;

namespace Immersion.Classes
{
    public class ScreenPanel : Panel
    {
        private Screen screen;
        private PictureBox pictureBox;
        private Label label;
        private Form pictureForm;

        public ScreenPanel(Screen screen)
        {
            this.screen = screen;
            this.Width = 100;
            this.Height = 75;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.AllowDrop = true;

            pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "monitor.png"));
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(Width, Height);
            pictureBox.AllowDrop = true;
            pictureBox.DragEnter += Panel_DragEnter;
            pictureBox.DragDrop += Panel_DragDrop;
            pictureBox.Click += Panel_Click;
            this.Controls.Add(pictureBox);

            label = new Label();
            label.Text = screen.DeviceName;
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AllowDrop = true;
            label.DragEnter += Panel_DragEnter;
            label.DragDrop += Panel_DragDrop;
            label.Click += Panel_Click;
            this.Controls.Add(label);

            this.DragEnter += Panel_DragEnter;
            this.DragDrop += Panel_DragDrop;
            this.Click += Panel_Click;

            this.Resize += (s, e) => LayoutControls();
            LayoutControls();
        }

        private void LayoutControls()
        {
            // Grafik zentrieren
            pictureBox.Location = new Point(
                (this.ClientSize.Width - pictureBox.Width) / 2,
                10);

            // Label zentriert unterhalb
            label.Location = new Point(
                (this.ClientSize.Width - label.Width) / 2,
                pictureBox.Bottom + 5);
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            if (pictureForm != null && !pictureForm.IsDisposed)
            {
                pictureForm.Close();
                pictureForm  = null;
            }
            pictureBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "monitor.png"));
        }
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            var dragged = e.Data.GetData(typeof(PicturePanel)) as PicturePanel;
            if (dragged != null)
            {
                ShowElementOnScreen(dragged.GetImagePath());
            }
        }
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PicturePanel)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        public void ShowElementOnScreen(string text)
        {
            if (pictureForm != null && !pictureForm.IsDisposed) return;

            pictureForm = new Form();
            pictureForm.StartPosition = FormStartPosition.Manual;

            PictureBox imgToShow = new PictureBox();
            imgToShow.Image = Image.FromFile(text);
            imgToShow.SizeMode = PictureBoxSizeMode.Zoom;
            imgToShow.Dock = DockStyle.Fill;
            pictureForm.Controls.Add(imgToShow);

            // Position und Größe auf den Arbeitsbereich des gewählten Monitors setzen
            Rectangle workingArea = screen.WorkingArea;
            pictureForm.Location = workingArea.Location;
            pictureForm.Size = workingArea.Size;
            pictureForm.BackColor = Color.Black;

            pictureForm.FormBorderStyle = FormBorderStyle.None;
            pictureForm.ControlBox = false;
            pictureForm.WindowState = FormWindowState.Maximized;

            pictureForm.Show();
            pictureBox.Image = Image.FromFile(text);
        }

    }
}