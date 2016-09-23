using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AzureCache
{
    public class LocalStore
    {
        private List<IEntity> _entityStore;
        private static LocalStore _instance;
        private LocalStore()
        {
            ProvisionStore();
        }

        public static LocalStore GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }
            _instance = new LocalStore();
            return _instance;
        }

        public IEntity GetById(int id)
        {
            return _entityStore.FirstOrDefault(e => e.Id == id);
        }

        private void ProvisionStore()
        {
            _entityStore = new List<IEntity>()
            {
                new MyEntity(1, "first name"),
                new MyEntity(2, "second name")
            };
        }
    }
}
