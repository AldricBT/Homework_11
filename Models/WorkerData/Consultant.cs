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
        private readonly RepositoryOfClients _repositoryOfClients;
        private readonly PublicRepositoryOfClients _publicClients;
        private readonly string _pathToClientsData;

        
        public Consultant(string pathToClientsData)
        {
            _pathToClientsData = pathToClientsData;
            _repositoryOfClients = new RepositoryOfClients(_pathToClientsData);
            _publicClients = new PublicRepositoryOfClients();
            for (int i = 0;  i < _repositoryOfClients.Clients.Count; i++)
            {
                _publicClients.Add(GetClient(_repositoryOfClients.Clients[i]));
            }
        }
        

        /// <summary>
        /// Свойство для чтения выходных данных
        /// </summary>
        public PublicRepositoryOfClients PublicClients
        {
            get => _publicClients;
        }


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
        public string SetPhone(Client client, )
        {
            get { return _client.Phone; }
            set
            {
                if ((!string.IsNullOrEmpty(value)) && (Math.Floor(Math.Log10(Int64.Parse(value)) + 1) == 11))
                    _client.Phone = value;
            }
        }


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
