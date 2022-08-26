using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;
using GraphqlSampleApp.Api.Repositories.Interfaces;
using HotChocolate.Subscriptions;
using static GraphqlSampleApp.Api.Models.User.UserPayload;

namespace GraphqlSampleApp.Api.Types.Mutations
{
    public class Mutation
    {
        //public async Task<CreatePostPayload> CreatePost([Service] IPostRepository postRepository, CreatePostInput createPostInput)
        //{
        //    var item = await Task.Run(() => postRepository.CreatePost(createPostInput));
        //    return new CreatePostPayload(item);
        //}

        //public async Task<bool> DeletePost([Service] IPostRepository postRepository, string id)
        //{
        //    var item = await postRepository.DeletePost(id);
        //    return item;
        //}

        //public async Task<long> UpdatePost([Service] IPostRepository postRepository, string id, CreatePostInput post)
        //{
        //    var item = await postRepository.ReplacePost(id, post);
        //    return item;
        //}

        ////[Authorize]
        //public async Task<CreateUserPayload> CreateUser([Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender, CreateUserInput createUserInput)
        //{
        //    try
        //    {
        //        var item = userRepository.CreateUser(createUserInput);
        //        await eventSender.SendAsync(nameof(Subscription.SubscribeUser), item);

        //        return new CreateUserPayload(item);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public DeleteUserPayload DeleteUser([Service] IUserRepository userRepository, [ID] Guid id)
        //{
        //    var item = userRepository.DeleteUser(id);
        //    return new DeleteUserPayload(item);
        //}
        //public UpdateUserPayload UpdateUser([Service] IUserRepository userRepository, [ID] Guid id, UpdateUserInput updateUserInput)
        //{
        //    var item = userRepository.UpdateUser(id, updateUserInput);
        //    return new UpdateUserPayload(item);
        //}

        //public UserTokenPayload Login([Service] IUserRepository userRepository, LoginInput loginInput)
        //{
        //    UserTokenPayload p = userRepository.Login(loginInput);
        //    return p;
        //}
        //public UserTokenPayload RenewAccessToken([Service] IUserRepository userRepository, RenewTokenInput renewTokenInput)
        //{
        //    return userRepository.RenewAccessToken(renewTokenInput);
        //}
    }
}
