using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class CommentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int DestinationId { get; set; }
    }
}
