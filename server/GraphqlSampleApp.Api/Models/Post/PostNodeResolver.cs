using MongoDB.Driver;

namespace GraphqlSampleApp.Api.Models.User
{
    public class PostNodeResolver
    {
        public Task<Post.Post> ResolveAsync([Service] IMongoCollection<Post.Post> collection, string id)
        {
            return collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }

    public class CommentNodeResolver
    {
        public Task<Post.Comment> ResolveAsync([Service] IMongoCollection<Post.Comment> collection, string id)
        {
            return collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
