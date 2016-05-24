namespace Disqus.NET
{
    /// <summary>
    /// <remarks>https://disqus.com/api/docs/errors/</remarks>
    /// </summary>
    public enum DisqusErrorCode
    {
        Success = 0,
        EndpointNotValid = 1,
        MissingOrInvalidArgument = 2,
        EndpointResourceNotValid = 3,
        AuthenticationRequired = 4,
        InvalidApiKey = 5,
        InvalidApiVersion = 6,

    }
}