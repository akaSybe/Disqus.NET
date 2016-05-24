using System;

namespace Disqus.NET.Models
{
    public class DisqusForum
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public string Founder { get; set; }

        public string Language { get; set; }

        public string TwitterName { get; set; }

        public int ThreadsNumber { get; set; }
    }
}
