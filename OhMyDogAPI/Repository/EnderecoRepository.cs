using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DatabaseContext _context;
        public EnderecoRepository() 
        { 
            _context = new DatabaseContext();
        }

        public Endereco? Create(Endereco endereco)
        {
            try
            {
                var user = _context.Usuarios.FirstOrDefault(u => endereco.UsuarioId == u.Id);
                NullOrEmptyVariable<Usuario>.ThrowIfNull(user, "Usuário não encontrado");

                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return GetEndereco(endereco.Id);
        }

        public bool? DeleteEndereco(int idEndereco)
        {
            var endereco = GetEndereco(idEndereco);
            NullOrEmptyVariable<Endereco>.ThrowIfNull(endereco, "Endereço não encontrado");
            
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return true;
        }

        public List<Endereco> GetAllEnderecosOfUser(int idUsuario)
        {
            if(!_context.Usuarios.Where(u => u.Id == idUsuario).Any())
            {
                throw new Exception("Usuário não encontrado");
            }

            return _context.Enderecos
                .AsNoTracking()
                .Where(e => e.UsuarioId == idUsuario)
                .ToList();
        }

        public Endereco? GetEndereco(int id)
        {
            return NullOrEmptyVariable<Endereco>.ThrowIfNull(
                _context.Enderecos.FirstOrDefault(e => e.Id == id), "Endereço não encontrado");
        }
        public Endereco UpdateEndereco(Endereco endereco)
        {
            try
            {
                var enderecoAntigo = _context.Enderecos.FirstOrDefault(e => e.Id == endereco.Id);
                NullOrEmptyVariable<Endereco>.ThrowIfNull(endereco, "Endereço não encontrado");

                enderecoAntigo.Logradouro = endereco.Logradouro;
                enderecoAntigo.Numero = endereco.Numero;
                enderecoAntigo.Bairro = endereco.Bairro;
                enderecoAntigo.Cep = endereco.Cep;
                enderecoAntigo.Complemento = endereco.Complemento;
                enderecoAntigo.Uf = endereco.Uf;
                enderecoAntigo.Cidade = endereco.Cidade;

                _context.Enderecos.Update(enderecoAntigo);
                _context.SaveChanges();

                return enderecoAntigo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
