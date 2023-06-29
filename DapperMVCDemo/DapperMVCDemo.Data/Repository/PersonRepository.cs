using DapperMVCDemo.Data.DataAccess;
using DapperMVCDemo.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperMVCDemo.Data.Repository
{

    public class PersonRepository : IPersonRepository
    {
        private readonly ISQLDataAccess _sqlDataAccess;
        public PersonRepository(ISQLDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess; 
        }



        public async Task<bool> AddPerson(Person person)
        {
            try
            {
                await _sqlDataAccess.SaveData("sp_create_person", new { person.Name, person.Email, person.Address });
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            try
            {
                await _sqlDataAccess.SaveData("sp_create_person", new { person.Name, person.Email, person.Address });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }   
        
        public async Task<bool> DeletePerson(int id)
        {
            try
            {
                await _sqlDataAccess.SaveData("sp_create_person", new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Person?> GetPersonById(int id)
        {
            IEnumerable<Person> result = await _sqlDataAccess.GetData<Person, dynamic>
                   ("sp_get_all_person", new { Id = id });
            return result.FirstOrDefault();
        }  
        
        public async Task<IEnumerable<Person>> GetAllData()
        { 
            string query = "sp_get_all_person";
            return await _sqlDataAccess.GetData<Person, dynamic>(query, new { });
        }

    }
}
