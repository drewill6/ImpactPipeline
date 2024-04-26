using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImpact.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string? RoleName { get; set; } // RoleName can be 'Admin', 'User', etc.
        public string? Description { get; set; } // Description of the role
        public string? Permissions { get; set; } // Store role-specific permissions (if needed)
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; } // Indicates if the role is active
        public bool IsAdminRole { get; set; } // Indicates whether the role has administrative privileges
    }
}
