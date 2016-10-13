using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusThreadsApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusId>> ApproveAsync(DisqusAccessToken accessToken, DisqusThreadApproveRequest request);

        /// <summary>
        /// Closes a thread.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> CloseAsync(DisqusAccessToken accessToken, DisqusThreadCloseRequest request);

        /// <summary>
        /// Creates a new thread.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusThread>> CreateAsync(DisqusAccessToken accessToken, DisqusThreadCreateRequest request);

        /// <summary>
        /// Returns thread details.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusThread>> DetailsAsync(DisqusAccessToken accessToken, DisqusThreadDetailsRequest request);

        /// <summary>
        /// Returns thread details.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusThread>> DetailsAsync(DisqusThreadDetailsRequest request);

        /// <summary>
        /// Returns a list of threads sorted by the date created.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListAsync(DisqusAccessToken accessToken, DisqusThreadListRequest request);

        /// <summary>
        /// Returns a list of threads sorted by the date created.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusThread>>> ListAsync(DisqusThreadListRequest request);

        /// <summary>
        /// Returns a list of threads sorted by hotness (date and likes).
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusThread>>> ListHotAsync(DisqusAccessToken accessToken, DisqusThreadListHotRequest request);

        /// <summary>
        /// Returns a list of threads sorted by hotness (date and likes).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusThread>>> ListHotAsync(DisqusThreadListHotRequest request);

        /// <summary>
        /// Returns a list of threads sorted by number of posts made since 'interval'
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusThread>>> ListPopularAsync(DisqusAccessToken accessToken, DisqusThreadListPopularRequest request);

        /// <summary>
        /// Returns a list of threads sorted by number of posts made since 'interval'
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusThread>>> ListPopularAsync(DisqusThreadListPopularRequest request);

        /// <summary>
        /// Returns a list of posts within a thread.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusAccessToken accessToken, DisqusThreadListPostsRequest request);

        /// <summary>
        /// Returns a list of posts within a thread.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPostsAsync(DisqusThreadListPostsRequest request);

        /// <summary>
        /// Returns a list of users that voted on this thread.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusUser>>> ListUsersVotedThreadAsync(DisqusAccessToken accessToken, DisqusThreadListUsersVotedThreadRequest request);

        /// <summary>
        /// Returns a list of users that voted on this thread.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusUser>>> ListUsersVotedThreadAsync(DisqusThreadListUsersVotedThreadRequest request);

        /// <summary>
        /// Opens a thread.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> OpenAsync(DisqusAccessToken accessToken, DisqusThreadOpenRequest request);

        /// <summary>
        /// Removes a thread.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> RemoveAsync(DisqusAccessToken accessToken, DisqusThreadRemoveRequest request);

        /// <summary>
        /// Opens a thread.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> RestoreAsync(DisqusAccessToken accessToken, DisqusThreadRestoreRequest request);

        /// <summary>
        /// Returns an unsorted set of threads given a list of ids.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusThread>>> SetAsync(DisqusAccessToken accessToken, DisqusThreadSetRequest request);

        /// <summary>
        /// Returns an unsorted set of threads given a list of ids.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusThread>>> SetAsync(DisqusThreadSetRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> SpamAsync(DisqusAccessToken accessToken, DisqusThreadSpamRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="thread"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> SubscribeAsync(DisqusAccessToken accessToken, string thread);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="thread"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> SubscribeAsync(string email, string thread);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="thread"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> UnsubscribeAsync(DisqusAccessToken accessToken, string thread);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="thread"></param>
        /// <returns></returns>
        Task<DisqusResponse<string>> UnsubscribeAsync(string email, string thread);

        /// <summary>
        /// Updates information on a thread.
        /// </summary>
        /// <returns></returns>
        Task<DisqusResponse<DisqusThread>> UpdateAsync(DisqusAccessToken accessToken, DisqusThreadUpdateRequest request);

        /// <summary>
        /// Register a vote on a thread.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusVoteStats>> VoteAsync(DisqusAccessToken accessToken, DisqusThreadVoteRequest request);

        /// <summary>
        /// Register a vote on a thread.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusVoteStats>> VoteAsync(DisqusThreadVoteRequest request);
    }
}
