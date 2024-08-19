using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA
{
    public class DBService
    {
        private const string DB_NAME = "KJCPA_db";
        private readonly SQLiteAsyncConnection _connection;
        public DBService() 
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Term>();
            _connection.CreateTableAsync<Course>();
        }

        public async Task<List<Term>> GetTerms()
        {
            return await _connection.Table<Term>().ToListAsync();
        }

        public async Task<Term> GetByID(int id)
        {
            return await _connection.Table<Term>().Where( x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task Create(Term term)
        {
            await _connection.InsertAsync(term);
        }

        public async Task Update(Term term)
        {
            await _connection.UpdateAsync(term);
        }

        public async Task Delete(Term term)
        {
            await _connection.DeleteAsync(term);
        }

        // to do: implement Course Table Operations
    }
}
