using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;
using GraphqlSampleApp.Api.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GraphqlSampleApp.Api.Repositories.Implementations
{
    public class PostRepository
        : IPostRepository
    {
        private readonly IMongoCollection<Post> _post;

        public PostRepository(IMongoClient client)
        {
            var database = client.GetDatabase("NFTDB");
            var collection = database.GetCollection<Post>(nameof(Post));
            _post = collection;
        }

        public Post CreatePost(CreatePostInput post)
        {
            var newPost = new Post()
            {
                UserName = post.UserName,
                Comments = GetComments(post.Comments),
                Title = post.Title
            };
            _post.InsertOne(newPost);
            return newPost;
        }

        private static ICollection<Comment> GetComments(ICollection<CreateCommentInput> commentInput)
        {
            List<Comment> lstComments = new List<Comment>();
            foreach (var item in commentInput)
            {
                Comment c = new Comment() { Text = item.Text, Id = ObjectId.GenerateNewId().ToString() };
                lstComments.Add(c);
            }
            return lstComments;
        }
    }
}
