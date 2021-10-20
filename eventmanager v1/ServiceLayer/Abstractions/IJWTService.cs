using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Abstractions
{
    public interface IJWTService
    {
        
            string GenerateSecurityToken(bool isAdmin, int id);
        
    }
}
