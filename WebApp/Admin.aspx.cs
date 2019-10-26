using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Entities;
using WebApp.Repositories;
using WebApp.Interfaces;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Web.Services;

namespace WebApp
{
    public partial class Contact : Page
    {
        private readonly IUserRepository _userRepository;

     /*   public Contact(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        } */
        protected void Page_Load(object sender, EventArgs e)
        {
           // GetUser();

        }
      
       
    }
}