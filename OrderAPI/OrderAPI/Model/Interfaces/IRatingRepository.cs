using Microsoft.AspNetCore.Routing.Constraints;
using OrderAPI.Controllers;

namespace OrderAPI.Model.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAllByProduct(int produtoId);
        Task<List<Rating>> GetAllByUser(int userId);
        Task<Rating> Get(int id);
        Task<Rating> Add(Rating rating);
        Task<Rating> Delete(int id);
    }
}
