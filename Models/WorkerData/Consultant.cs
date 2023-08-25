using Homework_11.Models.ClientsData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Homework_11.Models.WorkerData
{
    internal class Consultant
    {
        private ObservableCollection<Client> _clients;
        private ObservableCollection<Client> _publicClients;
        private string _pathToClientsData;

        public ObservableCollection<Client> PublicClients
        {
            get => _publicClients;
        }

        public Consultant(string pathToClientsData) 
        {
            _pathToClientsData = pathToClientsData;
            _clients = new ObservableCollection<Client>();
            _publicClients = new ObservableCollection<Client>();
            if (File.Exists(_pathToClientsData))
            {
                Load();
            }
            else
            {
                CreateRandomDB(10);
                Save();
            }

            for (int i = 0; i < _clients.Count; i++)
            {
                _publicClients.Add(GetClient(_clients[i]));
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
        public void Save()
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
        private Client GetClient(Client client)
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

        private string GetLastname(Client client)
        {
            return client.Lastname;
        }

        private string GetName(Client client)
        {
            return client.Name;
        }

        private string GetPatronymic(Client client)
        {
            return client.Patronymic;
        }

        private string GetPhone(Client client)
        {
            return client.Phone;
        }

        private string GetPassport(Client client)
        {
            string stars = "";
            for (int i = 0; i < client.Passport.Length; i++)
            {
                stars += "*";
            }
            return stars;
        }
        #endregion

        #region Client Set methods
        //public bool SetPhone(Client client, string newPhone)
        //{   
        //    int index = _repositoryOfClients.Clients.IndexOf(client);
        //    if ((!string.IsNullOrEmpty(newPhone)) &&
        //        (Math.Floor(Math.Log10(Int64.Parse(newPhone)) + 1) == 11))
        //    {
        //        _repositoryOfClients.Clients[index].Phone = newPhone;
        //        return true;
        //    }
        //    return false;
        //}


        #endregion





        //public DateTime EditTime
        //{
        //    get { return _client.EditTime; }
        //    set { _client.EditTime = DateTime.Now; }
        //}

        //public string EditData
        //{
        //    get { return _client.EditData; }
        //    set { _client.EditData = value; }
        //}

        //public string EditType
        //{
        //    get { return _client.EditType; }
        //    set { _client.EditType = value; }
        //}

        //public string EditWho
        //{
        //    get { return _client.EditWho; }
        //    set { _client.EditWho = value; }
        //}

    }
}
