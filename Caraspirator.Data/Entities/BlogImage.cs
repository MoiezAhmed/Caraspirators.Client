using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Entities;

public class BlogImage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string? image { get; set; }
    public string? caption { get; set; }

    public int blogforginkey { get; set; }
 //   [ForeignKey(nameof(blogforginkey))]
    public virtual Tag? blog { get; set; }

}
