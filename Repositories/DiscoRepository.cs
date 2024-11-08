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
    public class DiscoRepository : IDiscoRepository
    {
        private readonly string _connectionString;

        public DiscoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Disco>> GetAll()
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Discos";
                return await db.QueryAsync<Disco>(sql);
            }
        }

        public async Task<IEnumerable<Disco>> GetByGenero(string genero)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Discos where Genero like @Genero";
                return await db.QueryAsync<Disco>(sql, new { Genero = '%'+genero+'%' });
            }
        }

        public async Task<IEnumerable<Disco>> GetByArtista(string artista)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Discos WHERE Artista like @Artista";
                return await db.QueryAsync<Disco>(sql, new { Artista = '%'+artista+'%' });
            }
        }

        public async Task<Disco> GetById(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Discos WHERE ID = @id";
                var faixaSql = "SELECT * FROM Faixas Where idDisco = @id";
                var disco = await db.QueryFirstOrDefaultAsync<Disco>(sql, new {id});
                if (disco != null)
                {
                    disco.Faixas = (await db.QueryAsync<Faixa>(faixaSql, new {id})).AsList();
                }

                return disco;
            }
        }

        public async Task<int> Add(Disco disco)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Discos (Titulo, Artista, AnoLancamento, Genero, Gravadora, DuracaoTotal, Formato, Capa, DataAquisicao, AvaliacaoPessoal, Comentario) VALUES (@Titulo, @Artista, @AnoLancamento, @Genero, @Gravadora, @DuracaoTotal, @Formato, @Capa, @DataAquisicao, @AvaliacaoPessoal, @Comentario)";
                return await db.ExecuteAsync(sql, new DynamicParameters(disco));
            }
        }

        public async Task<int> Update(Disco disco)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "UPDATE Discos SET Titulo = @Titulo, Artista = @Artista, AnoLancamento = @AnoLancamento, Genero = @Genero, Gravadora = @Gravadora, DuracaoTotal = @DuracaoTotal, Formato = @Formato, Capa = @Capa, DataAquisicao = @DataAquisicao, AvaliacaoPessoal = @AvaliacaoPessoal, Comentario = @Comentario WHERE Id = @Id";
                return await db.ExecuteAsync(sql, new DynamicParameters(disco));
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Discos WHERE Id = @id";
                return await db.ExecuteAsync(sql, new {id});
            }
        }

    }
}