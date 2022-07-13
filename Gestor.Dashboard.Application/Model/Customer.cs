using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Dashboard.Application.Contracts
{
    public class Customer
    {
        public Guid Id { get; internal set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int DDD { get; private set; }
        public string Phone { get; private set; }
        public string CPF { get; private set; }

       public Customer(string name, string email, int dDD, string phone, string cPF)
        {
            Name = name;
            Email = email;
            DDD = dDD;
            Phone = phone;
            CPF = cPF;
        }
    }
}
