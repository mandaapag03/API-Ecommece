using AdministratorAPI.Model;

namespace AdministratorAPI.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> GetAll();
        Task<Feedback> GetById(int id);
        Task<Feedback> Send(Feedback feedback);
    }
}
