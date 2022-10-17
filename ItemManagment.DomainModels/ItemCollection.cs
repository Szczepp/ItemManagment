using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.DomainModels
{
    public class ItemCollection
    {
        public ItemCollection()
        {
            this.Items = new HashSet<Item>();  
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
