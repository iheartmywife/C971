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

        public async Task<Term> GetTermByID(int id)
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

        //public async Task<List<Course>> GetCourses()
        //{
        //    return await _connection.Table<Course>().ToListAsync();
        //}

        public async Task<Course> GetCourseByID(int id)
        {
            return await _connection.Table<Course>().Where( x => x.TermID == id).FirstOrDefaultAsync();
        }
        public async Task<List<Course>> GetCoursesWithID(int id)
        {
            return await _connection.Table<Course>().Where(x => x.TermID == id).ToListAsync();
        }
        public int GetCourseCountForTerm(int id)
        {
            if (_connection.Table<Course> != null || GetCoursesWithID(id).Result.Count > 0)
            {
                return GetCoursesWithID(id).Result.Count;
            }
            else
            {
                return 0;
            }
        }

        public async Task CreateCourse(Course course)
        {
            await _connection.InsertAsync(course);
        }

        public async Task UpdateCourse(Course course)
        {
            await _connection.UpdateAsync(course);
        }

        public async Task DeleteCourse(Course course) 
        {
            await _connection.DeleteAsync(course);
        }
    }
}
