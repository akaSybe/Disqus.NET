namespace Disqus.NET.Models
{
    public class DisqusAuthor: DisqusUserBase
    {
        public static implicit operator DisqusAuthor(string str)
        {
            int id;

            int.TryParse(str, out id);

            return new DisqusAuthor()
            {
                Id = id
            };
        }
    }
}
