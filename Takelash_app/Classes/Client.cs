using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Takelash_app.Classes
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Phone { get; set; }
        public Client() { }

        public Client(string Name, string Description, string Date, string Phone, int Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Date = Date;
            this.Phone = Phone;
        }
    }
}
