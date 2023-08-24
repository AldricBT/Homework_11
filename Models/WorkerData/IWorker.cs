using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models.WorkerData
{
    internal interface IWorker
    {
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public DateTime EditTime { get; set; }
        public string EditData { get; set; }
        public string EditType { get; set; }
        public string EditWho { get; set; }
    }
}
