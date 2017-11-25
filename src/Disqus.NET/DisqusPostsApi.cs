using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusPostsApi: DisqusApiBase, IDisqusPostsApi
    {
        public DisqusPostsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) 
            : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<DisqusResponse<IEnumerable<DisqusId>>> ApproveAsync(DisqusAccessToken accessToken, params string[] posts)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters("post", posts);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusId>>>(DisqusRequestMethod.Post, DisqusEndpoints.Posts.Approve, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPost>> CreateAsync(DisqusAccessToken accessToken, DisqusPostCreateRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusPost>>(DisqusRequestMethod.Post, DisqusEndpoints.Posts.Create, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPost>> CreateAsync(DisqusPostCreateRequest request)
        {
            return await CreateAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPost>> DetailsAsync(DisqusAccessToken accessToken, DisqusPostDetailsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusPost>>(DisqusRequestMethod.Get, DisqusEndpoints.Posts.Details, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPost>> DetailsAsync(DisqusPostDetailsRequest request)
        {
            return await DetailsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusPost>>> GetContextAsync(DisqusAccessToken accessToken, DisqusPostGetContextRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusPost>>>(DisqusRequestMethod.Get, DisqusEndpoints.Posts.GetContext, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusPost>>> GetContextAsync(DisqusPostGetContextRequest request)
        {
            return await GetContextAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListAsync(DisqusAccessToken accessToken, DisqusPostListRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusPost>>>(DisqusRequestMethod.Get, DisqusEndpoints.Posts.List, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListAsync(DisqusPostListRequest request)
        {
            return await ListAsync(null, request).ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPopularAsync(DisqusAccessToken accessToken, DisqusPostListPopularRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters(request.Parameters)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusPost>>>(DisqusRequestMethod.Get, DisqusEndpoints.Posts.ListPopular, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPopularAsync(DisqusPostListPopularRequest request)
        {
            return await ListPopularAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusId>>> RemoveAsync(DisqusAccessToken accessToken, params long[] posts)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters("post", posts.Select(p => p.ToString()).ToArray())
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusId>>>(DisqusRequestMethod.Post, DisqusEndpoints.Posts.Remove, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPost>> ReportAsync(DisqusAccessToken accessToken, long postId)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("post", postId.ToString())
                .WithParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusPost>>(DisqusRequestMethod.Post, DisqusEndpoints.Posts.Report, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPost>> ReportAsync(int postId)
        {
            return await ReportAsync(null, postId).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusId>>> RestoreAsync(DisqusAccessToken accessToken, params long[] posts)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters("post", posts.Select(p => p.ToString()).ToArray())
                .WithParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusId>>>(DisqusRequestMethod.Post, DisqusEndpoints.Posts.Restore, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusId>>> SpamAsync(DisqusAccessToken accessToken, params long[] posts)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithMultipleParameters("post", posts.Select(p => p.ToString()).ToArray())
                .WithParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusId>>>(DisqusRequestMethod.Post, DisqusEndpoints.Posts.Spam, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPost>> UpdateAsync(DisqusAccessToken accessToken, long postId, string message)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("post", postId.ToString())
                .WithParameter("message", message)
                .WithParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusPost>>(DisqusRequestMethod.Post, DisqusEndpoints.Posts.Update, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPostVoteStats>> VoteAsync(DisqusAccessToken accessToken, long postId, DisqusVote vote)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("post", postId.ToString())
                .WithParameter("vote", vote.ToString("D"))
                .WithParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusPostVoteStats>>(DisqusRequestMethod.Post, DisqusEndpoints.Posts.Vote, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusPostVoteStats>> VoteAsync(long postId, DisqusVote vote)
        {
            return await VoteAsync(null, postId, vote).ConfigureAwait(false);
        }
    }
}
