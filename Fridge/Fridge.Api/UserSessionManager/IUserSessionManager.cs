using Fridge.Data.Data;

namespace Fridge.Api.UserSessionManager
{
    public interface IUserSessionManager
    {
        IFridgeData Data { get; }

        void CreateUserSession(string username, string accessToken);

        bool ValidateUserSession();

        void RemoveUserSession();

        void RemoveExpiredSessions();
    }
}