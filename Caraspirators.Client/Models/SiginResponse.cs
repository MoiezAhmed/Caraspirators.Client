using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirators.Client.Models;

public class SiginResponse
{
    public int StatusCode { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public LoginData Data { get; set; }
}
