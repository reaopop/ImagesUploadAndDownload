namespace UploadImageProject.Models
{

    public partial class image
    {
        public int id { get; set; }

        public byte[] logo { get; set; }

        public string imagefile { get; set; }

        public string subject { get; set; }

        public string description { get; set; }

        public System.Drawing.Image img { get; set; }
    }
}
