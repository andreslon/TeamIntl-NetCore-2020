using System;
using System.Collections.Generic;
using System.Text;
using Team.NetCore.Domain.Interfaces;

namespace Team.NetCore.Domain.Services
{
    public class ClientService : IClientservice
    {
        public double GetMoney()
        {
            return 1000000;
        }

        public string GetName()
        {
            return "GENERIC";
        }
    }
}
