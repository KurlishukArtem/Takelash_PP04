using System;
using System.Collections.Generic;
using System.Text;

namespace Takelash_app.Classes
{
    public class CompanyType
    {
        public int id { get; set; }
        public string name { get; set; }
        public CompanyType() { }
        public CompanyType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
