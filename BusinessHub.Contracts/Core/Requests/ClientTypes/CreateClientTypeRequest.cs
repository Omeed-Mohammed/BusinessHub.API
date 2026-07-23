using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Requests.ClientTypes
{
    public class CreateClientTypeRequest
    {
        public string ClientTypeName { get; set; } = string.Empty;
    }
}
