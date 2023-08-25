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
    internal class Consultant : Worker
    {
        private ObservableCollection<Client> _publicClients;

        public Consultant(string pathToClientsData) :
            base(pathToClientsData)
        {
            _publicClients = new ObservableCollection<Client>();
            for (int i = 0; i < base.Clients.Count; i++)
            {
                _publicClients.Add(GetClient(base.Clients[i]));
            }
        }

        public override ObservableCollection<Client> PublicClients
        {
            get => _publicClients;
        }



        #region Client Get methods (private)
        /// <summary>
        /// Получает экземпляр клиента для отображения данных для консультанта
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private new Client GetClient(Client client)
        {
            return new Client(
                GetLastname(client),
                GetName(client),
                GetPatronymic(client),
                GetPhone(client),
                GetPassport(client));
        }

        private new string GetPassport(Client client)
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
