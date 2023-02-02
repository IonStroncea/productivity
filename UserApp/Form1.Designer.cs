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
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwodTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.compNameLabel = new System.Windows.Forms.Label();
            this.compNameTextBox = new System.Windows.Forms.TextBox();
            this.newCompCheckBox = new System.Windows.Forms.CheckBox();
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
            this.sendLabel.Visible = false;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(26, 45);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(60, 15);
            this.userNameLabel.TabIndex = 8;
            this.userNameLabel.Text = "Username";
            this.userNameLabel.Click += new System.EventHandler(this.userNameLabel_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(26, 90);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(57, 15);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(26, 63);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.userNameTextBox.TabIndex = 10;
            // 
            // passwodTextBox
            // 
            this.passwodTextBox.Location = new System.Drawing.Point(26, 108);
            this.passwodTextBox.Name = "passwodTextBox";
            this.passwodTextBox.Size = new System.Drawing.Size(100, 23);
            this.passwodTextBox.TabIndex = 11;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(26, 206);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 12;
            this.loginButton.Text = "Log In";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // compNameLabel
            // 
            this.compNameLabel.AutoSize = true;
            this.compNameLabel.Location = new System.Drawing.Point(26, 134);
            this.compNameLabel.Name = "compNameLabel";
            this.compNameLabel.Size = new System.Drawing.Size(96, 15);
            this.compNameLabel.TabIndex = 13;
            this.compNameLabel.Text = "Computer Name";
            // 
            // compNameTextBox
            // 
            this.compNameTextBox.Location = new System.Drawing.Point(26, 152);
            this.compNameTextBox.Name = "compNameTextBox";
            this.compNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.compNameTextBox.TabIndex = 14;
            // 
            // newCompCheckBox
            // 
            this.newCompCheckBox.AutoSize = true;
            this.newCompCheckBox.Location = new System.Drawing.Point(26, 181);
            this.newCompCheckBox.Name = "newCompCheckBox";
            this.newCompCheckBox.Size = new System.Drawing.Size(105, 19);
            this.newCompCheckBox.TabIndex = 15;
            this.newCompCheckBox.Text = "New computer";
            this.newCompCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 268);
            this.Controls.Add(this.newCompCheckBox);
            this.Controls.Add(this.compNameTextBox);
            this.Controls.Add(this.compNameLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwodTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
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
        private Label userNameLabel;
        private Label passwordLabel;
        private TextBox userNameTextBox;
        private TextBox passwodTextBox;
        private Button loginButton;
        private Label compNameLabel;
        private TextBox compNameTextBox;
        private CheckBox newCompCheckBox;
    }
}