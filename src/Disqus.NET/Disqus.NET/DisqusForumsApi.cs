using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disqus.NET.Models;

namespace Disqus.NET
{
    internal class DisqusForumsApi: IDisqusForumsApi
    {
        public DisqusForumsApi()
        {
            
        }

        public async Task<DisqusResponse<DisqusForum>> GetForumDetailsAsync(string forum, DisqusForumAttach attach = DisqusForumAttach.None, DisqusForumRelated related = DisqusForumRelated.None)
        {
            throw new NotImplementedException();
        }
    }
}
