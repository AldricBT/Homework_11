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

        public override void ChangedClientData(Client _changed, Client _remember)
        {
            Edit(Clients.Where(c => c.Id == _changed.Id).First().Id, _changed);
            string editData = string.Empty;

            //поиск имени измененного свойства
            for (int i = 0; i < _remember.GetType().GetProperties().Length; i++)
            {
                if (_remember.GetType().GetProperties()[i].GetValue(_remember!)!.ToString() !=
                    _changed.GetType().GetProperties()[i].GetValue(_changed!)!.ToString())
                {                   
                    editData = ((EnumOfEditData)i).ToString();
                    break;
                }
            }                        

            Clients.Where(c => c.Id == _changed.Id).First().EditData = editData;
            Clients.Where(c => c.Id == _changed.Id).First().EditTime = DateTime.Now;
            Clients.Where(c => c.Id == _changed.Id).First().EditWho = EnumOfWorkers.Менеджер.ToString();
            Clients.Where(c => c.Id == _changed.Id).First().EditType = "Изменение";

            _publicClients.Where(c => c.Id == _changed.Id).First().EditData = editData;
            _publicClients.Where(c => c.Id == _changed.Id).First().EditTime = DateTime.Now;
            _publicClients.Where(c => c.Id == _changed.Id).First().EditWho = EnumOfWorkers.Менеджер.ToString();
            _publicClients.Where(c => c.Id == _changed.Id).First().EditType = "Изменение";

            Save();
        }

        public Manager(string pathToClientsData) : base(pathToClientsData)
        {
            _publicClients = GetPublicData();
        }
    }
}
