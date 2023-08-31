using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models
{
    internal class Consultant : Worker
    {
        private ObservableCollection<Client> _publicClients;

        public override ObservableCollection<Client> PublicClients
        {
            get => _publicClients;
        }

        protected override ObservableCollection<Client> GetPublicData()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();            
            string passport;
            
            for (int i = 0; i < Clients.Count; i++)
            {                
                passport = new string('*', Clients[i].Passport.Length);
                clients.Add((Client)Clients[i].Clone());
                clients[i].Passport = passport;
            }

            return clients;
        }

        public override void ChangedClientData(Client _changed, Client _remember)
        {
            Clients.Where(c => c.Id == _changed.Id).First().Phone = _changed.Phone;

            Clients.Where(c => c.Id == _changed.Id).First().EditData = EnumOfEditData.Телефон.ToString();
            Clients.Where(c => c.Id == _changed.Id).First().EditTime = DateTime.Now;
            Clients.Where(c => c.Id == _changed.Id).First().EditWho = EnumOfWorkers.Консультант.ToString();
            Clients.Where(c => c.Id == _changed.Id).First().EditType = "Изменение";

            _publicClients.Where(c => c.Id == _changed.Id).First().EditData = EnumOfEditData.Телефон.ToString();
            _publicClients.Where(c => c.Id == _changed.Id).First().EditTime = DateTime.Now;
            _publicClients.Where(c => c.Id == _changed.Id).First().EditWho = EnumOfWorkers.Консультант.ToString();
            _publicClients.Where(c => c.Id == _changed.Id).First().EditType = "Изменение";

            Save();
        }

        public Consultant(string pathToClientsData) : base(pathToClientsData)
        {
            _publicClients = GetPublicData();
        }
    }
}
