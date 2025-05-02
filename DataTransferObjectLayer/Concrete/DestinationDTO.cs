using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class DestinationDTO
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string SubTitle { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public bool Popular { get; set; }
        public string? CoverImage { get; set; }
        public IFormFile? Image{ get; set; }
        public string Details { get; set; }
    }
}
