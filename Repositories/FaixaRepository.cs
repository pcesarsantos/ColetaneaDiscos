using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ColetaneaDiscos.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ColetaneaDiscos.Repositories
{
    public class FaixaRepository : IFaixaRepository
    {
        private readonly string _connectionString;

        public FaixaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Faixa>> GetByDisco(int IdDisco)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Faixas Where IdDisco = @IdDisco";
                return await db.QueryAsync<Faixa>(sql, new { IdDisco = IdDisco });
            }
        }

        public async Task<int> Add(Faixa faixa)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Faixas (NomeDaFaixa, TempoDeDuracao, IdDisco) VALUES (@NomeDaFaixa, @TempoDeDuracao, @IdDisco)";
                return await db.ExecuteAsync(sql, new { faixa.NomeDaFaixa, faixa.TempoDeDuracao, faixa.IdDisco });
            }
        }

        public async Task<int> Update(Faixa faixa)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "UPDATE Faixas SET NomeDaFaixa = @NomeDaFaixa, TempoDeDuracao = @TempoDeDuracao, IdDisco = @IdDisco WHERE Id = @Id";
                return await db.ExecuteAsync(sql, new {faixa.NomeDaFaixa, faixa.TempoDeDuracao, faixa.IdDisco, faixa.Id });
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Faixas WHER Id = @Id";
                return await db.ExecuteAsync(sql, new {Id = id});
            }
        }


    }
}