using System.Text;

namespace NeDersinV2.Extensions
{
    static public class ToSha256Extension
    {
        static public string ToSha256(this string str)
        {
            var sb = new StringBuilder();
            using (var hash = System.Security.Cryptography.SHA256.Create())
            {
                var result = hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                for (int i = 0; i < result.Length; i++)
                    sb.Append(result[i].ToString("x2"));
            }
            return sb.ToString();

        }

        static public string ToSha256(this int integer) => integer.ToString().ToSha256();
        
    }
}
