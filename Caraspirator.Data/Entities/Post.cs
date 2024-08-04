using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<PostTag> PostTag { get; set; }
    }
}
