using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Extensions;
using Disqus.NET.Internal;
using Disqus.NET.Models;

namespace Disqus.NET
{
    public class DisqusPostsApi: DisqusApiBase, IDisqusPostsApi
    {
        public DisqusPostsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) 
            : base(requestProcessor, authMethod, key)
        {
        }

        public Task<DisqusResponse<IEnumerable<DisqusId>>> ApproveAsync(string accessToken, params string[] post)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DisqusResponse<DisqusPost>> DetailsAsync(string postId, DisqusPostRelated related)
        {
            return await DetailsAsync(null, postId, related).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPost>> DetailsAsync(DisqusAccessToken accessToken, string postId, DisqusPostRelated related)
        {
            DisqusParameters parameterBuilder = Parameters
                .WithParameter("post", postId)
                .WithOptionalParameter("access_token", accessToken);

            if (related != DisqusPostRelated.None)
            {
                parameterBuilder.WithMultipleParameters("related", related.ToStringArray());
            }

            Collection<KeyValuePair<string, string>> parameters = parameterBuilder;

            var response = await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusPost>> (DisqusRequestMethod.Get, DisqusEndpoints.Posts.Details, parameters)
                .ConfigureAwait(false);

            return response;
        }
    }
}
