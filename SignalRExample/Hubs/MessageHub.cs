using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRExample.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string message,IEnumerable<string> connectionIds)
        {
            #region Caller
            //Sadece server'a bildirim gönderen client'la iletişim kurar.
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region All
            //Server'a bağlı olan tüm clientlarla iletişim kurar.
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Other
            //Sadece server'a bağlı olan client dışında, server'a bağlı olan tüm clientlara mesaj gönderir.
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Metotları

            #region AllExcept
            //Belirtilen clientlar hariç server'a bağlı olan tüm clientlara bildiride bulunur.
            await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client

            #endregion

            #region Clients

            #endregion

            #region Group

            #endregion

            #region GroupExcept

            #endregion

            #region Groups

            #endregion

            #region OthersInGroup

            #endregion

            #region User

            #endregion

            #region Users

            #endregion

            #endregion
        }
        public override async Task OnConnectedAsync()
        {
           await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
