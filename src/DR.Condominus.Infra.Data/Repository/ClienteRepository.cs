using Dapper;
using DR.Domain.Interfaces;
using DR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Condominus.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> ObterAtivos()
        {
            //return Buscar(c => c.Ativo);
            //Dapper
            var sql = @"SELECT * FROM Clientes c 
                        WHERE c.Excluido = 0 AND cAtivo = 1";
            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override Cliente ObterPorId(Guid id)
        {
            //return Db.Clientes.AsNoTracking().Include("Enderecos").FirstOrDefault(c => c.Id == id) ;
            //Dapper
            var sql = @"SELECT * FROM Clientes c
                        LEFT JOIN Enderecos e ON c.ID = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql, (c,e) => 
            {
                c.AdicionaEndereco(e);
                return c;
            }, new { uid = id}).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();

            base.Atualizar(cliente);
        }
    }
}
