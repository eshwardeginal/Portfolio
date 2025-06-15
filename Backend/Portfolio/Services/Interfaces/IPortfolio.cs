using PortfolioAPI.Models;

namespace Portfolio.Services.Interfaces
{
    public interface IPortfolio
    {
        Task<PortfolioResponse> GetAllAsync(string connstring);
        Task<ProjectDTO?> GetByIdAsync(int id);
        Task<ProjectDTO> CreateAsync(ProjectDTO dto);
        Task<bool> UpdateAsync(int id, ProjectDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
