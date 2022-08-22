using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphqlSampleApp.Api.Models.Post
{

   // [Node(
   //NodeResolverType = typeof(CommentNodeResolver),
   //NodeResolver = nameof(CommentNodeResolver.ResolveAsync))]
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public record CreateCommentInput(string Text);
}
