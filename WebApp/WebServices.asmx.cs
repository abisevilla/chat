using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using WebApp.Entities;

namespace WebApp
{
    /// <summary>
    /// Descripción breve de WebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
   
    [System.Web.Script.Services.ScriptService]
    public class WebServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public  string  GetUser()
        {
            List<User> list = new List<User>();

            using (var db = new AppDbContext())
            {

                var users = db.Users.Select(e => new { e.Id , e.NickName }).ToList();

                //for (int i = 0; i < users.Length; i++)
                //{
                //    string s = users[i];
                //    var nickname = new User() { NickName = s };
                //    list.Add(nickname);
                    
                //}

                return  JsonConvert.SerializeObject(users);
            }

        }
    }
}
