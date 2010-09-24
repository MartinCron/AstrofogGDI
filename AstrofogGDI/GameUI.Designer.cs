namespace AstrofogGDI
{
    partial class GameUI
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.asteroidCountLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.LivesLabel = new System.Windows.Forms.Label();
            this.hudTimer = new System.Windows.Forms.Timer(this.components);
            this.replacementTimer = new System.Windows.Forms.Timer(this.components);
            this.messageLabel = new System.Windows.Forms.Label();
            this.waveLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 33;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.Color.Silver;
            this.ScoreLabel.Location = new System.Drawing.Point(293, 42);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(68, 17);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "label1";
            this.ScoreLabel.Visible = false;
            // 
            // asteroidCountLabel
            // 
            this.asteroidCountLabel.AutoSize = true;
            this.asteroidCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.asteroidCountLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asteroidCountLabel.ForeColor = System.Drawing.Color.Silver;
            this.asteroidCountLabel.Location = new System.Drawing.Point(296, 87);
            this.asteroidCountLabel.Name = "asteroidCountLabel";
            this.asteroidCountLabel.Size = new System.Drawing.Size(68, 17);
            this.asteroidCountLabel.TabIndex = 1;
            this.asteroidCountLabel.Text = "label2";
            this.asteroidCountLabel.Visible = false;
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.highScoreLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.ForeColor = System.Drawing.Color.Silver;
            this.highScoreLabel.Location = new System.Drawing.Point(299, 140);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(68, 17);
            this.highScoreLabel.TabIndex = 2;
            this.highScoreLabel.Text = "label3";
            this.highScoreLabel.Visible = false;
            // 
            // LivesLabel
            // 
            this.LivesLabel.AutoSize = true;
            this.LivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.LivesLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LivesLabel.ForeColor = System.Drawing.Color.Silver;
            this.LivesLabel.Location = new System.Drawing.Point(296, 157);
            this.LivesLabel.Name = "LivesLabel";
            this.LivesLabel.Size = new System.Drawing.Size(68, 17);
            this.LivesLabel.TabIndex = 3;
            this.LivesLabel.Text = "label1";
            this.LivesLabel.Visible = false;
            // 
            // replacementTimer
            // 
            this.replacementTimer.Enabled = true;
            this.replacementTimer.Interval = 2500;
            this.replacementTimer.Tick += new System.EventHandler(this.replacementTimer_Tick);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.BackColor = System.Drawing.Color.Transparent;
            this.messageLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.Silver;
            this.messageLabel.Location = new System.Drawing.Point(249, 248);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(78, 17);
            this.messageLabel.TabIndex = 4;
            this.messageLabel.Text = "message";
            // 
            // waveLabel
            // 
            this.waveLabel.AutoSize = true;
            this.waveLabel.BackColor = System.Drawing.Color.Transparent;
            this.waveLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveLabel.ForeColor = System.Drawing.Color.Silver;
            this.waveLabel.Location = new System.Drawing.Point(299, 187);
            this.waveLabel.Name = "waveLabel";
            this.waveLabel.Size = new System.Drawing.Size(48, 17);
            this.waveLabel.TabIndex = 5;
            this.waveLabel.Text = "wave";
            this.waveLabel.Visible = false;
            // 
            // GameUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(566, 512);
            this.ControlBox = false;
            this.Controls.Add(this.waveLabel);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.LivesLabel);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.asteroidCountLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Name = "GameUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label asteroidCountLabel;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Label LivesLabel;
        private System.Windows.Forms.Timer hudTimer;
        private System.Windows.Forms.Timer replacementTimer;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label waveLabel;
    }
}

