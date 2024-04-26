namespace DataImpact.Models
{
    public class PersonalInfoModel
    {
        public int Id { get; set; } 

        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; } public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ResumeFilePath { get; set; }   // Store the file path in the database
    }
}
