namespace GraphqlSampleApp.Api.Models.User
{
    public class UserPayload
    {
        //In the example above, we declared the record properties with the set accessor.
        //That means the object's state can be modified after its creation, making them mutable.
        public record CreateUserPayload(User user);
        public record DeleteUserPayload(bool isSuccessfull);
        public record UpdateUserPayload(bool isSuccessfull);
        public record UserTokenPayload(string Message, string AccessToken, string RefreshToken);
    }
}
