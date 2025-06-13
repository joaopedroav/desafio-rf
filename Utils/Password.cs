using System.Text;

namespace DesafioTechSub.Utils
{
    public class Password
    {
        public static string ConvertPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }
    }
}
