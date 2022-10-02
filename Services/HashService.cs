using System.Security.Cryptography;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace AuthApi.Services
{
    public class HashService
    {
        public static string Encode(string plainText)
        {
            try
            {
                byte[] encData_byte = new byte[plainText.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(plainText);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public static string Decode(string encoded)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encoded);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
