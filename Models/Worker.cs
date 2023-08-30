using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework_11.Models
{
    internal abstract class Worker
    {
        protected enum EnumOfWorkers
        {
            Консультант,
            Менеджер
        }
        protected enum EnumOfEditData
        {
            Фамилия = 1,
            Имя,
            Отчество,
            Телефон,
            Паспорт
        }

        private static string _pathToClientsData = string.Empty;

        private static ObservableCollection<Client> _clients = default!;
        
        public abstract ObservableCollection<Client> PublicClients { get; }

        public static ObservableCollection<Client> Clients
        {
            get => _clients;
        }

        protected abstract ObservableCollection<Client> GetPublicData();

        public static int GetNextID()
        {            
            return Clients.Max(c => c.Id) + 1;         
        }

        /// <summary>
        /// Добавление клиента в базу
        /// </summary>
        /// <param name="client"></param>
        public void Add(Client client)
        {
            _clients.Add(client);
        }

        /// <summary>
        /// Удаление клиента по ID
        /// </summary>
        /// <param name="clientId"></param>
        public void Remove(int clientId)
        {
            _clients.Remove(_clients.Where(c => c.Id == clientId).First());
        }

        /// <summary>
        /// Изменение клиента по ID
        /// </summary>
        /// <param name="clientId">ID изменяемого клиента</param>
        /// <param name="editedClient">На какого клиента редактируют</param>
        public static void Edit(int clientId, Client editedClient)
        {
            _clients[_clients.IndexOf(_clients.Where(c => c.Id == clientId).First())] = editedClient;
        }
        /// <summary>
        /// Изменение данных клиента
        /// </summary>
        /// <param name="_changed">Отображаемый клиент после изменения</param>
        /// /// <param name="_remember">Отображаемый клиент до изменения</param>
        public abstract void ChangedClientData(Client _changed, Client _remember);

        private void CreateRandomDB(int num)
        {
            Random rnd = new Random();            
            for (int i = 0; i < num; i++)
            {
                _clients.Add(new Client(i + 1,
                    "Фамилия_" + rnd.Next(0, 100).ToString(), 
                    "Имя_" + rnd.Next(0, 100).ToString(),
                    "Отчество_" + rnd.Next(0, 100).ToString(),
                    Math.Round((rnd.NextDouble() + 1) * 1e+10).ToString(),
                    Math.Round((rnd.NextDouble() + 1) * 1e+9).ToString()));
            }
            Save();
        }

        public static void Save()
        {
            string jsonString = JsonSerializer.Serialize(_clients);
            File.WriteAllText(_pathToClientsData, jsonString);
        }

        /// <summary>
        /// Загрузка базы из файла в память
        /// </summary>
        private void Load()
        {
            string jsonString = File.ReadAllText(_pathToClientsData);
            if (_clients != null)
                _clients = JsonSerializer.Deserialize<ObservableCollection<Client>>(jsonString)!;
        }

        public Worker(string pathToClientsData)
        {
            _pathToClientsData = pathToClientsData;
            _clients = new ObservableCollection<Client>();

            if (File.Exists(_pathToClientsData))
                Load();
            else
            {
                CreateRandomDB(10);
                Save();
            }

        }
    }
}
