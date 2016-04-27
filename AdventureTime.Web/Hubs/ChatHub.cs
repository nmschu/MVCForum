using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AdventureTime.Web.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            //call addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}