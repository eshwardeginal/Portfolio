using Microsoft.Data.SqlClient;
using Portfolio.Services.Interfaces;
using PortfolioAPI.Models;
using System.Data;

namespace Portfolio.Services.Implementation
{
    public class PortfolioDAO : IPortfolio
    {
        public Task<ProjectDTO> CreateAsync(ProjectDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PortfolioResponse> GetAllAsync(string connstring)
        {
            PortfolioResponse result = new PortfolioResponse()
            {
                UserProfiles = new List<UserProfile>(),
                Skills = new List<Skill>(),
                Projects = new List<ProjectDTO>(),
                Experiences = new List<Experience>(),
                Educations = new List<Education>()
            };

            

            using (SqlConnection conn = new SqlConnection(connstring))
            using (SqlCommand cmd = new SqlCommand("GetAllPortfolioData", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    // UserProfile
                    while (reader.Read())
                    {
                        result.UserProfiles.Add(new UserProfile
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Tagline = reader.GetString(2),
                            About = reader.GetString(3),
                            LinkedIn = reader.GetString(4),
                            GitHub = reader.GetString(5),
                            Email = reader.GetString(6)
                        });
                    }

                    // Skills
                    await reader.NextResultAsync();
                    while (reader.Read())
                    {
                        result.Skills.Add(new Skill
                        {
                            Id = reader.GetInt32(0),
                            Category = reader.GetString(1),
                            Name = reader.GetString(2),
                            IconClass = reader.GetString(3)
                        });
                    }

                    // Projects
                    await reader.NextResultAsync();
                    while (reader.Read())
                    {
                        result.Projects.Add(new ProjectDTO
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            TechStack = reader.GetString(3),
                            GitHubLink = reader.GetString(4),
                            LiveDemoLink = reader.IsDBNull(5) ? null : reader.GetString(5)
                        });
                    }

                    // Experience
                    await reader.NextResultAsync();
                    while (reader.Read())
                    {
                        result.Experiences.Add(new Experience
                        {
                            Id = reader.GetInt32(0),
                            Company = reader.GetString(1),
                            Role = reader.GetString(2),
                            Description = reader.GetString(3),
                            StartDate = reader.GetDateTime(4),
                            EndDate = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)
                        });
                    }

                    // Education
                    await reader.NextResultAsync();
                    while (reader.Read())
                    {
                        result.Educations.Add(new Education
                        {
                            Id = reader.GetInt32(0),
                            Institute = reader.GetString(1),
                            Degree = reader.GetString(2),
                            StartYear = reader.GetInt32(3),
                            EndYear = reader.GetInt32(4)
                        });
                    }
                }
            }

            return result;
        }


        public Task<ProjectDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, ProjectDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
