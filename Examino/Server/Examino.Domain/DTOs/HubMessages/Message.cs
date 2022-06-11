using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.DTOs
{
    public class Message
    {
        public string RaportId { get; set; }
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
        public string TextMessage { get; set; }
    }
}
