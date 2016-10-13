using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Disqus.NET.Extensions;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public class DisqusThreadsApi : DisqusApiBase, IDisqusThreadsApi
    {
        public DisqusThreadsApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key) : base(requestProcessor, authMethod, key)
        {
        }

        public async Task<DisqusResponse<DisqusThread>> DetailsAsync(DisqusThreadDetailsRequest request)
        {
            return await DetailsAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusId>> ApproveAsync(DisqusAccessToken accessToken, DisqusThreadApproveRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusId>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Approve, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusId>>> CloseAsync(DisqusAccessToken accessToken, DisqusThreadCloseRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusId>>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Close, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusThread>> DetailsAsync(DisqusAccessToken accessToken, DisqusThreadDetailsRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            var response = await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusThread>>(DisqusRequestMethod.Get, DisqusEndpoints.Threads.Details, parameters)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListAsync(DisqusAccessToken accessToken, DisqusThreadListRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<CursoredDisqusResponse<IEnumerable<DisqusThread>>>(DisqusRequestMethod.Get, DisqusEndpoints.Threads.List, parameters)
                .ConfigureAwait(false);
        }

        public async Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListAsync(DisqusThreadListRequest request)
        {
            return await ListAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusThread>>> ListHotAsync(DisqusAccessToken accessToken, DisqusThreadListHotRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusThread>>>(DisqusRequestMethod.Get, DisqusEndpoints.Threads.ListHot, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusThread>>> ListHotAsync(DisqusThreadListHotRequest request)
        {
            return await ListHotAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusThread>>> ListPopularAsync(DisqusAccessToken accessToken, DisqusThreadListPopularRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusThread>>>(DisqusRequestMethod.Get, DisqusEndpoints.Threads.ListPopular, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusThread>>> ListPopularAsync(DisqusThreadListPopularRequest request)
        {
            return await ListPopularAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusUser>>> ListUsersVotedThreadAsync(DisqusAccessToken accessToken, DisqusThreadListUsersVotedThreadRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusUser>>>(DisqusRequestMethod.Get, DisqusEndpoints.Threads.ListUsersVotedThread, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusUser>>> ListUsersVotedThreadAsync(DisqusThreadListUsersVotedThreadRequest request)
        {
            return await ListUsersVotedThreadAsync(null, request).ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusId>>> OpenAsync(DisqusAccessToken accessToken, DisqusThreadOpenRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusId>>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Open, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusId>>> RemoveAsync(DisqusAccessToken accessToken, DisqusThreadRemoveRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusId>>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Remove, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusId>>> RestoreAsync(DisqusAccessToken accessToken, DisqusThreadRestoreRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusId>>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Restore, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusThread>>> SetAsync(DisqusAccessToken accessToken, DisqusThreadSetRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<IEnumerable<DisqusThread>>>(DisqusRequestMethod.Get, DisqusEndpoints.Threads.Set, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<IEnumerable<DisqusThread>>> SetAsync(DisqusThreadSetRequest request)
        {
            return await SetAsync(null, request).ConfigureAwait(false);
        }

        // TODO: need info
        public async Task<DisqusResponse<string>> SpamAsync(DisqusAccessToken accessToken, DisqusThreadSpamRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Spam, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> SubscribeAsync(DisqusAccessToken accessToken, string thread)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("thread", thread)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Subscribe, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> SubscribeAsync(string email, string thread)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("thread", thread)
                .WithParameter("email", email);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Subscribe, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> UnsubscribeAsync(DisqusAccessToken accessToken, string thread)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("thread", thread)
                .WithOptionalParameter("access_token", accessToken);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Unsubscribe, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<string>> UnsubscribeAsync(string email, string thread)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithParameter("thread", thread)
                .WithParameter("email", email);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<string>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Unsubscribe, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusVoteStats>> VoteAsync(DisqusAccessToken accessToken, DisqusThreadVoteRequest request)
        {
            Collection<KeyValuePair<string, string>> parameters = Parameters
                .WithOptionalParameter("access_token", accessToken)
                .WithMultipleParameters(request.Parameters);

            return await RequestProcessor
                .ExecuteAsync<DisqusResponse<DisqusVoteStats>>(DisqusRequestMethod.Post, DisqusEndpoints.Threads.Vote, parameters)
                .ConfigureAwait(false);
        }

        public async Task<DisqusResponse<DisqusVoteStats>> VoteAsync(DisqusThreadVoteRequest request)
        {
            return await VoteAsync(null, request).ConfigureAwait(false);
        }
    }
}