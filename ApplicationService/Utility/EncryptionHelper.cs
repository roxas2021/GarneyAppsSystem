using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Utility
{
    public class EncryptionHelper
    {
        public static string Encrypt(string input)
        {
            // Implementation for encryption  
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
        }

        public static string Decrypt(string input)
        {
            // Implementation for decryption  
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input));
        }
    }
}
