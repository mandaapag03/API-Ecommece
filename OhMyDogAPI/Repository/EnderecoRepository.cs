using Microsoft.EntityFrameworkCore.Storage;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;

namespace OhMyDogAPI.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        DatabaseContext _context;
        public EnderecoRepository() 
        { 
            _context = new DatabaseContext();
        }

        public Endereco? Create(Endereco endereco)
        {
            var result = _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            if (result == null)
            {
                throw new Exception("Não foi possível cadastrar o usuário");
            }
            return GetEndereco(endereco.Id);
        }

        public Endereco? GetEndereco(int id)
        {
                return _context.Enderecos.FirstOrDefault(e => e.Id == id);
        }

        public Endereco UpdateEndereco(Endereco endereco)
        {
            try
            {
                var enderecoAntigo = _context.Enderecos.FirstOrDefault(e => e.Id == endereco.Id);
                if (enderecoAntigo == null)
                {
                    throw new Exception("Endereço não encontrado");
                }

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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
