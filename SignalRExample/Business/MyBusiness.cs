using Microsoft.AspNetCore.SignalR;
using SignalRExample.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRExample.Business
{
    public class MyBusiness /*çok yaratıcı bir ismi olan bu sınıf business katmanınn işlerini temsilen kullanılmaktadır. :D*/
    {
        readonly IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessage(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
