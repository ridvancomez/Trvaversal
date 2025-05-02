using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
