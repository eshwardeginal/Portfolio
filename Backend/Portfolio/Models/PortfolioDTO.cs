namespace PortfolioAPI.Models
{


    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TechStack { get; set; }
        public string GitHubLink { get; set; }
        public string LiveDemoLink { get; set; }
    }

    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string About { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string Email { get; set; }
    }


    public class Skill
    {
        public int Id { get; set; }
        public string Category { get; set; }  // e.g., Frontend, Backend
        public string Name { get; set; }
        public string IconClass { get; set; }
    }


    public class Experience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }  // Nullable if currently working
    }

    public class Education
    {
        public int Id { get; set; }
        public string Institute { get; set; }
        public string Degree { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }

    public class PortfolioResponse
    {
        public List<UserProfile> UserProfiles { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectDTO> Projects { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Education> Educations { get; set; }
    }


}
