using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class DestinationDetailImageDTO
    {
        public int DestinationId { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile Image { get; set; }
        
    }
}
