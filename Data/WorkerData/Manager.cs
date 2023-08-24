using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Data.WorkerData
{
    internal class Manager : IWorker
    {

        private Client client;

        public Manager(Client client)
        {
            this.client = client;
        }

        public string Lastname
        {
            get { return client.Lastname; }
            set { client.Lastname = value; }
        }

        public string Name
        {
            get { return client.Name; }
            set { client.Name = value; }
        }

        public string Patronymic
        {
            get { return client.Patronymic; }
            set { client.Patronymic = value; }
        }

        public string Phone
        {
            get { return client.Phone; }
            set
            {
                if (Math.Floor(Math.Log10(Int64.Parse(value)) + 1) == 11) client.Phone = value;
            }
        }

        public string Passport
        {
            get { return client.Passport; }
            set { client.Passport = value; }
        }

        public DateTime EditTime
        {
            get { return client.EditTime; }
            set { client.EditTime = DateTime.Now; }
        }

        public string EditData
        {
            get { return client.EditData; }
            set { client.EditData = value; }
        }

        public string EditType
        {
            get { return client.EditType; }
            set { client.EditType = value; }
        }

        public string EditWho
        {
            get { return client.EditWho; }
            set { client.EditWho = "Менеджер"; }
        }
    }
}
