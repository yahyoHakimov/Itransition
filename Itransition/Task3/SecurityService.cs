using System.Security.Cryptography;
using System.Text;

namespace Itransition.Task3
{
    public class SecurityService
    {
        public byte[] Key { get; private set; }

        public SecurityService()
        {
            GenerateKey();
        }

        private void GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                Key = new byte[32]; // 256 bits
                rng.GetBytes(Key);
            }
        }

        public string ComputeHMAC(string message)
        {
            using (var hmac = new HMACSHA256(Key))
            {
                byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return BitConverter.ToString(hashValue).Replace("-", "");
            }
        }
    }
}
