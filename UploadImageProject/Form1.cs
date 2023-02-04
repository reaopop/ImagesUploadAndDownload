using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadImageProject.Helper.Service;
using UploadImageProject.Models;
using UploadImageProject.Services;

namespace UploadImageProject
{
    public partial class Form1 : Form
    {
        public string ImageFolderPath = Path.GetDirectoryName(Application.ExecutablePath);
        image Item_Image = new image() { description = "",imagefile = "",subject = ""};
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DoubleClick += DataGridView1_DoubleClick;
            dataGridView1.DataSource = Image_Service.SelectImages().Select(x => new { x.id, x.imagefile, x.subject, x.description }).ToList();
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            var imagefile = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
            var subject = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
            var description = Convert.ToString(dataGridView1.SelectedRows[0].Cells[3].Value);
            Item_Image = new image() { id = id , imagefile = imagefile , subject = subject , description = description};
            lbl_imagefile.Text = imagefile;


        }

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(System.IO.Path.GetFullPath(fd.FileName));
                    long file_size = new FileInfo(System.IO.Path.GetFullPath(fd.FileName)).Length / 1024;
                    string string_size = BytesToFileSizeString(new FileInfo(System.IO.Path.GetFullPath(fd.FileName)).Length);
                    
                    // display image in picture box  
                    pictureBox1.Image = new Bitmap(fd.FileName);
                    Item_Image.imagefile = fd.FileName;
                    // image file path  
                    lbl_size.Text = string_size;
                    lbl_imagefile.Text = fd.FileName;
                }
            }
        }
        public String BytesToFileSizeString(int byteCount)
        {
            return BytesToFileSizeString(((int)byteCount));

        }
        public String BytesToFileSizeString(long byteCount)
        {
            string[] suf = { "بايت", "ك بايت", "ميجا", "جيجا", "تيرا", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Item_Image.logo = Images_Converter.SetImage(pictureBox1.Image);
                //Item_Image.imagefile = (Entity.item_code + "_" + Images_Converter.ImageType.item);
                Item_Image.AddImage();
                dataGridView1.DataSource = Image_Service.SelectImages().Select(x => new { x.id, x.imagefile, x.subject, x.description }).ToList();
                Item_Image = new image() { description = "", imagefile = "", subject = "" };
                pictureBox1.Image = null;
                lbl_imagefile.Text = "";
                lbl_size.Text = "";
                MessageBox.Show("Upload Completed :)");

            }
            else
                MessageBox.Show("Please Select Image To Save .....");
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            Images_Converter.GetImageByID(Item_Image.id, ImageFolderPath, ($"image{Item_Image.id}" + ".jpeg"));
            OpenFolder(($"image{Item_Image.id}" + ".jpeg"));
            MessageBox.Show("Download Completed :)");
        }

        public void OpenFolder( string filename)
        {
            if (Directory.Exists(ImageFolderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    Arguments = ImageFolderPath,
                    FileName = filename,

                };
                Process.Start(ImageFolderPath);
                Process.Start(startInfo);
            }

            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", ImageFolderPath));
            }
        }
    }
}
