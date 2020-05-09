using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatUygulamasi.Models;
using Microsoft.AspNet.SignalR;

namespace ChatUygulamasi.Hubs
{
    public class ChatHub : Hub
    {
        DataContext db = new DataContext();
       public void Send(string username, string message)
    {
            Mesaj mesaj = new Mesaj();
            mesaj.Id =0;
            mesaj.GonderenAdi = username;
            mesaj.AliciAdi = "Grup";
            mesaj.MesajMetin = message;
            mesaj.Tarih = DateTime.Now;

            db.Mesajs.Add(mesaj);
            db.SaveChanges();
        Clients.All.sendMessage(username, message);
    }
        
    }
}