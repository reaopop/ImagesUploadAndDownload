
namespace UploadImageProject.Helper.DB
{
    public static class Scheams
    {
        public static string Default { get => "dbo."; }
    }
    public static class Stored_Procedures
    {
        public static class Images
        {
            // Images Stored Procedures
            public static string Images_Insert { get => (Scheams.Default + "Images_Ins"); }
            public static string Images_Update { get => (Scheams.Default + "Images_Up"); }
            public static string Images_Delete { get => (Scheams.Default + "Images_Del"); }
            public static string Images_SelectAll { get => (Scheams.Default + "Images_SelAll"); }
            public static string Images_SelectByID { get => (Scheams.Default + "Images_SelByID"); }
            // ///////////////////////////////////

        }
    }
}
