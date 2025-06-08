// Services/IAuthService.cs (crea este archivo primero)
public interface IAuthService
{
    bool IsAuthenticated { get; }
    string CurrentUser { get; }
    Task<bool> LoginAsync(string username, string password);
    void Logout();
}

// Services/AuthMockService.cs
public class AuthMockService : IAuthService
{
    public bool IsAuthenticated { get; private set; }
    public string CurrentUser { get; private set; } = "Invitado";

    public Task<bool> LoginAsync(string username, string password)
    {
        IsAuthenticated = true;
        CurrentUser = username;
        return Task.FromResult(true);
    }

    public void Logout()
    {
        IsAuthenticated = false;
        CurrentUser = "Invitado";
    }
}