using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedColumns.DataAccess;

public class User
{
    public Guid UserId { get; set; }

    public required string SocialSecurityNumber { get; set; }
}
