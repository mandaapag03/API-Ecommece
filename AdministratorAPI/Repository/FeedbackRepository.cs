using AdministratorAPI.Data;
using AdministratorAPI.Interfaces;
using AdministratorAPI.Model;
using Microsoft.EntityFrameworkCore;
using VerifyNullablesObjects;

namespace AdministratorAPI.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DatabaseContext _context;
        public FeedbackRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<Feedback>> GetAll()
        {
            try
            {
                return await _context.Feedbacks.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Feedback> GetById(int id)
        {
            try
            {
                var feedback = await _context.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
                return NullOrEmptyVariable<Feedback>.ThrowIfNull(feedback, "Feedback não encontrado");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Feedback> Send(Feedback feedback)
        {    
            try
            {
                if (feedback.Nota < 0 && feedback.Nota > 5)
                {
                    throw new Exception("A nota tem que ser de 0 a 5");
                }

                await _context.Feedbacks.AddAsync(feedback);
                _context.SaveChanges();
                var id = _context.Feedbacks.Max(x => x.Id);
                return await GetById(id);
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
