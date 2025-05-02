using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string DayNigth { get; set; }
        public double Price { get; set; }
        public string SubTitle { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public bool Popular { get; set; }
        public string CoverImage { get; set; }
        public string Details { get; set; }

        public List<Picture>Pictures { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Reservation> Rezervations { get; set; }
    }
}
