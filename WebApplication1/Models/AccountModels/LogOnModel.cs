using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.AccountModels
{
    public class LogOnModel
    {
        [Required]
        [StringLength(15, MinimumLength = 2)]
        [Display(Name="Brukernavn")]
        public string Username { get; set; }

        [Display(Name ="Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Husk meg på denne maskinen")]
        public bool RememberMe { get; internal set; }
    }
}