using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Core.Extensions
{
    public static class GetByUserIdExtansions
    {
        public static string GetByUserId(this HttpContext httpContext)
        {
            return httpContext.User==null ? string.Empty 
                : httpContext.User.Claims.Single(x => x.Type == "Id").Value;
        }
    }
}
