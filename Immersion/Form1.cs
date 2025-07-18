using Immersion.Classes;

namespace Immersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.DragEnter += flowLayoutPanel1_DragEnter;
            flowLayoutPanel1.DragDrop += flowLayoutPanel1_DragDrop;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AutoScroll = true;
        }

        private void schließenAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // Es können mehrere Dateien gedroppt werden, daher nur die erste nehmen
            if (files.Length > 0 && Path.GetExtension(files[0]).ToLower() == ".xml")
            {
                ImmersionMain.sceneList = XMLHAndling.LoadScenesFromXML(files[0]);
                //var testScene = new Scene("Lublub");
                //var testScene2 = new Scene("Mein Name");
                //var testScene3 = new Scene("Yay!");
                //ImmersionMain.sceneList.Clear();
                //ImmersionMain.sceneList.Add(testScene);
                //ImmersionMain.sceneList.Add(testScene2);
                //ImmersionMain.sceneList.Add(testScene3);
            }

            flowLayoutPanel1.Controls.Clear();

            foreach (Scene scene in ImmersionMain.sceneList)
            {
                Panel scenePanel = scene.CreateScenePanel();
                scenePanel.Width = flowLayoutPanel1.ClientSize.Width - 4;

                flowLayoutPanel1.Controls.Add(scenePanel);
            }
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control child in flowLayoutPanel1.Controls)
            {
                // Annahme: Padding/Abstand ggf. berücksichtigen
                child.Width = flowLayoutPanel1.ClientSize.Width-4;
            }
        }
    }
}
