using GraphqlSampleApp.Api.Models.User;
using GraphqlSampleApp.Api.Repositories.Interfaces;
using MongoDB.Driver;

namespace GraphqlSampleApp.Api.Repositories.Implementations
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IMongoCollection<UserRole> _userRole;

        public UserRoleRepository(IMongoClient client)
        {
            var database = client.GetDatabase("NFTDB");
            var collection = database.GetCollection<UserRole>(nameof(UserRole));
            _userRole = collection;
        }

        public IList<UserRole> GetRoleById(Guid id)
        {
            return _userRole.Find(_ => _.UserId == id).ToList();
        }
    }
}
