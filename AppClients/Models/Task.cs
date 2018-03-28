using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppClients.Models
{
    [Table("Tasks")]
    public class Task
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Task name")]
        public string TaskName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        //[Display(Name = "Client Address")]
        //public string Address { get; set; }

        [Display(Name = "Start time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public Task()
        {
            Clients = new List<Client>();
        }
    }
}