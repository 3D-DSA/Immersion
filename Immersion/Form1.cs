using Immersion.Classes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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

            // bind events from the current scene to the flowLayoutPanels
            ImmersionMain.currentScene = new Scene("Neue Szene", 1, "", new ObservableCollection<Picture>(),
                new ObservableCollection<Video>(), new ObservableCollection<Sound>());

            ImmersionMain.scenes.Add(1, ImmersionMain.currentScene);
            PopulateScenePanel();

            if (ImmersionMain.currentScene != null)
            {
                ImmersionMain.currentScene.PictureList.CollectionChanged += PictureList_CollectionChanged;
                // Initiale Anzeige
                SynchronizePictureFlowLayoutPanel();
            }

        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Bilddateien (*.bmp;*.jpg;*.jpeg;*.png)|" +
                    "*.bmp;*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    List<string> imageList = new List<string>(openFileDialog.FileNames);

                    ImmersionMain.AddImagesToList(imageList);
                }
            }
        }

        private void btnAddScene_Click(object sender, EventArgs e)
        {
            if (ImmersionMain.currentScene != null)
                ImmersionMain.currentScene.PictureList.CollectionChanged -= PictureList_CollectionChanged;

            Scene scene = new Scene("", ImmersionMain.scenes.Count() + 1, "", new ObservableCollection<Picture>(), new ObservableCollection<Video>(), new ObservableCollection<Sound>());
            ImmersionMain.scenes.Add(ImmersionMain.scenes.Count() + 1, scene);
            ImmersionMain.SwapCurrentScene(scene);
            ImmersionMain.currentScene.PictureList.CollectionChanged += PictureList_CollectionChanged;
            PopulateScenePanel();
        }

        private Control? CreatePanelForPicture(object newItem)
        {
            // Beispiel: Panel erstellen, mit Tag setzen etc.
            Picture pic = (Picture)newItem;
            PicturePanel p = new PicturePanel(pic.PathToFile);
            p.Tag = pic.Id;
            return p;
        }

        private Control? FindPanelByTag(object tag, FlowLayoutPanel flp)
        {
            foreach (Control c in flp.Controls)
            {
                if (c.Tag == tag)
                    return c;
            }
            return null;
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
                    PicturePanel picPanel = new PicturePanel(file);
                    flowLayoutPanelImages.Controls.Add(picPanel);
                }
                catch { }
            }
        }
        private void flowLayoutPanelScenes_DragDrop(object sender, DragEventArgs e)
        {
            List<string>? files = e.Data.GetData(DataFormats.FileDrop) as List<string>;
            if (files == null || files.Count() != 1 || Path.GetExtension(files[0]).ToLower() != ".xml")
                return;

            ImmersionMain.scenes = XMLHandling.LoadScenesFromXML(files.First());

            PopulateScenePanel();
        }
        private void flowLayoutPanelImages_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void flowLayoutPanelScenes_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void flowLayoutPanelScreens_Resize(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanelScenes.Controls)
            {
                control.Height = flowLayoutPanelScreens.Height - 4;
            }
        }
        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control child in flowLayoutPanelScenes.Controls)
            {
                child.Width = flowLayoutPanelScenes.ClientSize.Width - 4;
            }
        }

        private void LoadScreens()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenPanel newScreenPanel = new ScreenPanel(screen);
                newScreenPanel.Height = flowLayoutPanelScreens.Height - 4;

                System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
                tt.SetToolTip(newScreenPanel, screen.DeviceName);

                flowLayoutPanelScreens.Controls.Add(newScreenPanel);
            }
        }

        private void ˆffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "XML-Dateien (*.xml)|*.xml";
                dialog.Title = "XML-Datei ausw‰hlen";

                if (dialog.ShowDialog() != DialogResult.OK || !File.Exists(dialog.FileName))
                    return;

                ImmersionMain.scenes.Clear();
                ImmersionMain.scenes = XMLHandling.LoadScenesFromXML(dialog.FileName);
                PopulateScenePanel();
            }
        }

        private void PictureList_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // Reagiere auf Add/Remove etc.
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var newItem in e.NewItems)
                {
                    var p = CreatePanelForPicture(newItem);

                    flowLayoutPanelImages.Controls.Add(p);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var oldItem in e.OldItems)
                {
                    var panel = FindPanelByTag(oldItem, flowLayoutPanelImages);
                    if (panel != null)
                    {
                        flowLayoutPanelImages.Controls.Remove(panel);
                        panel.Dispose();
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                SynchronizePictureFlowLayoutPanel();
            }
        }

        private void PopulateScenePanel()
        {
            if (ImmersionMain.currentScene != null)
            {
                ImmersionMain.currentScene.PictureList.CollectionChanged -= PictureList_CollectionChanged;
                ImmersionMain.currentScene = new Scene("",0,"",null,null,null);
            }
            flowLayoutPanelScenes.Controls.Clear();

            if(ImmersionMain.scenes.Count > 0)
                ImmersionMain.currentScene = ImmersionMain.scenes.First().Value;

            foreach (var scene in ImmersionMain.scenes)
            {
                ScenePanel scenePanel = scene.Value.CreateScenePanel();
                scenePanel.Width = flowLayoutPanelScenes.ClientSize.Width - 10;
                scenePanel.SetActiveMarker(scene.Key == ImmersionMain.currentScene.GetId());
                scenePanel.Selected += ScenePanel_Selected;

                flowLayoutPanelScenes.Controls.Add(scenePanel);
            }

            SynchronizePictureFlowLayoutPanel();
        }

        private void ScenePanel_Selected(object? sender, EventArgs e)
        {
            ScenePanel selectedPanel = sender as ScenePanel;
            if (selectedPanel == null) return;

            // Globale Variable setzen
            if(ImmersionMain.currentScene != null)
                ImmersionMain.currentScene.PictureList.CollectionChanged -= PictureList_CollectionChanged;
            ImmersionMain.currentScene = ImmersionMain.scenes[selectedPanel.GetId()];
            ImmersionMain.currentScene.PictureList.CollectionChanged += PictureList_CollectionChanged;
            SynchronizePictureFlowLayoutPanel();

            // Markierung aktualisieren
            foreach (ScenePanel panel in flowLayoutPanelScenes.Controls.OfType<ScenePanel>())
                panel.SetActiveMarker(ImmersionMain.currentScene.GetId() == panel.GetId()); 
        }

        private void schlieﬂenAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void SynchronizePictureFlowLayoutPanel()
        {
            flowLayoutPanelImages.Controls.Clear();
            foreach (var pic in ImmersionMain.currentScene.PictureList)
            {
                flowLayoutPanelImages.Controls.Add(CreatePanelForPicture(pic));
            }
        }
    }
}
