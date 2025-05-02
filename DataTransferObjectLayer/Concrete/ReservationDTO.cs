using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class ReservationDTO
    {
        public int DestinationId { get; set; }
        public DateTime CheckIn { get; set; }
        public int PersonCount { get; set; }
    }
}
