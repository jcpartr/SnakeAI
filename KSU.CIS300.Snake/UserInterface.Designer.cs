namespace KSU.CIS300.Snake
{
    partial class uxInterface
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
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxToolStrip_Easy = new System.Windows.Forms.ToolStripMenuItem();
            this.uxToolStrip_Normal = new System.Windows.Forms.ToolStripMenuItem();
            this.uxToolStrip_Hard = new System.Windows.Forms.ToolStripMenuItem();
            this.uxCheckBox_AIPlayer = new System.Windows.Forms.CheckBox();
            this.uxNum_AISpeed = new System.Windows.Forms.NumericUpDown();
            this.uxLabel_AISpeed = new System.Windows.Forms.Label();
            this.uxLabel_ScoreText = new System.Windows.Forms.Label();
            this.uxLabel_Score = new System.Windows.Forms.Label();
            this.uxPictureBox_Game = new System.Windows.Forms.PictureBox();
            this.uxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNum_AISpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox_Game)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Size = new System.Drawing.Size(623, 24);
            this.uxMenuStrip.TabIndex = 0;
            this.uxMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxToolStrip_Easy,
            this.uxToolStrip_Normal,
            this.uxToolStrip_Hard});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // uxToolStrip_Easy
            // 
            this.uxToolStrip_Easy.Name = "uxToolStrip_Easy";
            this.uxToolStrip_Easy.Size = new System.Drawing.Size(114, 22);
            this.uxToolStrip_Easy.Text = "Easy";
            this.uxToolStrip_Easy.Click += new System.EventHandler(this.uxToolStrip_Easy_Click);
            // 
            // uxToolStrip_Normal
            // 
            this.uxToolStrip_Normal.Name = "uxToolStrip_Normal";
            this.uxToolStrip_Normal.Size = new System.Drawing.Size(114, 22);
            this.uxToolStrip_Normal.Text = "Normal";
            this.uxToolStrip_Normal.Click += new System.EventHandler(this.uxToolStrip_Normal_Click);
            // 
            // uxToolStrip_Hard
            // 
            this.uxToolStrip_Hard.Name = "uxToolStrip_Hard";
            this.uxToolStrip_Hard.Size = new System.Drawing.Size(114, 22);
            this.uxToolStrip_Hard.Text = "Hard";
            this.uxToolStrip_Hard.Click += new System.EventHandler(this.uxToolStrip_Hard_Click);
            // 
            // uxCheckBox_AIPlayer
            // 
            this.uxCheckBox_AIPlayer.AutoSize = true;
            this.uxCheckBox_AIPlayer.BackColor = System.Drawing.Color.LightGray;
            this.uxCheckBox_AIPlayer.Location = new System.Drawing.Point(53, 4);
            this.uxCheckBox_AIPlayer.Name = "uxCheckBox_AIPlayer";
            this.uxCheckBox_AIPlayer.Size = new System.Drawing.Size(68, 17);
            this.uxCheckBox_AIPlayer.TabIndex = 1;
            this.uxCheckBox_AIPlayer.Text = "AI Player";
            this.uxCheckBox_AIPlayer.UseVisualStyleBackColor = false;
            // 
            // uxNum_AISpeed
            // 
            this.uxNum_AISpeed.Location = new System.Drawing.Point(199, 5);
            this.uxNum_AISpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.uxNum_AISpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNum_AISpeed.Name = "uxNum_AISpeed";
            this.uxNum_AISpeed.Size = new System.Drawing.Size(51, 20);
            this.uxNum_AISpeed.TabIndex = 2;
            this.uxNum_AISpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // uxLabel_AISpeed
            // 
            this.uxLabel_AISpeed.AutoSize = true;
            this.uxLabel_AISpeed.Location = new System.Drawing.Point(142, 7);
            this.uxLabel_AISpeed.Name = "uxLabel_AISpeed";
            this.uxLabel_AISpeed.Size = new System.Drawing.Size(51, 13);
            this.uxLabel_AISpeed.TabIndex = 3;
            this.uxLabel_AISpeed.Text = "AI Speed";
            // 
            // uxLabel_ScoreText
            // 
            this.uxLabel_ScoreText.AutoSize = true;
            this.uxLabel_ScoreText.Location = new System.Drawing.Point(522, 11);
            this.uxLabel_ScoreText.Name = "uxLabel_ScoreText";
            this.uxLabel_ScoreText.Size = new System.Drawing.Size(38, 13);
            this.uxLabel_ScoreText.TabIndex = 4;
            this.uxLabel_ScoreText.Text = "Score:";
            // 
            // uxLabel_Score
            // 
            this.uxLabel_Score.AutoSize = true;
            this.uxLabel_Score.Location = new System.Drawing.Point(566, 12);
            this.uxLabel_Score.Name = "uxLabel_Score";
            this.uxLabel_Score.Size = new System.Drawing.Size(13, 13);
            this.uxLabel_Score.TabIndex = 5;
            this.uxLabel_Score.Text = "0";
            // 
            // uxPictureBox_Game
            // 
            this.uxPictureBox_Game.BackColor = System.Drawing.Color.SkyBlue;
            this.uxPictureBox_Game.Location = new System.Drawing.Point(12, 45);
            this.uxPictureBox_Game.Margin = new System.Windows.Forms.Padding(25);
            this.uxPictureBox_Game.Name = "uxPictureBox_Game";
            this.uxPictureBox_Game.Size = new System.Drawing.Size(600, 600);
            this.uxPictureBox_Game.TabIndex = 6;
            this.uxPictureBox_Game.TabStop = false;
            this.uxPictureBox_Game.Paint += new System.Windows.Forms.PaintEventHandler(this.uxPictureBox_Game_Paint);
            this.uxPictureBox_Game.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.uxInterface_PreviewKeyDown);
            // 
            // uxInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(623, 660);
            this.Controls.Add(this.uxPictureBox_Game);
            this.Controls.Add(this.uxLabel_Score);
            this.Controls.Add(this.uxLabel_ScoreText);
            this.Controls.Add(this.uxLabel_AISpeed);
            this.Controls.Add(this.uxNum_AISpeed);
            this.Controls.Add(this.uxCheckBox_AIPlayer);
            this.Controls.Add(this.uxMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.uxMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "uxInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classic Snake";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.uxInterface_PreviewKeyDown);
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNum_AISpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox_Game)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxToolStrip_Easy;
        private System.Windows.Forms.ToolStripMenuItem uxToolStrip_Normal;
        private System.Windows.Forms.ToolStripMenuItem uxToolStrip_Hard;
        private System.Windows.Forms.CheckBox uxCheckBox_AIPlayer;
        private System.Windows.Forms.NumericUpDown uxNum_AISpeed;
        private System.Windows.Forms.Label uxLabel_AISpeed;
        private System.Windows.Forms.Label uxLabel_ScoreText;
        private System.Windows.Forms.Label uxLabel_Score;
        private System.Windows.Forms.PictureBox uxPictureBox_Game;
    }
}

