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
    internal class ReadOnlyRepositoryOfClients : IEnumerable
    {

        #region Поля
        private ReadOnlyObservableCollection<Client> _clients;
        
        #endregion
        
        /// <summary>
        /// Конструктор. В случае отсутствия базы данных создает случайную
        /// </summary>
        /// <param name="path"></param>
        public ReadOnlyRepositoryOfClients(RepositoryOfClients clients)
        {            
            _clients = new ReadOnlyObservableCollection<Client>(clients.Clients);
        }
        
        /// <summary>
        /// Реализация интерфейса IEnumerable для перечисления коллекции
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator() => _clients.GetEnumerator();
        
    }
}

