using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework_11.Models.WorkerData
{
    internal abstract class Worker
    {
        private ObservableCollection<Client> _clients;
        private readonly string _pathToClientsData;

        public abstract ObservableCollection<Client> PublicClients { get; }

        protected ObservableCollection<Client> Clients
        {
            get => _clients;
        }

        protected Worker(string pathToClientsData)
        {
            _pathToClientsData = pathToClientsData;
            _clients = new ObservableCollection<Client>();
            if (File.Exists(_pathToClientsData))
            {
                Load();
            }
            else
            {
                CreateRandomDB(10);
                Save();
            }
        }

        #region Private methods
        /// <summary>
        /// Создание базы случайных клиентов
        /// </summary>
        /// <param name="size">Количество клиентов в базе</param>
        private void CreateRandomDB(int size)
        {
            Client client;
            for (int i = 0; i < size; i++)
            {
                client = new Client();
                _clients.Add(client);
            }
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
        #endregion


        #region Public methods
        /// <summary>
        /// Сохранение базы из памяти в файл
        /// </summary>
        protected void Save()
        {
            string jsonString = JsonSerializer.Serialize(_clients);
            File.WriteAllText(_pathToClientsData, jsonString);
        }
        #endregion


        #region Client Get methods (private)
        /// <summary>
        /// Получает экземпляр клиента для отображения данных для консультанта
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        protected Client GetClient(Client client)
        {
            return new Client(
                GetLastname(client),
                GetName(client),
                GetPatronymic(client),
                GetPhone(client),
                GetPassport(client));
        }

        //private int GetId(Client client)
        //{
        //    return client.ID;
        //}

        protected string GetLastname(Client client)
        {
            return client.Lastname;
        }

        protected string GetName(Client client)
        {
            return client.Name;
        }

        protected string GetPatronymic(Client client)
        {
            return client.Patronymic;
        }

        protected string GetPhone(Client client)
        {
            return client.Phone;
        }

        protected string GetPassport(Client client)
        {            
            return client.Passport;
        }
        #endregion

    }
}
