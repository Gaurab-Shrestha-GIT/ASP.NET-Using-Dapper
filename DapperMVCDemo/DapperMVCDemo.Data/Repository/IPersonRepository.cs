using DapperMVCDemo.Data.Models.Domain;

namespace DapperMVCDemo.Data.Repository
{
    public interface IPersonRepository
    {
        public Task<bool> AddPerson(Person person);
        public  Task<bool> UpdatePerson(Person person);
        public Task<bool> DeletePerson(int id);
        public Task<Person?> GetPersonById(int id);
        public Task<IEnumerable<Person>> GetAllData();
    }
}