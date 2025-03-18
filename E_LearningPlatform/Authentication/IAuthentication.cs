using System.Threading.Tasks;

namespace E_LearningPlatform.Authentication
{
    public interface IAuthentication
    {
        string Authenticate(string Email, string password);
    }
}