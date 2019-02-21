namespace Starwalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameOverText = new System.Windows.Forms.TextBox();
            this.enemyPicture = new System.Windows.Forms.PictureBox();
            this.Lifebox1 = new System.Windows.Forms.PictureBox();
            this.Lifebox2 = new System.Windows.Forms.PictureBox();
            this.Lifebox3 = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.sheildPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lifebox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lifebox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lifebox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheildPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // gameOverText
            // 
            this.gameOverText.AllowDrop = true;
            this.gameOverText.BackColor = System.Drawing.Color.MediumBlue;
            this.gameOverText.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverText.ForeColor = System.Drawing.SystemColors.Menu;
            this.gameOverText.Location = new System.Drawing.Point(226, 179);
            this.gameOverText.Multiline = true;
            this.gameOverText.Name = "gameOverText";
            this.gameOverText.ReadOnly = true;
            this.gameOverText.Size = new System.Drawing.Size(771, 158);
            this.gameOverText.TabIndex = 1;
            this.gameOverText.Text = "Game Over";
            this.gameOverText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gameOverText.Visible = false;
            this.gameOverText.TextChanged += new System.EventHandler(this.gameOverText_TextChanged);
            // 
            // enemyPicture
            // 
            this.enemyPicture.BackgroundImage = global::Starwalle.Properties.Resources.alienblaster;
            this.enemyPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enemyPicture.Location = new System.Drawing.Point(2000, 2000);
            this.enemyPicture.Name = "enemyPicture";
            this.enemyPicture.Size = new System.Drawing.Size(50, 50);
            this.enemyPicture.TabIndex = 8;
            this.enemyPicture.TabStop = false;
            // 
            // Lifebox1
            // 
            this.Lifebox1.BackColor = System.Drawing.Color.ForestGreen;
            this.Lifebox1.Location = new System.Drawing.Point(1222, 591);
            this.Lifebox1.Name = "Lifebox1";
            this.Lifebox1.Size = new System.Drawing.Size(50, 50);
            this.Lifebox1.TabIndex = 6;
            this.Lifebox1.TabStop = false;
            // 
            // Lifebox2
            // 
            this.Lifebox2.BackColor = System.Drawing.Color.ForestGreen;
            this.Lifebox2.Location = new System.Drawing.Point(1222, 535);
            this.Lifebox2.Name = "Lifebox2";
            this.Lifebox2.Size = new System.Drawing.Size(50, 50);
            this.Lifebox2.TabIndex = 5;
            this.Lifebox2.TabStop = false;
            // 
            // Lifebox3
            // 
            this.Lifebox3.BackColor = System.Drawing.Color.ForestGreen;
            this.Lifebox3.Location = new System.Drawing.Point(1222, 479);
            this.Lifebox3.Name = "Lifebox3";
            this.Lifebox3.Size = new System.Drawing.Size(50, 50);
            this.Lifebox3.TabIndex = 3;
            this.Lifebox3.TabStop = false;
            // 
            // player
            // 
            this.player.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.player.BackColor = System.Drawing.Color.White;
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.ImageLocation = "";
            this.player.InitialImage = null;
            this.player.Location = new System.Drawing.Point(503, 619);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(128, 90);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // sheildPicture
            // 
            this.sheildPicture.BackgroundImage = global::Starwalle.Properties.Resources.circle;
            this.sheildPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.sheildPicture.Image = global::Starwalle.Properties.Resources.circle;
            this.sheildPicture.Location = new System.Drawing.Point(387, 573);
            this.sheildPicture.Name = "sheildPicture";
            this.sheildPicture.Size = new System.Drawing.Size(256, 180);
            this.sheildPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sheildPicture.TabIndex = 2;
            this.sheildPicture.TabStop = false;
            this.sheildPicture.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 749);
            this.Controls.Add(this.enemyPicture);
            this.Controls.Add(this.Lifebox1);
            this.Controls.Add(this.Lifebox2);
            this.Controls.Add(this.Lifebox3);
            this.Controls.Add(this.gameOverText);
            this.Controls.Add(this.player);
            this.Controls.Add(this.sheildPicture);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.enemyPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lifebox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lifebox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lifebox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheildPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        public System.Windows.Forms.TextBox gameOverText;
        private System.Windows.Forms.PictureBox sheildPicture;
        private System.Windows.Forms.PictureBox Lifebox3;
        private System.Windows.Forms.PictureBox Lifebox2;
        private System.Windows.Forms.PictureBox Lifebox1;
        private System.Windows.Forms.PictureBox enemyPicture;
    }
}

