namespace Pacman
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PacmanBox = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PacHeaderBox = new System.Windows.Forms.GroupBox();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GameStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PacHeaderBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PacmanBox
            // 
            this.PacmanBox.Location = new System.Drawing.Point(18, 18);
            this.PacmanBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PacmanBox.Name = "PacmanBox";
            this.PacmanBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PacmanBox.Size = new System.Drawing.Size(880, 496);
            this.PacmanBox.TabIndex = 0;
            this.PacmanBox.TabStop = false;
            this.PacmanBox.Text = "Pacman";
            // 
            // PacHeaderBox
            // 
            this.PacHeaderBox.Controls.Add(this.HelpLabel);
            this.PacHeaderBox.Controls.Add(this.ScoreLabel);
            this.PacHeaderBox.Controls.Add(this.label1);
            this.PacHeaderBox.Controls.Add(this.GameStart);
            this.PacHeaderBox.Location = new System.Drawing.Point(18, 522);
            this.PacHeaderBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PacHeaderBox.Name = "PacHeaderBox";
            this.PacHeaderBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PacHeaderBox.Size = new System.Drawing.Size(880, 97);
            this.PacHeaderBox.TabIndex = 1;
            this.PacHeaderBox.TabStop = false;
            // 
            // HelpLabel
            // 
            this.HelpLabel.AutoSize = true;
            this.HelpLabel.Location = new System.Drawing.Point(178, 45);
            this.HelpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(691, 20);
            this.HelpLabel.TabIndex = 4;
            this.HelpLabel.Text = "Note: KeyUp= Move Up , Key Down = Move Down , Key Right = Move Right , Key Left =" +
    " Move Left";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(32, 48);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(18, 20);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Score";
            // 
            // GameStart
            // 
            this.GameStart.Location = new System.Drawing.Point(708, 27);
            this.GameStart.Name = "GameStart";
            this.GameStart.Size = new System.Drawing.Size(165, 56);
            this.GameStart.TabIndex = 5;
            this.GameStart.Text = "Start Game";
            this.GameStart.UseVisualStyleBackColor = true;
            this.GameStart.Click += new System.EventHandler(this.GameStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 629);
            this.Controls.Add(this.PacHeaderBox);
            this.Controls.Add(this.PacmanBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Pacman Game";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PacHeaderBox.ResumeLayout(false);
            this.PacHeaderBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PacmanBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox PacHeaderBox;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GameStart;
        private System.Windows.Forms.Label HelpLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

