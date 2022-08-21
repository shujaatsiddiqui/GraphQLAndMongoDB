using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;
using GraphqlSampleApp.Api.Repositories.Interfaces;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Subscriptions;
using static GraphqlSampleApp.Api.Models.User.UserPayload;
namespace GraphqlSampleApp.Api.Types
{
    public class Mutation
    {
        //[Authorize]
        public async Task<CreateUserPayload> CreateUser([Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender, CreateUserInput createUserInput)
        {
            try
            {
                var item = userRepository.CreateUser(createUserInput);
                await eventSender.SendAsync(nameof(Subscription.SubscribeUser), item);

                return new CreateUserPayload(item);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CreatePostPayload> CreatePost([Service] IPostRepository postRepository, CreatePostInput createPostInput)
        {
            var item = await Task.Run(() => postRepository.CreatePost(createPostInput));
            return new CreatePostPayload(item);
        }
        public DeleteUserPayload DeleteUser([Service] IUserRepository userRepository, [ID] Guid id)
        {
            var item = userRepository.DeleteUser(id);
            return new DeleteUserPayload(item);
        }
        public UpdateUserPayload UpdateUser([Service] IUserRepository userRepository, [ID] Guid id, UpdateUserInput updateUserInput)
        {
            var item = userRepository.UpdateUser(id, updateUserInput);
            return new UpdateUserPayload(item);
        }

        public UserTokenPayload Login([Service] IUserRepository userRepository, LoginInput loginInput)
        {
            UserTokenPayload p = userRepository.Login(loginInput);
            return p;
        }
        public UserTokenPayload RenewAccessToken([Service] IUserRepository userRepository, RenewTokenInput renewTokenInput)
        {
            return userRepository.RenewAccessToken(renewTokenInput);
        }
    }
}
