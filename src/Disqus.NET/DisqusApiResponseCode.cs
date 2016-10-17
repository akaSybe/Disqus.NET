namespace Disqus.NET
{
    /// <summary>
    /// <remarks>https://disqus.com/api/docs/errors/</remarks>
    /// </summary>
    public enum DisqusApiResponseCode
    {
        /// <summary>
        /// Success
        /// </summary>
        Success = 0,
        /// <summary>
        /// Endpoint not valid
        /// </summary>
        InvalidEndpoint = 1,
        /// <summary>
        /// Missing or invalid argument
        /// </summary>
        MissingOrInvalidArgument = 2,
        /// <summary>
        /// Endpoint resource not valid
        /// </summary>
        InvalidResource = 3,
        /// <summary>
        /// You must be authenticated to perform this action
        /// </summary>
        AuthenticationRequired = 4,
        /// <summary>
        /// Invalid API key
        /// </summary>
        InvalidApiKey = 5,
        /// <summary>
        /// Invalid API version
        /// </summary>
        InvalidApiVersion = 6,
        /// <summary>
        /// You cannot access this resource using %(request_method)s
        /// </summary>
        InvalidResourceHttpMethod = 7,
        /// <summary>
        /// A requested object was not found
        /// </summary>
        RequestedObjectNotFound = 8,
        /// <summary>
        /// You cannot access this resource using your %(access_type)s API key
        /// </summary>
        NoAccessToResourceWithApiKey = 9,
        /// <summary>
        /// This operation is not supported
        /// </summary>
        NotSupportedOperation = 10,
        /// <summary>
        /// Your API key is not valid on this domain
        /// </summary>
        InvalidApiKeyOnThisDomain = 11,
        /// <summary>
        /// This application does not have enough privileges to access this resource
        /// </summary>
        ApplicationHaveNoAccessToResource = 12,
        /// <summary>
        /// You have exceeded the rate limit for this resource
        /// </summary>
        ExceededResourceRateLimit = 13,
        /// <summary>
        /// You have exceeded the rate limit for your account
        /// </summary>
        ExceededAccountRateLimit = 14,
        /// <summary>
        /// There was internal server error while processing your request
        /// </summary>
        InternalServerError = 15,
        /// <summary>
        /// Your request timed out
        /// </summary>
        Timeout = 16,
        /// <summary>
        /// The authenticated user does not have access to this feature
        /// </summary>
        AuthenticatedUserHaveNoAccessToFeature = 17,
        /// <summary>
        /// The authorization signature you passed was not valid
        /// </summary>
        InvalidAuthorizationSignature = 18,
        /// <summary>
        /// You must re-submit this request with a response to the captcha challenge
        /// </summary>
        CaptchaRequired = 19,
        /// <summary>
        /// The API is currently undergoing maintenance, and your changes were saved, but will not be visible yet.
        /// </summary>
        ApiUndergoingMaintenanceAndChangesWereSaved = 20,
        /// <summary>
        /// The API is currently undergoing maintenance, and your changes could not be saved.
        /// </summary>
        ApiUndergoingMaintenanceAndChangesCouldNotBeSaved = 21,
        /// <summary>
        /// You do not have the appropriate permissions to access this resource
        /// </summary>
        NoAppropriatePermissionsToResource = 22,
        /// <summary>
        /// You must be authenticated and verified by the forum owner to perform this action
        /// </summary>
        VerificationRequired = 23,
    }
}