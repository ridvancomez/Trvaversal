using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int DestinationId { get; set; }
        public int PersonCount { get; set; }
        public DateTime CheckIn { get; set; }
        public string Status { get; set; }

        public AppUser AppUser { get; set; }
        public Destination Destination { get; set; }
    }
}
