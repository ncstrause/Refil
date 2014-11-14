using System;
using System.ComponentModel.DataAnnotations;

namespace RefilWeb.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        public virtual User FoodProvider { get; set; }

        public virtual User DrinkProvider { get; set; }

        public virtual Book Book { get; set; }
    }
}