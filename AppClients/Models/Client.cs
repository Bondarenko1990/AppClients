using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppClients.Models
{
    [Table("Clients")]
    public class Client
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [DisplayFormat(DataFormatString = "{0:###-###-##-##}")]
        [Display(Name = "Phone1")]
        public string Phone1 { get; set; }

        [DisplayFormat(DataFormatString = "{0:###-###-##-##}")]
        [Display(Name = "Phone2")]
        public string Phone2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:###-###-##-##}")]
        [Display(Name = "Phone3")]
        public string Phone3 { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public Client()
        {
            Tasks = new List<Task>();
        }
    }
}