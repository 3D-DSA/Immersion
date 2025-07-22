using Immersion.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Immersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanelScenes.DragEnter += flowLayoutPanel1_DragEnter;
            flowLayoutPanelScenes.DragDrop += flowLayoutPanel1_DragDrop;
            flowLayoutPanelScenes.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelScenes.AutoScroll = true;
            LoadScreens();
        }

        private void LoadScreens()
        {
            throw new NotImplementedException();
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
            List<string>? files = e.Data.GetData(DataFormats.FileDrop) as List<string>;
            if (files == null || files.Count() != 1 || Path.GetExtension(files[0]).ToLower() != ".xml")
                return;

            ImmersionMain.sceneList = XMLHandling.LoadScenesFromXML(files.First());

            PopulateScenePanel();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control child in flowLayoutPanelScenes.Controls)
            {
                // Annahme: Padding/Abstand ggf. berücksichtigen
                child.Width = flowLayoutPanelScenes.ClientSize.Width - 4;
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "XML-Dateien (*.xml)|*.xml";
                dialog.Title = "Projekt speichern";
                if (dialog.ShowDialog() != DialogResult.OK || !Directory.Exists(Path.GetDirectoryName(dialog.FileName)))
                    return;

                XMLHandling.SaveScenesToXML(dialog.FileName, ImmersionMain.sceneList);
            }
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "XML-Dateien (*.xml)|*.xml";
                dialog.Title = "XML-Datei auswählen";

                if (dialog.ShowDialog() != DialogResult.OK || !File.Exists(dialog.FileName))
                    return;

                ImmersionMain.sceneList.Clear();
                ImmersionMain.sceneList = XMLHandling.LoadScenesFromXML(dialog.FileName);
                PopulateScenePanel();
            }
        }

        private void PopulateScenePanel()
        {
            flowLayoutPanelScenes.Controls.Clear();

            foreach (Scene scene in ImmersionMain.sceneList)
            {
                Panel scenePanel = scene.CreateScenePanel();
                scenePanel.Width = flowLayoutPanelScenes.ClientSize.Width - 4;

                flowLayoutPanelScenes.Controls.Add(scenePanel);
            }
        }

        private void btnAddScene_Click(object sender, EventArgs e)
        {
            Scene scene = new Scene("", ImmersionMain.sceneList.Count() + 1, "", new List<Picture>(), new List<Video>(), new List<Sound>);
            ImmersionMain.sceneList.Add(scene);
            PopulateScenePanel();
        }
    }
}
