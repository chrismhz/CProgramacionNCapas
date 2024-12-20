using CMartinezTestWebServices.ServiceReferenceDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMartinezTestWebServices
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceReferenceDemo.OperacionesClient operacionesClient = new ServiceReferenceDemo.OperacionesClient();

            var resultado = operacionesClient.Suma(10,2);
        }
    }
}
