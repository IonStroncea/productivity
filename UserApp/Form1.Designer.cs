namespace UserApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.Resume = new System.Windows.Forms.ToolStripMenuItem();
            this.Pause = new System.Windows.Forms.ToolStripMenuItem();
            this.Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.gpuLabel = new System.Windows.Forms.Label();
            this.ramLabel = new System.Windows.Forms.Label();
            this.cpuUssageLabel = new System.Windows.Forms.Label();
            this.gpuUssageLabel = new System.Windows.Forms.Label();
            this.ramUssageLabel = new System.Windows.Forms.Label();
            this.sendLabel = new System.Windows.Forms.Label();
            this.iconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.iconMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // iconMenu
            // 
            this.iconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenWindow,
            this.Resume,
            this.Pause,
            this.Stop});
            this.iconMenu.Name = "iconMenu";
            this.iconMenu.Size = new System.Drawing.Size(148, 92);
            this.iconMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.iconMenu_ItemClicked);
            // 
            // OpenWindow
            // 
            this.OpenWindow.Name = "OpenWindow";
            this.OpenWindow.Size = new System.Drawing.Size(147, 22);
            this.OpenWindow.Text = "OpenWindow";
            // 
            // Resume
            // 
            this.Resume.Name = "Resume";
            this.Resume.Size = new System.Drawing.Size(147, 22);
            this.Resume.Text = "Resume";
            // 
            // Pause
            // 
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(147, 22);
            this.Pause.Text = "Pause";
            // 
            // Stop
            // 
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(147, 22);
            this.Stop.Text = "Stop";
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Location = new System.Drawing.Point(168, 58);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(30, 15);
            this.cpuLabel.TabIndex = 1;
            this.cpuLabel.Text = "CPU";
            // 
            // gpuLabel
            // 
            this.gpuLabel.AutoSize = true;
            this.gpuLabel.Location = new System.Drawing.Point(168, 90);
            this.gpuLabel.Name = "gpuLabel";
            this.gpuLabel.Size = new System.Drawing.Size(30, 15);
            this.gpuLabel.TabIndex = 2;
            this.gpuLabel.Text = "GPU";
            // 
            // ramLabel
            // 
            this.ramLabel.AutoSize = true;
            this.ramLabel.Location = new System.Drawing.Point(168, 126);
            this.ramLabel.Name = "ramLabel";
            this.ramLabel.Size = new System.Drawing.Size(33, 15);
            this.ramLabel.TabIndex = 3;
            this.ramLabel.Text = "RAM";
            // 
            // cpuUssageLabel
            // 
            this.cpuUssageLabel.AutoSize = true;
            this.cpuUssageLabel.Location = new System.Drawing.Point(204, 58);
            this.cpuUssageLabel.Name = "cpuUssageLabel";
            this.cpuUssageLabel.Size = new System.Drawing.Size(13, 15);
            this.cpuUssageLabel.TabIndex = 4;
            this.cpuUssageLabel.Text = "0";
            // 
            // gpuUssageLabel
            // 
            this.gpuUssageLabel.AutoSize = true;
            this.gpuUssageLabel.Location = new System.Drawing.Point(204, 90);
            this.gpuUssageLabel.Name = "gpuUssageLabel";
            this.gpuUssageLabel.Size = new System.Drawing.Size(13, 15);
            this.gpuUssageLabel.TabIndex = 5;
            this.gpuUssageLabel.Text = "0";
            // 
            // ramUssageLabel
            // 
            this.ramUssageLabel.AutoSize = true;
            this.ramUssageLabel.Location = new System.Drawing.Point(204, 126);
            this.ramUssageLabel.Name = "ramUssageLabel";
            this.ramUssageLabel.Size = new System.Drawing.Size(13, 15);
            this.ramUssageLabel.TabIndex = 6;
            this.ramUssageLabel.Text = "0";
            // 
            // sendLabel
            // 
            this.sendLabel.AutoSize = true;
            this.sendLabel.Location = new System.Drawing.Point(168, 171);
            this.sendLabel.Name = "sendLabel";
            this.sendLabel.Size = new System.Drawing.Size(38, 15);
            this.sendLabel.TabIndex = 7;
            this.sendLabel.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 268);
            this.Controls.Add(this.sendLabel);
            this.Controls.Add(this.ramUssageLabel);
            this.Controls.Add(this.gpuUssageLabel);
            this.Controls.Add(this.cpuUssageLabel);
            this.Controls.Add(this.ramLabel);
            this.Controls.Add(this.gpuLabel);
            this.Controls.Add(this.cpuLabel);
            this.Name = "MainForm";
            this.Text = "PerformanceAnalyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.iconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip iconMenu;
        private ToolStripMenuItem Stop;
        private ToolStripMenuItem Pause;
        private ToolStripMenuItem Resume;
        private ToolStripMenuItem OpenWindow;
        private Label cpuLabel;
        private Label gpuLabel;
        private Label ramLabel;
        private Label cpuUssageLabel;
        private Label gpuUssageLabel;
        private Label ramUssageLabel;
        private Label sendLabel;
    }
}