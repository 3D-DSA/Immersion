using Immersion.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Immersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanelScenes.DragEnter += flowLayoutPanelScenes_DragEnter;
            flowLayoutPanelScenes.DragDrop += flowLayoutPanelScenes_DragDrop;
            flowLayoutPanelScenes.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelScenes.AutoScroll = true;
            LoadScreens();

            flowLayoutPanelImages.DragEnter += flowLayoutPanelImages_DragEnter;
            flowLayoutPanelImages.DragDrop += flowLayoutPanelImages_DragDrop;

        }

        private void flowLayoutPanelImages_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void flowLayoutPanelImages_DragDrop(object? sender, DragEventArgs e)
        {
            List<string> validImageTypes = new List<string> { "png", "jpg", "bmp" };
            List<string>? files = e.Data.GetData(DataFormats.FileDrop) as List<string>;
            foreach (var file in files)
            {
                if (!File.Exists(file)) continue;
                try
                {
                    if (!validImageTypes.Any(v => v.Contains(Path.GetExtension(file))))
                        continue;
                    PicturenPanel picPanel = new PicturenPanel(file);
                    flowLayoutPanelImages.Controls.Add(picPanel);
                }
                catch { }
            }
        }

        private void LoadScreens()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenPanel newScreenPanel = new ScreenPanel(screen);
                newScreenPanel.Height = flowLayoutPanelScreens.Height - 4;
                flowLayoutPanelScreens.Controls.Add(newScreenPanel);

            }
        }

        private void schließenAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanelScenes_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void flowLayoutPanelScenes_DragDrop(object sender, DragEventArgs e)
        {
            List<string>? files = e.Data.GetData(DataFormats.FileDrop) as List<string>;
            if (files == null || files.Count() != 1 || Path.GetExtension(files[0]).ToLower() != ".xml")
                return;

            ImmersionMain.scenes = XMLHandling.LoadScenesFromXML(files.First());

            PopulateScenePanel();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control child in flowLayoutPanelScenes.Controls)
            {
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

                XMLHandling.SaveScenesToXML(dialog.FileName, ImmersionMain.scenes);
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

                ImmersionMain.scenes.Clear();
                ImmersionMain.scenes = XMLHandling.LoadScenesFromXML(dialog.FileName);
                PopulateScenePanel();
            }
        }

        private void PopulateScenePanel()
        {
            flowLayoutPanelScenes.Controls.Clear();

            foreach (var scene in ImmersionMain.scenes)
            {
                ScenePanel scenePanel = scene.Value.CreateScenePanel();
                scenePanel.Width = flowLayoutPanelScenes.ClientSize.Width - 10;

                flowLayoutPanelScenes.Controls.Add(scenePanel);
            }
        }

        private void btnAddScene_Click(object sender, EventArgs e)
        {
            Scene scene = new Scene("", ImmersionMain.scenes.Count() + 1, "", new List<Picture>(), new List<Video>(), new List<Sound>());
            ImmersionMain.scenes.Add(ImmersionMain.scenes.Count() + 1, scene);
            ImmersionMain.SwapCurrentScene(scene);
            PopulateScenePanel();
        }

        private void flowLayoutPanelScreens_Resize(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanelScenes.Controls)
            {
                control.Height = flowLayoutPanelScreens.Height - 4;
            }
        }
    }
}
