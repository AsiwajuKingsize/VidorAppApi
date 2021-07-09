using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BAL_SERVICES.Helpers
{
    public class SecurityHelper
    {
        public static string GenerateSalt(int nSalt = 100)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt= "rUUZZDF9VMLTQLmaOOk/hyscIkdRdF+ROuFOgAtRprQ+KdVbP2QeQOt24ZDQfdOT04/tufyLajpDae6LjWs/lwdIsh1w2POyI26WU01vhzE/8SPmkI236j1VDrWvAjvJ1qd6NQ==", int nIterations= 10150, int nHash=50)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }
    }
}
