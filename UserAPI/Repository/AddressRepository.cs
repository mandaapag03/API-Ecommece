using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Model;
using UserAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace UserAPI.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DatabaseContext _context;
        public AddressRepository() 
        { 
            _context = new DatabaseContext();
        }

        public Address? Create(Address address)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => address.UsuarioId == u.Id);
                NullOrEmptyVariable<User>.ThrowIfNull(user, "Usuário não encontrado");

                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Get(address.Id);
        }

        public bool? Delete(int id)
        {
            var address = Get(id);
            NullOrEmptyVariable<Address>.ThrowIfNull(address, "Endereço não encontrado");
            
            _context.Addresses.Remove(address);
            _context.SaveChanges();

            return true;
        }

        public List<Address> GetAll(int UserId)
        {
            if(!_context.Users.Where(u => u.Id == UserId).Any())
            {
                throw new Exception("Usuário não encontrado");
            }

            return _context.Addresses
                .AsNoTracking()
                .Where(e => e.UsuarioId == UserId)
                .ToList();
        }

        public Address? Get(int id)
        {
            return NullOrEmptyVariable<Address>.ThrowIfNull(
                _context.Addresses.FirstOrDefault(e => e.Id == id), "Endereço não encontrado");
        }
        public Address Update(Address address)
        {
            try
            {
                var oldAddress = _context.Addresses.FirstOrDefault(e => e.Id == address.Id);
                NullOrEmptyVariable<Address>.ThrowIfNull(address, "Endereço não encontrado");

                oldAddress.Logradouro = address.Logradouro;
                oldAddress.Numero = address.Numero;
                oldAddress.Bairro = address.Bairro;
                oldAddress.Cep = address.Cep;
                oldAddress.Complemento = address.Complemento;
                oldAddress.Uf = address.Uf;
                oldAddress.Cidade = address.Cidade;

                _context.Addresses.Update(oldAddress);
                _context.SaveChanges();

                return oldAddress;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
