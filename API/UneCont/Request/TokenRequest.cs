using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UneCont.Request;
public class TokenRequest
{
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
