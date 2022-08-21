using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;
using static GraphqlSampleApp.Api.Models.User.UserPayload;

namespace GraphqlSampleApp.Api.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Comment CreateComment(Comment comment);
    }
}
