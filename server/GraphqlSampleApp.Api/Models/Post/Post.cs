using GraphqlSampleApp.Api.Models.User;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphqlSampleApp.Api.Models.Post
{
   // [Node(
   //IdField = nameof(Id),
   //NodeResolverType = typeof(PostNodeResolver),
   //NodeResolver = nameof(PostNodeResolver.ResolveAsync))]
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; } = "";
        public string UserName { get; set; } 

        public ICollection<Comment> Comments { get; set; }

    }

    public record CreatePostInput(string Title, string UserName, ICollection<CreateCommentInput> Comments);

    public record CreatePostPayload(Post post);
}
