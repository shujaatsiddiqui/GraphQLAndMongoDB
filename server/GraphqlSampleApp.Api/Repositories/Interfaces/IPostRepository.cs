using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;

namespace GraphqlSampleApp.Api.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Post CreatePost(CreatePostInput post);
    }
}
