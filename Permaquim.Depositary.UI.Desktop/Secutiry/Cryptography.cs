using System.Security.Cryptography;
using System.Text;

namespace Permaquim.Depositary.UI.Desktop.Secutiry
{
    internal static class Cryptography
    {
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
        internal static string HashNuevo(string str)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] bytes = Encoding.Default.GetBytes(str);
            byte[] encoded = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; i++)
                sb.Append(encoded[i].ToString("x2"));

            return sb.ToString();
        }
    }
}
