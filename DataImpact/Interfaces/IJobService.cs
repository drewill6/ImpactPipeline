using DataImpact.Interfaces;
using Microsoft.EntityFrameworkCore;
using DataImpact.Models;
using DataImpact.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImpact.Interfaces
{
    public interface IJobService
    {
        Task<List<JobOpportunity?>> GetAllJobsAsync();
        Task<JobOpportunity> GetJobByIdAsync(int jobId);
        Task<List<JobOpportunity>> GetJobOpportunitiesAsync();
        Task<int> CreateJobAsync(JobOpportunity jobOpportunity, List<string> responsibilitiesList, List<string> qualificationsList, List<string> benefitsList);
        Task<bool> UpdateJobAsync(int jobId, JobOpportunity updatedJob);
        Task<bool> DeleteJobAsync(int jobId);
    }
}
