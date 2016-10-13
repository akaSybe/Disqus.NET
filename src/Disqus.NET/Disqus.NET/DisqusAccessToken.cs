namespace Disqus.NET
{
    public class DisqusAccessToken
    {
        private readonly string _accessToken;

        private DisqusAccessToken(string accessToken)
        {
            _accessToken = accessToken;
        }

        public static DisqusAccessToken Create(string accessToken)
        {
            return new DisqusAccessToken(accessToken);
        }

        public static implicit operator string(DisqusAccessToken accessToken)
        {
            return accessToken._accessToken;
        }

        public override string ToString()
        {
            return _accessToken;
        }
    }
}
