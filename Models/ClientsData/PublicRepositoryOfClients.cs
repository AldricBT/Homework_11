using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework_11.Models.ClientsData
{
    internal class PublicRepositoryOfClients : IEnumerable
    {

        
        private ObservableCollection<Client> _clients;

        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
        }

        public PublicRepositoryOfClients()
        {            
            _clients = new ObservableCollection<Client>();
        }

        /// <summary>
        /// Добавление клиента в базу (в памяти)
        /// </summary>
        /// <param name="client">экземпляр клиента</param>
        public void Add(Client client)
        {
            _clients.Add(client);
        }

        /// <summary>
        /// Реализация интерфейса IEnumerable для перечисления коллекции
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator() => _clients.GetEnumerator();
        
    }
}

