using UploadImageProject.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UploadImageProject.Helper.Service;

namespace UploadImageProject.Services
{
    public static class Images_Converter
    {
        public enum ImageType
        {
            item,
            companey,
            other
        }
        public static byte[] SetImage(Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (img == null) { return null; }
                try
                {
                    var i2 = new System.Drawing.Bitmap(img);
                    ImageCodecInfo jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                    img.Save(stream, jpegEncoder, CompressImage(70));
                    return stream.ToArray();
                }
                catch
                {
                    return stream.ToArray();
                }
            }
        }
        public static Image GetImage(byte[] imgArray)
        {
            Image img = null;
            if (imgArray == null) return null;
            using (MemoryStream stream = new MemoryStream(imgArray, false))
            {
                if (imgArray == null) { return null; }
                try
                {
                    img = Image.FromStream(stream);
                    return img;
                }
                catch
                {
                    return img;
                }
            }
        }
        public static bool IfImageExist(string folder_path, string file_name)
        {
            string path = Path.Combine(folder_path, file_name);
            if (File.Exists(path))
            {
                return true;
            }
            else return false;
        }

        public static Image GetImageFromLocalFile(this Image img, string folder_path, string file_name)
        {
            if (IfImageExist(folder_path, file_name))
            {
                string path = Path.Combine(folder_path, file_name);
                img = Image.FromFile(path);
            }
            return img;
        }

        public static void SetImageFromLocalFile(this Image img, string folder_path, string file_name)
        {
            if (!IfImageExist(folder_path, file_name))
            {
                string path = Path.Combine(folder_path, file_name);
                var i2 = new System.Drawing.Bitmap(img);
                ImageCodecInfo jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                i2.Save(path, jpegEncoder, CompressImage(70));
            }
        }


        public static image GetImageByID(int image_id, string folder_path, string file_name)
        {
            try
            {
                image imgclass = new image();
                Image img = null;
                imgclass.img = img.GetImageFromLocalFile(folder_path, file_name);
                if (imgclass.img == null)
                {
                    imgclass = Image_Service.SelectImageByID(image_id);
                    imgclass.img = Images_Converter.GetImage(imgclass.logo);
                    if (imgclass == null) return new image() { description = "", imagefile = "", subject = "", img = null };
                    imgclass.img.SetImageFromLocalFile(folder_path, file_name);

                }
                return imgclass;
            }
            catch (Exception)
            {
                return new image() { description = "", imagefile = "", subject = "", img = null };
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] allCodecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in allCodecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private static EncoderParameters CompressImage(int ImageQuality)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            try
            {
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameter encoderParameter = new EncoderParameter(myEncoder, ImageQuality);
                encoderParameters.Param[0] = encoderParameter;

                return encoderParameters;
            }
            catch (Exception)
            {
                return encoderParameters;
            }
        }
    }
}
