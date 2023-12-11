using Dapper;
using Microsoft.Data.SqlClient;
using net9demo.Models;
using System.Data;

namespace net9demo.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeople();
    }

    public class PersonRepository(IConfiguration config) : IPersonRepository
    {
        private string constr = config.GetConnectionString("default");
        public async Task<IEnumerable<Person>> GetPeople()
        {
            using IDbConnection connection = new SqlConnection(constr);
            string query = "select * from Person";
            var people = await connection.QueryAsync<Person>(query);
            //var people = new List<Person>()
            //{
            //    new Person{Name="ravindra",Age=31,Email="ravindra@gmail.com"},
            //    new Person{Name="sattu",Age=34,Email="sattu@gmail.com"},
            //};
            return people;
        } 
    }
}
