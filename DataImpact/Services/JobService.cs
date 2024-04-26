using DataImpact.Interfaces;
using Microsoft.EntityFrameworkCore;
using DataImpact.Models;
using DataImpact.Services;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImpact.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _dbContext; 

        public JobService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<JobOpportunity>> GetJobOpportunitiesAsync()
        {
            //Implement logic to retrieve job opportunities from the database
            // Example using Entity Frameworkj
            var jobs = await _dbContext.JobOpportunities.ToListAsync();

            // Return the jjob opportunities directly without additional mapping
            return jobs;
        }
        public async Task<List<JobOpportunity?>> GetAllJobsAsync()
        {
            // Implement the logic to save the jobs data to the database
            // Example using Entity FrameworkCore:
            var jobs = await _dbContext.JobOpportunities.ToListAsync();
            return jobs;
            //Map job entities to JobOpportunity models and return the list of job opportunities return jobs.Select(job => MapJobEntityToJobOpportunity(JobOpportunity)).ToList();
        }
        public async Task<JobOpportunity> GetJobByIdAsync(int jobId)
        {
            var jobOpportunity = await _dbContext.JobOpportunities.FindAsync(jobId);

            if (jobOpportunity != null)
            {
                var responsibilitiesList = jobOpportunity?.Responsibilities.Split(',').ToList();
                var qualificationsList = jobOpportunity?.Qualifications?.Split(',').ToList();
                var benefitsList = jobOpportunity?.Benefits.Split(",").ToList();
            }
            return jobOpportunity;
            //May use Map job entities later return job != null ? MapJobEntityToJobOpportunity(JobOpportunity) : null;
        }

        public async Task<int> CreateJobAsync(JobOpportunity jobOpportunity, List<string> responsibilitiesList, List<string> qualificationsList, List<string> benefitsList)
        {
            jobOpportunity.Responsibilities = string.Join(",", responsibilitiesList);
            jobOpportunity.Qualifications = string.Join(",", qualificationsList);
            jobOpportunity.Benefits = string.Join(",", benefitsList);

            _dbContext.JobOpportunities.Add(jobOpportunity);
            await _dbContext.SaveChangesAsync();

            return jobOpportunity.Id; // Assuming Id is the primary key property of my job Entity
        }

        public async Task<bool> UpdateJobAsync(int jobId, JobOpportunity updatedJob)
        {
            var existingJob = await _dbContext.JobOpportunities.FirstOrDefaultAsync(j => j.Id == jobId);
            if (existingJob != null) 
            {
                //Update properties of the existingJob entity with values from updatedJob
                existingJob.JobTitle = updatedJob.JobTitle;
                existingJob.JobDescription = updatedJob.JobDescription;
                // Update other properties similarly...

                await _dbContext.SaveChangesAsync();
                return true; // Indicates successful update
            }
            return false; // Indicates job with given ID was not found
        }

        public async Task<bool> DeleteJobAsync(int jobId)
        {
            try
            {
                // Implement the logic to delete the job with the specified jobId from the database.
                var jobToDelete = await _dbContext.JobOpportunities.FindAsync(jobId);
                if (jobToDelete != null)
                {
                    _dbContext.JobOpportunities.Remove(jobToDelete);
                    await _dbContext.SaveChangesAsync();
                    return true; // Job successfully deleted
                }
                return false; // job not found
                              // Handle exceptions and return appropriate results based on the delete operation.
            }
            catch (Exception)
            {
                // Handle exceptions here (log the error, etc.)
                return false; // Delete operation failed
            }
        }

    }
}

//// Helper method to map Job entity to JobOpportunity model
//private JobOpportunity MapJobEntityToJobOpportunity(JobOpportunity job)
//{
//    return new JobOpportunity
//    {
//        Id = job.Id,
//        JobTitle = job.JobTitle,
//        JobDescription = job.JobDescription,
//        JobCategory = job.JobCategory,
//        Location = job.Location,
//        EmploymentType = job.EmploymentType,
//    };
//}