
namespace DataImpact.Models
{
    public enum EmploymentType
    {
        FullTime,
        PartTime,
        Contract,
    }

    public enum ExperienceLevel
    {
        EntryLevel,
        MidLevel,
        SeniorLevel,
        // Add more levels if necessary
    }

    public enum JobCategory
    {
        IT,
        Marketing,
        Sales,
        Finance,
        Healthcare,
        // Add more job categories as needed
    }

    public enum ApplicationStatus
    {
        Pending,
        Reviewed,
        Rejected,
        Hired,
        // Add more status updates as needed
    }

    public enum EducationLevel
    {
        HighSchool,
        Associate,
        Bachelor,
        Masters,
        Doctorate,
        // Add more education level as needed
    }

    public enum EmploymentStatus
    {
        Employed,
        Unemployed,
        Freelance,
        Contractor,
        // Add more to employment status as needed
    }

    public enum SalaryType
    {
        Annual,
        Monthly,
        Hourly,
        // Add more salary types as needed
    }
    public class JobOpportunity
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public JobCategory Category { get; set; } = JobCategory.IT;
        public string Location { get; set; } = string.Empty;
        //public EmploymentType EmploymentType { get; set; } = EmploymentType.FullTime;
        public ExperienceLevel ExperienceLevel { get; set; } = ExperienceLevel.EntryLevel;
        public string Salary { get; set; } = string.Empty;
        public SalaryType SalaryTpe { get; set; } = SalaryType.Annual;
        public DateTime ApplicationDeadline { get; set; } = DateTime.MinValue;
        public string ApplicationLink { get; set; } = string.Empty;
        public string Responsibilities { get; set; } = string.Empty;
        public string? Qualifications { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public string EqualOpportunityEmployer { get; set; } = string.Empty;
        public string CompanyInfo { get; set; } = string.Empty;
        public DateTime PostedDate { get; set ; } = DateTime.MinValue;
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

        // Custom method to calculate job age in days
        public int GetJobAgeInDays()
        {
            return (DateTime.Now - PostedDate).Days;
        }

        public EmploymentType EmploymentType { get; set; } = EmploymentType.FullTime; // Default value

    }
}
