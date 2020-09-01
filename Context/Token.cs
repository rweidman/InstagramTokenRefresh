using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramTokenRefresh.Context
{
    public class Token
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public DateTime DateModified { get; set; }
        public virtual Client Client { get; set; }

    }
}
