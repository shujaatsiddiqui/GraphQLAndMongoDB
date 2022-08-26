using GraphqlSampleApp.Api.Models.Post;
using GraphqlSampleApp.Api.Models.User;
using GraphqlSampleApp.Api.Repositories.Interfaces;
using HotChocolate.Data;

namespace GraphqlSampleApp.Api.Types.Query
{
    [ExtendObjectType(typeof(Query))]
    public class PostQuery
    {    //For the UsePaging middleware to work, our resolver needs to return an IEnumerable<T> or an IQueryable<T>.
         //The middleware will then apply the pagination arguments to what we have returned.In the case of an IQueryable<T> this means that the pagination operations can be directly translated to native database queries. 
         //We also offer pagination integrations for some database technologies that do not use IQueryable.
        [UsePaging(IncludeTotalCount = true)]
        //[UseProjection]
        //[UseSorting]
        //[UseFiltering]
        //[Authorize(Roles= new[] {"admin","super-admin"})]
        //[Authorize(Policy="roles-policy")]
        //[Authorize(Policy="claim-policy-1")]
        //[Authorize(Policy = "claim-policy-2")]
        //[Authorize]
        public async Task<List<Post>> GetPostsByUsername([Service] IPostRepository postRepository, string userName)
        {
            var item = await postRepository.GetPostsByUsername(userName);
            return item;
        }
        public async Task<Post> GetPost([Service] IPostRepository postRepository, string id)
        {
            var item = await postRepository.GetPost(id);
            return item;
        }
    }


}
