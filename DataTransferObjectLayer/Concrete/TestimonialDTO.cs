using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class TestimonialDTO
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Comment { get; set; }
        public string? ClientImage { get; set; }
        public IFormFile Image { get; set; }
        public bool Status { get; set; }


    }
}
