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

        public async Task<Post> CreatePost(CreatePostInput post)
        {
            Post newPost = GetPostFromPostInput(post);
            _post.InsertOne(newPost);
            return newPost;
        }

        private static Post GetPostFromPostInput(CreatePostInput post)
        {
            return new Post()
            {
                UserName = post.UserName,
                Comments = GetComments(post.Comments),
                Title = post.Title
            };
        }

        public async Task<Post> GetPost(string id)
        {
            var data = await _post.FindAsync(x => x.Id == id);
            return data.FirstOrDefault();
        }

        public async Task<List<Post>> GetPostsByUsername(string userName)
        {
            var data = await _post.FindAsync(x => x.UserName == userName);
            return data.ToList();
        }

        public async Task<bool> DeletePost(string id)
        {
            var data = await _post.DeleteOneAsync(x => x.Id == id);
            return data.IsAcknowledged;
        }

        public async Task<long> ReplacePost(string id, CreatePostInput post)
        {
            var postObj = GetPostFromPostInput(post);
            postObj.Id = id;
            var filter = Builders<Post>.Filter.Eq(c => c.Id, id);            
            var result = await _post.ReplaceOneAsync(filter,postObj);
            return result.ModifiedCount;
        }

        private static ICollection<Comment> GetComments(ICollection<CreateCommentInput> commentInput)
        {
            List<Comment> lstComments = new List<Comment>();
            foreach (var item in commentInput)
            {
                Comment c = new Comment()
                {
                    Text = item.Text,
                    Id = ObjectId.GenerateNewId().ToString()
                };
                lstComments.Add(c);
            }
            return lstComments;
        }
    }
}
