using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessage(string message,IEnumerable<string> connectionIds)
        //public async Task SendMessage(string message,string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessage(string message,IEnumerable<string> groups)
        public async Task SendMessage(string message,string groupname)
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
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client
            // Server'a bağlı olan clientlar arasından sadece belirli bir clienta bildiride bulunur.
            //await Clients.Clients(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion

            #region Clients
            //Server'a bağlı olan clientlar arasından sadece belirtilenlere bildiride bulunur.
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);

            #endregion

            #region Group
            //Belirtilen gruptaki tüm clientlara bildiride bulunur.
            // Önce gruplar oluşturulmalı ve ardından clientlar gruplara subsc. olmalıdır.
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);

            #endregion

            #region GroupExcept
            //Belirtilen gruptaki belirtilen clientlar dışındaki tüm clientlara mesaj iletmemizi sağlayan fonksiyondur.
            //await Clients.GroupExcept(groupName,connectionIds).SendAsync("receiveMessage", message);

            #endregion

            #region Groups
            //await Clients.Groups(groups).SendAsync("receiveMessage", message);
            #endregion

            #region OthersInGroup
            //Bildiride bulunan client haricinde gruptaki tüm clientlara bildiride bulunan fonksiyondur.
            await Clients.OthersInGroup(groupname).SendAsync("receiveMessage", message);
            #endregion

            #region User
            //Authenticate olmuş kullanıcalara bildirim yapma ile ilgili metotdur. Sadece bir kullanıcıya bildiride bulunur.
            #endregion

            #region Users
            //Authenticate olmuş kullanıcalara bildirim yapma ile ilgili metotdur. Birden fazla kullanıcıya bildiride bulunur.
            #endregion

            #endregion
        }
        public override async Task OnConnectedAsync()
        {
           await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connnectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connnectionId,groupName);
        }
    }
}
