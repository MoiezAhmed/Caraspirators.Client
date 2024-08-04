using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Entities
{
    public class Subjects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        [StringLength(500)]
        public string? SubjectNameAr { get; set; }
        public string? SubjectNameEn { get; set; }
       
      
    }
}
