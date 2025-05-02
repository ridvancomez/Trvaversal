using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class GuideDTO
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image {  get; set; }
        public bool Status { get; set; }

    }
}
