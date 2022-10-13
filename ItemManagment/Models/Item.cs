using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Image { get; set; }
        public Nullable<long> ItemCollectionId { get; set; }
        public virtual ItemCollection ItemCollection { get; set; }
    }
}
