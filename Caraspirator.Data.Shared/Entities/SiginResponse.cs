using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Shared.Entities;

public class SiginResponse
{
    public int statusCode { get; set; }
    public object meta { get; set; }
    public bool succeeded { get; set; }
    public string message { get; set; }
    public object errors { get; set; }
    public LoginData data { get; set; }
}
