using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChatUygulamasi.Models;
using Microsoft.AspNet.SignalR;

namespace ChatUygulamasi.Hubs
{
    public class ChatHub : Hub
    {
        DataContext db = new DataContext();

   

        #region Methods

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            var kontrol = db.Kullanicis.Where(x => x.KullaniciAdi == userName).Count();
            var durum = "Cevrimici";
            if (kontrol == 0)
            {
                db.Kullanicis.Add(new Kullanici { Id = 0, connectionId = id, KullaniciAdi = userName, Durum =durum });
                db.SaveChanges();
            }
           else
            {
                var bulunan = db.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == userName);
                bulunan.Durum = "Cevrimici";
                bulunan.connectionId = id;

                db.Entry(bulunan).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            // send to caller
            Clients.Caller.onConnected(id, userName,durum, db.Kullanicis, db.Mesajs);

                // send to all except caller client
            Clients.AllExcept(id).onNewUserConnected(id, userName,durum);

            

        }

        public void SendMessageToAll(string userName, string message)
        {
            // store last 100 messages in cache
            AddMessageinCache(userName, message);

            // Broad cast message
            Clients.All.messageReceived(userName, message);
        }

        public void SendMessageToGruop(string userName, string message,string grupName)
        {
            // store last 100 messages in cache
            AddMessageinCache(userName, message);

            // Broad cast message
            Clients.Group(grupName).sendMessageToGruop(userName, message);
        }

        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId =Context.ConnectionId;

            var toUser = db.Kullanicis.FirstOrDefault(x => x.connectionId == toUserId);
            var fromUser = db.Kullanicis.FirstOrDefault(x => x.connectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                AddMessageinCachePrivate(toUser.KullaniciAdi,fromUser.KullaniciAdi, message);
                // send to 
                Clients.Client(toUserId.ToString()).sendPrivateMessage(fromUserId, fromUser.KullaniciAdi, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.KullaniciAdi, message);
            }

        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var id =Context.ConnectionId;

            var item = db.Kullanicis.FirstOrDefault(x => x.connectionId== id);
          
            if (item != null)
            {
                item.Durum = "Cevrimdısı";
                item.CikisTarih = DateTime.Now;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                
                Clients.All.onUserDisconnected(item.KullaniciAdi, item.Durum);

            }

            return base.OnDisconnected(stopCalled);
        }


        #endregion

        #region private Messages

        private void AddMessageinCache(string userName, string message)
        {
            db.Mesajs.Add(new Mesaj { Id =0 , AliciAdi = "Genel",GonderenAdi=userName, MesajMetin = message ,Tarih=DateTime.Now});
            db.SaveChanges();
        }

        private void AddMessageinCachePrivate(string alici,string gonderen, string message)
        {
            db.Mesajs.Add(new Mesaj { Id = 0, AliciAdi = alici, GonderenAdi = gonderen, MesajMetin = message, Tarih = DateTime.Now });
            db.SaveChanges();
        }

        public void join(string roomName)
        {
            Groups.Add(Context.ConnectionId, roomName);
        }

    }
}
#endregion