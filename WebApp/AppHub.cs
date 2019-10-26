using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebApp.Entities;
using WebApp.Interfaces;

namespace WebApp
{
    public class AppHub : Hub
    {
        public static List<Client> ConnectedUsers { get; set; } = new List<Client>();
        public string name { get; set; }

        public void Connect(string name )
        {



            Client c = new Client() {

                Id = Context.ConnectionId,
                NickName = name
            };

            var result = ConnectedUsers.FirstOrDefault(u => u.NickName == c.NickName);

            if (result == null)
            {
                AddUser(c);
               // return true;
            }

            Clients.Client(Context.ConnectionId).onMessage(  "Seleccionar otro usuario"       ); 


            
        }

        public void AddUser(Client c)
        {
            ConnectedUsers.Add(c);
            
            Clients.All.updateUsers( ConnectedUsers.Count(), ConnectedUsers.Select(u=>u.NickName));

            using (var db = new AppDbContext())
            {

                var user = new User()
                {
                    NickName = c.NickName
                };
                db.Users.Add(user);
                db.SaveChanges();
            }

        }


        public void Send(string name, string message)
        {
            this.name = name;
            //Context.
            using (var db = new AppDbContext())
            {
                // Retrieve user.
                var user = db.Users.FirstOrDefault(u => u.NickName == this.name);

                // If user does not exist in database, must add.
                if (user == null)
                {
                    user = new User()
                    {
                        NickName = this.name
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                }


            }
            Clients.All.SendMsg(name, message);

        }


      /*  public override System.Threading.Tasks.Task OnConnected()
        {
            
            

           // Clients.Caller.connected(userName, allUsers, messages);
            return base.OnConnected();
        } */
    }
    public class Client
    {
        public string NickName { get; set; }

        public string Id { get; set; }

    }

}