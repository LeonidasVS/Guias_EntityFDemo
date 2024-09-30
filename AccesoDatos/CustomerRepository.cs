using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public NorthwindEntities contexto = new NorthwindEntities();

        public List<Customers> ObtenerTodos()
        {
            var cliente = from cum in contexto.Customers select cum;
            return cliente.ToList();
        }

        public Customers ObtenerPorID(string id)
        {
            var obtenerCliente = from cm in contexto.Customers where cm.CustomerID == id select cm;
            return obtenerCliente.FirstOrDefault();
        }

        public int InsertarClientes(Customers customer)
        {
            contexto.Customers.Add(customer);
            return contexto.SaveChanges();
        }

        public int UpdateCliente(Customers customer)
        {
            var registro = ObtenerPorID(customer.CustomerID);

            if (registro!=null)
            {
                registro.CustomerID = customer.CustomerID;
                registro.CompanyName = customer.CompanyName;
                registro.ContactName = customer.ContactName;
                registro.ContactTitle = customer.ContactTitle;
                registro.Address = customer.Address;
            }

            return contexto.SaveChanges();
        }

        public int ELiminarCLiente(string id)
        {
            var registro = ObtenerPorID(id);
            if (registro!=null)
            {
                contexto.Customers.Remove(registro);
            }

            return contexto.SaveChanges();
        }
    }
}
