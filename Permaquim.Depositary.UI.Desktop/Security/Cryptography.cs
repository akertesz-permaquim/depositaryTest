using System.Security.Cryptography;
using System.Text;

namespace Permaquim.Depositary.UI.Desktop.Security
{
    public static class Cryptography
    {

        private static int _encoding = 28591;// iso-8859-1 Western European(ISO)
        /// <summary>
        /// Metodo de hasheo de una cadena de caracteres alfanumericos con MD5
        /// </summary>
        /// <param name="Source">La cadena de caracteres</param>
        /// <returns>Un array de bytes con el hash</returns>
        internal static String Hash(String source)
        {
            byte[] _data = System.Text.UTF8Encoding.ASCII.GetBytes(source);
            MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();
            byte[] _hashbyte = _md5.ComputeHash(_data);
            return BitConverter.ToString(_hashbyte);
        }
        public static string HashNuevo(string str)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] bytes = Encoding.Default.GetBytes(str);
            byte[] encoded = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; i++)
                sb.Append(encoded[i].ToString("x2"));

            return sb.ToString();
        }
        public static string Encrypt(string textToEncrypt, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have valid value.", nameof(key));
            if (string.IsNullOrEmpty(textToEncrypt))
                throw new ArgumentException("The text must have valid value.", nameof(textToEncrypt));

            var buffer = Encoding.UTF8.GetBytes(textToEncrypt);
            var hash = SHA512.Create();
            var aesKey = new byte[24];
            Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

            using (var aes = Aes.Create())
            {
                if (aes == null)
                    throw new ArgumentException("Parameter must not be null.", nameof(aes));

                aes.Key = aesKey;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var resultStream = new MemoryStream())
                {
                    using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                    using (var plainStream = new MemoryStream(buffer))
                    {
                        plainStream.CopyTo(aesStream);
                    }

                    var result = resultStream.ToArray();
                    var combined = new byte[aes.IV.Length + result.Length];
                    Array.ConstrainedCopy(aes.IV, 0, combined, 0, aes.IV.Length);
                    Array.ConstrainedCopy(result, 0, combined, aes.IV.Length, result.Length);

                    return Convert.ToBase64String(combined);
                }
            }
        }
        public static string Decrypt(this string textToDecrypt, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have valid value.", nameof(key));
            if (string.IsNullOrEmpty(textToDecrypt))
                throw new ArgumentException("The encrypted text must have valid value.", nameof(textToDecrypt));

            var combined = Convert.FromBase64String(textToDecrypt);
            var buffer = new byte[combined.Length];
            var hash = SHA512.Create();
            var aesKey = new byte[24];
            Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

            using (var aes = Aes.Create())
            {
                if (aes == null)
                    throw new ArgumentException("Parameter must not be null.", nameof(aes));

                aes.Key = aesKey;

                var iv = new byte[aes.IV.Length];
                var ciphertext = new byte[buffer.Length - iv.Length];

                Array.ConstrainedCopy(combined, 0, iv, 0, iv.Length);
                Array.ConstrainedCopy(combined, iv.Length, ciphertext, 0, ciphertext.Length);

                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var resultStream = new MemoryStream())
                {
                    using (var aesStream = new CryptoStream(resultStream, decryptor, CryptoStreamMode.Write))
                    using (var plainStream = new MemoryStream(ciphertext))
                    {
                        plainStream.CopyTo(aesStream);
                    }

                    return Encoding.UTF8.GetString(resultStream.ToArray());
                }
            }
        }
        /// <summary>
        /// Encriptación básica
        /// </summary>
        /// <param name="textToEncrypt"></param>
        /// <returns></returns>
        public static string BasicEncript(string textToEncrypt)
        {
            byte[] bytes = Encoding.GetEncoding(_encoding).GetBytes(textToEncrypt);
            return System.Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Des encriptación básica
        /// </summary>
        /// <param name="textToDecrypt"></param>
        /// <returns></returns>
        public static string BasicDecript(string textToDecrypt)
        {
            return Encoding.GetEncoding(_encoding).GetString(Convert.FromBase64String(textToDecrypt));
        }
    }
}
