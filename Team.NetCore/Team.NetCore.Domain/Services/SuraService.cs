using System;
using System.Collections.Generic;
using System.Text;
using Team.NetCore.Domain.Interfaces;

namespace Team.NetCore.Domain.Services
{
    public class SuraService : IClientservice
    {
        public double GetMoney()
        {
            return 5000000;
        }

        public string GetName()
        {
            return "Sura";
        }
    }
}
