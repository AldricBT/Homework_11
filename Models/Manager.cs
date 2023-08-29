using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models
{
    internal class Manager : Worker
    {
        private ObservableCollection<Client> _publicClients;

        public override ObservableCollection<Client> PublicClients
        {
            get => _publicClients;
        }

        protected override ObservableCollection<Client> GetPublicData()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();            

            for (int i = 0; i < Clients.Count; i++)
            {                
                clients.Add((Client)Clients[i].Clone());
            }

            return clients;
        }

        public Manager(string pathToClientsData) : base(pathToClientsData)
        {
            _publicClients = GetPublicData();
        }
    }
}
