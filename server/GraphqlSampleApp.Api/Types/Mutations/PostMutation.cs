using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;
using GraphqlSampleApp.Api.Repositories.Interfaces;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Subscriptions;
using static GraphqlSampleApp.Api.Models.User.UserPayload;
namespace GraphqlSampleApp.Api.Types.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class PostMutation
    {
        public async Task<CreatePostPayload> CreatePost([Service] IPostRepository postRepository, CreatePostInput createPostInput)
        {
            var item = await Task.Run(() => postRepository.CreatePost(createPostInput));
            return new CreatePostPayload(item);
        }

        public async Task<bool> DeletePost([Service] IPostRepository postRepository, string id)
        {
            var item = await postRepository.DeletePost(id);
            return item;
        }

        //public async Task<Post> UpdatePost([Service] IPostRepository postRepository, string id, Post post)
        //{
        //    //if (id != post.Id)
        //    //    throw new Exception("Invalid request");
        //    //var item = await postRepository.ReplacePost(id, post);
        //    //return item;
        //}
    }
}
