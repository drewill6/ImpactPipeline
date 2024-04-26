namespace DataImpact.Models
{
    public class SolutionsModels
    {
        public int Id { get; set; }
        public string? SolutionName { get; set; }
        public string? Description { get; set; }

        // Custom methode to validage solution details
        public bool IsValidSolution()
        {
            return !string.IsNullOrEmpty(SolutionName) && !string.IsNullOrEmpty(Description);
        }
    }
}
