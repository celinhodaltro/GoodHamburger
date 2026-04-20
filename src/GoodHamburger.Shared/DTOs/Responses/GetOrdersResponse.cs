using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Shared.DTOs.Responses
{
    public record GetOrdersResponse(List<OrderDto> Orders);
}
