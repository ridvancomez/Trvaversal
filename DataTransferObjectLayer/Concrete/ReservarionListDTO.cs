using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class ReservarionListDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public DateTime CheckIn { get; set; }
        public int PersonCount { get; set; }
        public string Status { get; set; }

    }
}
