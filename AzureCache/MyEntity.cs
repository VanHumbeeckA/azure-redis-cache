using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCache
{
    public class MyEntity : IEntity
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public MyEntity(int id, string name=null)
        {
            Id = id;
            if (name != null)
            {
                Name = name;
            }
        }
    }
}
