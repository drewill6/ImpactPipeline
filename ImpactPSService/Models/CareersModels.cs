namespace DataImpact.Models
{
    public class CareersModels
    {
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; } = string.Empty;
        public string? JobStatus { get; set; } 
        public string? JobType { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsInactive { get; set; }

        // Custom methos to check if the job is still active
        public bool IsJobActive()
        {
            //return IsActive && JobStatus != JobStatus.Active;
            return IsActive && PostedDate <= DateTime.Now;
        }
    }
}
