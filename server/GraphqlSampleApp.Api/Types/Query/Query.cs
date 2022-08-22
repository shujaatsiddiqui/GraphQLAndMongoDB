using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;
using GraphqlSampleApp.Api.Repositories.Interfaces;
using HotChocolate.Data;

namespace GraphqlSampleApp.Api.Types.Query
{
    public class Query
    {
        public async Task<Post> GetPost([Service] IPostRepository postRepository, string id)
        {
            var item = await postRepository.GetPost(id);
            return item;
        }
        public async Task<List<Post>> GetPostsByUsername([Service] IPostRepository postRepository, string userName)
        {
            var item = await postRepository.GetPostsByUsername(userName);
            return item;
        }

        //[UsePaging(IncludeTotalCount = true)]
        //[UseProjection]
        //[UseSorting]
        //[UseFiltering]
        //[Authorize(Roles= new[] {"admin","super-admin"})]
        //[Authorize(Policy="roles-policy")]
        //[Authorize(Policy="claim-policy-1")]
        //[Authorize(Policy = "claim-policy-2")]
        //[Authorize]
        public IExecutable<User> GetUsers([Service] IUserRepository userRepository) => userRepository.GetUser();

        [UseFirstOrDefault]
        public IExecutable<User> GetUserById([Service] IUserRepository userRepository, [ID] Guid id) => userRepository.GetUserById(id);
    }
}
