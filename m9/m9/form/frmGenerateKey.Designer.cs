
namespace m9
{
    partial class frmGenerateKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerateKey));
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.picKey = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picKey)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnGenerateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateKey.ForeColor = System.Drawing.Color.Lime;
            this.btnGenerateKey.Location = new System.Drawing.Point(71, 200);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(189, 73);
            this.btnGenerateKey.TabIndex = 0;
            this.btnGenerateKey.Text = "Generate Key";
            this.btnGenerateKey.UseVisualStyleBackColor = false;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // picKey
            // 
            this.picKey.BackColor = System.Drawing.Color.ForestGreen;
            this.picKey.Image = ((System.Drawing.Image)(resources.GetObject("picKey.Image")));
            this.picKey.Location = new System.Drawing.Point(81, 31);
            this.picKey.Name = "picKey";
            this.picKey.Size = new System.Drawing.Size(163, 152);
            this.picKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picKey.TabIndex = 1;
            this.picKey.TabStop = false;
            // 
            // frmGenerateKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(324, 375);
            this.Controls.Add(this.picKey);
            this.Controls.Add(this.btnGenerateKey);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerateKey";
            this.Text = "GenerateKey";
            ((System.ComponentModel.ISupportInitialize)(this.picKey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.PictureBox picKey;
    }
}