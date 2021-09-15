using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public override string Id { get; set; }
    }
}
