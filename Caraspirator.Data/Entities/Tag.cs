using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Entities;

public class Tag
{

    public int Id { get; set; }
    public ICollection<Post> posts { get; set; }
    public ICollection<PostTag> PostTags { get; set; }



}
