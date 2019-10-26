using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Entities
{
    public class User : Entities.BaseEntity
    {
        public string NickName { get; set; }
    }
}