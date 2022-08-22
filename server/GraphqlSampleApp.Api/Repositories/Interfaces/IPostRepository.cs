using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;

namespace GraphqlSampleApp.Api.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> CreatePost(CreatePostInput post);
        Task<Post> GetPost(string id);
        Task<List<Post>> GetPostsByUsername(string userName);
        Task<bool> DeletePost(string id);
        Task<long> ReplacePost(string id, CreatePostInput post);
    }
}
