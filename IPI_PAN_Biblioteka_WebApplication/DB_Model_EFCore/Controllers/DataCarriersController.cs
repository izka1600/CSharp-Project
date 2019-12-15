using DB_Model_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DB_Model_EFCore.Controllers
{
    public class DataCarriersController
    {
        PublicLibraryContext context = new PublicLibraryContext();
        public int CreateNewDataCarrier(string name)
        {
            var newDataCarr = new DataCarriers
            {
                Name = name
            };

            context.DataCarriers.Add(newDataCarr);
            context.SaveChanges();
            int newId = newDataCarr.DataCarrierId;
            return newId;
        }
        public List<DataCarriers> ListDataCarriers()
        {
            return context.DataCarriers.Where(r => r.DeleteDate == null).ToList();
        }
        public DataCarriers FindDataCarriers(int id)
        {
            return context.DataCarriers.Find(id);
        }
        public void UpdateDataCarriers(int Id, string name)
        {
            var upd = context.DataCarriers.Find(Id);
            upd.Name = name;
            upd.EditDate = DateTime.Now;
            context.SaveChanges();
        }
        public void DeleteDataCarriers(int Id)
        {
            var upd = context.DataCarriers.Find(Id);
            upd.DeleteDate = DateTime.Now;
            context.SaveChanges();
        }
    }
}
