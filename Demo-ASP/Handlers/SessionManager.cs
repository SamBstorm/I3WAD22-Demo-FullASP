using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public CurrentUser CurrentUser {
            get {
                string data = _session.GetString(nameof(CurrentUser));
                if (data is null) return null;
                return JsonSerializer.Deserialize<CurrentUser>(data);
            }
            set { 
                _session.SetString(
                    nameof(CurrentUser),
                    JsonSerializer.Serialize(value)
                    );
            }
        }
    }
}
