using UploadImageProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UploadImageProject.Helper.DB;

namespace UploadImageProject.Helper.Service
{
    public static class Image_Service
    {
        private static void SetParameterID(int id)
        {
            DBHelper.AddSqlParameter(id, "@image_id", System.Data.SqlDbType.Int);
        }

        private static void AddMessageParameters()
        {
            DBHelper.AddSqlParameter(0, "@Result_ID", System.Data.SqlDbType.Int, System.Data.ParameterDirection.Output);
            DBHelper.AddSqlParameter("", "@Result_Message", System.Data.SqlDbType.NVarChar, System.Data.ParameterDirection.Output);
        }

        private static void SetParameters(image img)
        {
            DBHelper.AddSqlParameter(img.logo.ToArray(), "@logo", System.Data.SqlDbType.Image, System.Data.ParameterDirection.Input, false);
            DBHelper.AddSqlParameter(img.imagefile, "@imagefile", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Input, false);
            DBHelper.AddSqlParameter(img.subject, "@subject", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Input, false);
            DBHelper.AddSqlParameter(img.description, "@description", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Input, false);
        }

        // Add New Image To image Table using stored procedure
        public static void AddImage(this image img)
        {
            DBHelper.sqlParameters = new List<System.Data.SqlClient.SqlParameter>();
            SetParameterID(img.id);
            SetParameters(img);
            if (img.id == 0)
            {
                DBHelper.sqlParameters.FirstOrDefault(x => x.ParameterName == "@image_id").Direction = System.Data.ParameterDirection.Output;
                DBHelper.ExecuteSP<image>(Stored_Procedures.Images.Images_Insert);
            }
            else
            {
                DBHelper.ExecuteSP<image>(Stored_Procedures.Images.Images_Update);
            }
            img.id = Convert.ToInt32(DBHelper.sqlParameters.FirstOrDefault(x => x.ParameterName == "@image_id")?.Value ?? 0);
        }

        // delete image from image table using stored procedure
        public static bool DeleteImage(int id)
        {
            DBHelper.sqlParameters = new List<System.Data.SqlClient.SqlParameter>();
            SetParameterID(id);
            DBHelper.ExecuteSP<image>(Stored_Procedures.Images.Images_Delete);
            return true;

        }

        // select record from image table by id using stored procedure
        public static image SelectImageByID(int Image_id)
        {
            DBHelper.sqlParameters = new List<System.Data.SqlClient.SqlParameter>();
            AddMessageParameters();
            SetParameterID(Image_id);
            return DBHelper.ExecuteSP<image>(Stored_Procedures.Images.Images_SelectByID).FirstOrDefault();
        } 

        // select all records from image table but not select image column .... just info
        public static List<image> SelectImages()
        {
            DBHelper.sqlParameters = new List<System.Data.SqlClient.SqlParameter>();
            return DBHelper.ExecuteSP<image>(Stored_Procedures.Images.Images_SelectAll);
            
        }
    }
}
