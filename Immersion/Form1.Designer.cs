namespace Immersion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            dateiToolStripMenuItem = new ToolStripMenuItem();
            öffnenToolStripMenuItem = new ToolStripMenuItem();
            speichernToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            schließenAltF4ToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            btnAddScene = new Button();
            flowLayoutPanelScenes = new FlowLayoutPanel();
            splitContainer3 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            groupBox4 = new GroupBox();
            flowLayoutPanelImages = new FlowLayoutPanel();
            btnAddImage = new Button();
            groupBox5 = new GroupBox();
            flowLayoutPanelVideos = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            flowLayoutPanelMusic = new FlowLayoutPanel();
            splitContainer2 = new SplitContainer();
            groupBox1 = new GroupBox();
            flowLayoutPanelScreens = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1679, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { öffnenToolStripMenuItem, speichernToolStripMenuItem, toolStripMenuItem1, schließenAltF4ToolStripMenuItem });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(59, 24);
            dateiToolStripMenuItem.Text = "&Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            öffnenToolStripMenuItem.Size = new Size(213, 26);
            öffnenToolStripMenuItem.Text = "&Öffnen";
            öffnenToolStripMenuItem.Click += öffnenToolStripMenuItem_Click;
            // 
            // speichernToolStripMenuItem
            // 
            speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            speichernToolStripMenuItem.Size = new Size(213, 26);
            speichernToolStripMenuItem.Text = "&Speichern";
            speichernToolStripMenuItem.Click += speichernToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(210, 6);
            // 
            // schließenAltF4ToolStripMenuItem
            // 
            schließenAltF4ToolStripMenuItem.Name = "schließenAltF4ToolStripMenuItem";
            schließenAltF4ToolStripMenuItem.Size = new Size(213, 26);
            schließenAltF4ToolStripMenuItem.Text = "Schließen (Alt+F4)";
            schließenAltF4ToolStripMenuItem.Click += schließenAltF4ToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer3);
            splitContainer1.Size = new Size(1679, 639);
            splitContainer1.SplitterDistance = 378;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAddScene);
            groupBox2.Controls.Add(flowLayoutPanelScenes);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(378, 639);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Szenen";
            // 
            // btnAddScene
            // 
            btnAddScene.Dock = DockStyle.Bottom;
            btnAddScene.Location = new Point(3, 607);
            btnAddScene.Name = "btnAddScene";
            btnAddScene.Size = new Size(372, 29);
            btnAddScene.TabIndex = 1;
            btnAddScene.Text = "+";
            btnAddScene.UseVisualStyleBackColor = true;
            btnAddScene.Click += btnAddScene_Click;
            // 
            // flowLayoutPanelScenes
            // 
            flowLayoutPanelScenes.AllowDrop = true;
            flowLayoutPanelScenes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelScenes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelScenes.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelScenes.Location = new Point(3, 23);
            flowLayoutPanelScenes.Name = "flowLayoutPanelScenes";
            flowLayoutPanelScenes.Size = new Size(372, 578);
            flowLayoutPanelScenes.TabIndex = 0;
            flowLayoutPanelScenes.WrapContents = false;
            flowLayoutPanelScenes.DragDrop += flowLayoutPanelScenes_DragDrop;
            flowLayoutPanelScenes.DragEnter += flowLayoutPanelScenes_DragEnter;
            flowLayoutPanelScenes.Resize += flowLayoutPanel1_Resize;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(groupBox3);
            splitContainer3.Size = new Size(1297, 639);
            splitContainer3.SplitterDistance = 425;
            splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(groupBox4);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(groupBox5);
            splitContainer4.Size = new Size(1297, 425);
            splitContainer4.SplitterDistance = 602;
            splitContainer4.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(flowLayoutPanelImages);
            groupBox4.Controls.Add(btnAddImage);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(0, 0);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(602, 425);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Bilder";
            // 
            // flowLayoutPanelImages
            // 
            flowLayoutPanelImages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelImages.Location = new Point(6, 23);
            flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            flowLayoutPanelImages.Size = new Size(590, 364);
            flowLayoutPanelImages.TabIndex = 2;
            // 
            // btnAddImage
            // 
            btnAddImage.Dock = DockStyle.Bottom;
            btnAddImage.Location = new Point(3, 393);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(596, 29);
            btnAddImage.TabIndex = 1;
            btnAddImage.Text = "+";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(flowLayoutPanelVideos);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(0, 0);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(691, 425);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Videos";
            // 
            // flowLayoutPanelVideos
            // 
            flowLayoutPanelVideos.Dock = DockStyle.Fill;
            flowLayoutPanelVideos.Location = new Point(3, 23);
            flowLayoutPanelVideos.Name = "flowLayoutPanelVideos";
            flowLayoutPanelVideos.Size = new Size(685, 399);
            flowLayoutPanelVideos.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(flowLayoutPanelMusic);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1297, 210);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Musik";
            // 
            // flowLayoutPanelMusic
            // 
            flowLayoutPanelMusic.Dock = DockStyle.Fill;
            flowLayoutPanelMusic.Location = new Point(3, 23);
            flowLayoutPanelMusic.Name = "flowLayoutPanelMusic";
            flowLayoutPanelMusic.Size = new Size(1291, 184);
            flowLayoutPanelMusic.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 28);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox1);
            splitContainer2.Size = new Size(1679, 761);
            splitContainer2.SplitterDistance = 639;
            splitContainer2.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(flowLayoutPanelScreens);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1679, 118);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bildschirme";
            // 
            // flowLayoutPanelScreens
            // 
            flowLayoutPanelScreens.Dock = DockStyle.Fill;
            flowLayoutPanelScreens.Location = new Point(3, 23);
            flowLayoutPanelScreens.Name = "flowLayoutPanelScreens";
            flowLayoutPanelScreens.Size = new Size(1673, 92);
            flowLayoutPanelScreens.TabIndex = 0;
            flowLayoutPanelScreens.Resize += flowLayoutPanelScreens_Resize;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1679, 789);
            Controls.Add(splitContainer2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem öffnenToolStripMenuItem;
        private ToolStripMenuItem speichernToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem schließenAltF4ToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanelScenes;
        private SplitContainer splitContainer2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private SplitContainer splitContainer3;
        private GroupBox groupBox3;
        private FlowLayoutPanel flowLayoutPanelMusic;
        private FlowLayoutPanel flowLayoutPanelScreens;
        private SplitContainer splitContainer4;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private FlowLayoutPanel flowLayoutPanelVideos;
        private Button btnAddScene;
        private Button btnAddImage;
        private FlowLayoutPanel flowLayoutPanelImages;
    }
}
