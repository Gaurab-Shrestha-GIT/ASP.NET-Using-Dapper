namespace DapperMVCDemo.Data.DataAccess
{
    public interface ISQLDataAccess
    {
        public Task<IEnumerable<T>> GetData<T, P>(string spName, string parameters, string connectionId = "connection");

        public Task SaveData<T>(string spName, T parameters, string connectionId = "connection");
    }
}