using GraphqlSampleApp.Api.Models.User;
using static GraphqlSampleApp.Api.Models.User.UserPayload;

namespace GraphqlSampleApp.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IExecutable<User> GetUser();
        User GetUserById(Guid id);
        User CreateUser(CreateUserInput createUserInput);
        bool DeleteUser(Guid id);
        bool UpdateUser(Guid id, UpdateUserInput updateUserInput);
        UserTokenPayload Login(LoginInput loginInput);
        UserTokenPayload RenewAccessToken(RenewTokenInput renewTokenInput);
    }
}
