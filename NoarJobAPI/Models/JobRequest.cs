namespace NoarJobAPI.Models
{
    public class JobRequest
    {
        private int jobID;
        private bool isActive;
        private string title;
        private string description;
        private string requirements;
        private int employerID;
        private string phone;
        private string email;
        private List<int> jobCategories;
        private List<int> cities;
        private List<int> jobTypes;

        public int JobID { get => jobID; set => jobID = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Requirements { get => requirements; set => requirements = value; }
        public int EmployerID { get => employerID; set => employerID = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public List<int> JobCategories { get => jobCategories; set => jobCategories = value; }
        public List<int> Cities { get => cities; set => cities = value; }
        public List<int> JobTypes { get => jobTypes; set => jobTypes = value; }
    }
}
