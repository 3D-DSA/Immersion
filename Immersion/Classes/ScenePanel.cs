using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immersion.Classes
{
    internal class ScenePanel : Panel
    {
        private int ID;
        private string Name;
        private string bgImagePath;
        private Label Label;
        private TextBox TextBox;
        private Panel MarkerBar;

        public ScenePanel(int id, string name)
        {
            Label = new Label
            {
                Text = String.IsNullOrWhiteSpace(name) ? "Neue Szene" : name,
                Location = new Point(0, 0),
                AutoSize = true,
                Font = new Font(FontFamily.GenericSansSerif, 12.0f, FontStyle.Bold),
            };
            Label.DoubleClick += Label_DoubleClick;

            TextBox = new TextBox
            {
                Text = "",
                Location = Label.Location,
                //Size = new Size( Parent.Width - 10, this.Height), //Label.Size,
                Visible = false
            };
            TextBox.KeyDown += TextBox_KeyDown;
            TextBox.LostFocus += TextBox_LostFocus;

            MarkerBar = new Panel();
            MarkerBar.Size = new Size(6, this.Height);
            MarkerBar.BackColor = Color.LimeGreen;
            MarkerBar.Dock = DockStyle.Right;
            MarkerBar.Visible = false;

            this.Controls.Add(MarkerBar);
            this.Controls.Add(Label);
            this.Controls.Add(TextBox);
            
            this.Click += ScenePanel_Click;

            if (string.IsNullOrEmpty(Label.Text))
                ShowTextBox();

            ID = id;
        }

        private void ScenePanel_Click(object? sender, EventArgs e)
        {
            ImmersionMain.currentScene = ImmersionMain.scenes[ID];  
        }

        private void ShowTextBox()
        {
            TextBox.Text = Label.Text;
            TextBox.Size = new Size(Parent.Width - 10, this.Height);
            Label.Visible = false;
            TextBox.Visible = true;
            TextBox.Focus();
            TextBox.SelectAll();
        }

        private void HideTextBox()
        {
            Label.Text = TextBox.Text;
            TextBox.Visible = false;
            Label.Visible = true;
            ImmersionMain.currentScene.SetName(Label.Text);
            ImmersionMain.scenes[ID] = ImmersionMain.currentScene;
        }

        private void TextBox_LostFocus(object? sender, EventArgs e)
        {
            HideTextBox();
        }

        private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HideTextBox();
                e.Handled = true;
                e.SuppressKeyPress = true; // verhindert Piepton
            };
        }

        private void Label_DoubleClick(object? sender, EventArgs e)
        {
            ShowTextBox();
        }

        internal void SetActiveMarker(bool activeStatus)
        {
            MarkerBar.Visible = activeStatus;
        }
    }
}
