using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RefilWeb.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public virtual User Creator { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime CreateDate { get; set; }
    }
}