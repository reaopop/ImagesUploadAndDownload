namespace UploadImageProject
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Choose = new System.Windows.Forms.Button();
            this.lbl_size = new System.Windows.Forms.Label();
            this.btn_Download = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_imagefile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(80, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Choose
            // 
            this.btn_Choose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Choose.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Choose.Location = new System.Drawing.Point(238, 65);
            this.btn_Choose.Name = "btn_Choose";
            this.btn_Choose.Size = new System.Drawing.Size(52, 40);
            this.btn_Choose.TabIndex = 2;
            this.btn_Choose.Text = "Choose";
            this.btn_Choose.UseVisualStyleBackColor = false;
            this.btn_Choose.Click += new System.EventHandler(this.btn_Choose_Click);
            // 
            // lbl_size
            // 
            this.lbl_size.AutoSize = true;
            this.lbl_size.Location = new System.Drawing.Point(80, 294);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(0, 13);
            this.lbl_size.TabIndex = 3;
            // 
            // btn_Download
            // 
            this.btn_Download.BackColor = System.Drawing.Color.Transparent;
            this.btn_Download.BackgroundImage = global::UploadImageProject.Properties.Resources.download_ceg4gjilfshf;
            this.btn_Download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Download.Location = new System.Drawing.Point(175, 286);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(57, 53);
            this.btn_Download.TabIndex = 4;
            this.btn_Download.UseVisualStyleBackColor = false;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.BackColor = System.Drawing.Color.Transparent;
            this.btn_upload.BackgroundImage = global::UploadImageProject.Properties.Resources.upload_0rlacujolm2y;
            this.btn_upload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_upload.Location = new System.Drawing.Point(238, 286);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(57, 53);
            this.btn_upload.TabIndex = 5;
            this.btn_upload.UseVisualStyleBackColor = false;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(342, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(562, 311);
            this.dataGridView1.TabIndex = 6;
            // 
            // lbl_imagefile
            // 
            this.lbl_imagefile.AutoSize = true;
            this.lbl_imagefile.Location = new System.Drawing.Point(12, 9);
            this.lbl_imagefile.Name = "lbl_imagefile";
            this.lbl_imagefile.Size = new System.Drawing.Size(35, 13);
            this.lbl_imagefile.TabIndex = 7;
            this.lbl_imagefile.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 355);
            this.Controls.Add(this.lbl_imagefile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.btn_Download);
            this.Controls.Add(this.lbl_size);
            this.Controls.Add(this.btn_Choose);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Choose;
        private System.Windows.Forms.Label lbl_size;
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_imagefile;
    }
}

