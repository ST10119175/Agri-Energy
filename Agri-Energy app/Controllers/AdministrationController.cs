using Agri_Energy_APP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Agri_Energy_APP.Controllers
{
    public class AdministrationController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        

    }
}
