using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Entities;

public class PostTag
{
    public int PostId { get; set; }

    public Post Posts { get; set; }
    public int TagId { get; set; }

    public Tag Tags { get; set; }

}
