namespace NoarJobAPI.Models
{
    public class JobSearchRequest
    {
        private int parentCategory;
        private List<int> jobCategories;
        private List<int> jobTypes;
        private int city;
        private string? text;
        private int userID;

        public int ParentCategory { get => parentCategory; set => parentCategory = value; }
        public List<int> JobCategories { get => jobCategories; set => jobCategories = value; }
        public List<int> JobTypes { get => jobTypes; set => jobTypes = value; }
        public int City { get => city; set => city = value; }
        public string? Text { get => text; set => text = value; }
        public int UserID { get => userID; set => userID = value; }
    }
}
