using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLayer.Concrete
{
    public class MailRequestDTO
    {
        public string? Name { get; set; }
        public string? SenderMail { get; set; }
        public string? ReceiverMail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
