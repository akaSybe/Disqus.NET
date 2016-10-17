using System.Collections.Generic;
using System.Threading.Tasks;
using Disqus.NET.Models;
using Disqus.NET.Requests;

namespace Disqus.NET
{
    public interface IDisqusPostsApi
    {
        /// <summary>
        /// Approves the requested post(s).
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/approve/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> ApproveAsync(DisqusAccessToken accessToken, params string[] post);

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/create/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> CreateAsync(DisqusAccessToken accessToken, DisqusPostCreateRequest request);

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/create/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> CreateAsync(DisqusPostCreateRequest request);

        /// <summary>
        /// Returns information about a post.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/details/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> DetailsAsync(DisqusAccessToken accessToken, DisqusPostDetailsRequest request);

        /// <summary>
        /// Returns information about a post.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/details/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> DetailsAsync(DisqusPostDetailsRequest request);

        /// <summary>
        /// Returns the hierarchal tree of a post (all parents).
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/getContext/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusPost>>> GetContextAsync(DisqusAccessToken accessToken, DisqusPostGetContextRequest request);

        /// <summary>
        /// Returns the hierarchal tree of a post (all parents).
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/getContext/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusPost>>> GetContextAsync(DisqusPostGetContextRequest request);

        /// <summary>
        /// Returns a list of posts ordered by the date created.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/list/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListAsync(DisqusAccessToken accessToken, DisqusPostListRequest request);

        /// <summary>
        /// Returns a list of posts ordered by the date created.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/list/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListAsync(DisqusPostListRequest request);

        /// <summary>
        /// Returns a list of posts ordered by the date created.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/listPopular/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPopularAsync(DisqusAccessToken accessToken, DisqusPostListPopularRequest request);

        /// <summary>
        /// Returns a list of posts ordered by the date created.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/listPopular/</remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CursoredDisqusResponse<IEnumerable<DisqusPost>>> ListPopularAsync(DisqusPostListPopularRequest request);

        /// <summary>
        /// Deletes the requested post(s).
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/remove/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="posts"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> RemoveAsync(DisqusAccessToken accessToken, params long[] posts);

        /// <summary>
        /// Reports a post (flagging).
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/report/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> ReportAsync(DisqusAccessToken accessToken, long postId);

        /// <summary>
        /// Reports a post (flagging).
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/report/</remarks>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> ReportAsync(int postId);

        /// <summary>
        /// Undeletes the requested post(s).
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/restore/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="posts"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> RestoreAsync(DisqusAccessToken accessToken, params long[] posts);

        /// <summary>
        /// Marks the requested post(s) as spam.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/spam/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="posts"></param>
        /// <returns></returns>
        Task<DisqusResponse<IEnumerable<DisqusId>>> SpamAsync(DisqusAccessToken accessToken, params long[] posts);

        /// <summary>
        /// Updates information on a post.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/update/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="postId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPost>> UpdateAsync(DisqusAccessToken accessToken, long postId, string message);

        /// <summary>
        /// Register a vote on a post.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/vote/</remarks>
        /// <param name="accessToken"></param>
        /// <param name="postId"></param>
        /// <param name="vote"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPostVoteStats>> VoteAsync(DisqusAccessToken accessToken, long postId, DisqusVote vote);

        /// <summary>
        /// Register a vote on a post.
        /// </summary>
        /// <remarks>https://disqus.com/api/docs/posts/vote/</remarks>
        /// <param name="postId"></param>
        /// <param name="vote"></param>
        /// <returns></returns>
        Task<DisqusResponse<DisqusPostVoteStats>> VoteAsync(long postId, DisqusVote vote);
    }
}
