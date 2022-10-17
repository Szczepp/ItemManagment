using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.DomainModels
{
    public class Item
    {
        public Item()
        {
            this.ItemCollection = new HashSet<ItemCollection>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Image { get; set; }
        public virtual ICollection<ItemCollection> ItemCollection { get; set; }
    }
}
