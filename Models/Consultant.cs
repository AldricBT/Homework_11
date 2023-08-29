using Homework_11.Data;
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

        public ObservableCollection<Client> PublicClients
        {
            get => _publicClients;
        }

        private ObservableCollection<Client> GetPublicData()
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

        public Consultant(string pathToClientsData) : base(pathToClientsData)
        {
            _publicClients = GetPublicData();
        }
    }
}
