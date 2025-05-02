using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class AdminReservationDTO
    {
        public int AppUserId { get; set; }
        public int DestinationId{ get; set; }
        public int PersonCount { get; set; }
        public DateTime CheckIn { get; set; }
        public string Status { get; set; }
    }
}
