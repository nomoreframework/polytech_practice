using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_7_WEB.Services.InitialDBService
{
    public class InitialService
    {
        InitialDBService service;
        public InitialService(InitialDBService service)
        {
            this.service = service;
        }
        public void DbInitial()
        {
            service.InitialDatabse();
        }
    }
}
