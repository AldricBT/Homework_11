using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Homework_11.Data.WorkerData
{
    internal class Consultant : IWorker
    {

        private Client _client;

        public Consultant(Client client)
        {
            _client = client;
        }


        public string Lastname
        {
            get { return _client.Lastname; }
            set { }
        }

        public string Name
        {
            get { return _client.Name; }
            set { }
        }

        public string Patronymic
        {
            get { return _client.Patronymic; }
            set { }
        }

        public string Phone
        {
            get { return _client.Phone; }
            set
            {
                if ((!string.IsNullOrEmpty(value)) && (Math.Floor(Math.Log10(Int64.Parse(value)) + 1) == 11))
                    _client.Phone = value;
            }
        }


        public string Passport
        {
            get
            {
                string stars = "";
                for (int i = 0; i < _client.Passport.Length; i++)
                {
                    stars += "*";
                }
                return stars;
            }
            set { }
        }

        public DateTime EditTime
        {
            get { return _client.EditTime; }
            set { _client.EditTime = DateTime.Now; }
        }

        public string EditData
        {
            get { return _client.EditData; }
            set { _client.EditData = value; }
        }

        public string EditType
        {
            get { return _client.EditType; }
            set { _client.EditType = value; }
        }

        public string EditWho
        {
            get { return _client.EditWho; }
            set { _client.EditWho = value; }
        }

    }
}
