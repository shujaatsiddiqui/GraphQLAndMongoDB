using GraphqlSampleApp.Api.Models.User;

namespace GraphqlSampleApp.Api.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        IList<UserRole> GetRoleById(Guid id);
    }
}
