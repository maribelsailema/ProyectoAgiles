

namespace Proyecto.client.Services
{
    public class AuthMockService
    {
        public bool IsAuthenticated { get; private set; }
        public string CurrentUser { get; private set; } = "Invitado";
        public string UserRole { get; private set; } = "Docente"; // Rol por defecto para pruebas

        public Task<bool> LoginAsync(string username, string password)
        {
            // Simulamos un login exitoso con cualquier credencial
            IsAuthenticated = true;
            CurrentUser = username;

            // Asignamos un rol basado en el usuario (simulación)
            UserRole = username.Contains("admin") ? "Administrador" : "Docente";

            return Task.FromResult(true); // Siempre retorna éxito
        }

        public void Logout()
        {
            IsAuthenticated = false;
            CurrentUser = "Invitado";
            UserRole = string.Empty;
        }

        // Método para simular verificación de roles
        public bool IsInRole(string role)
        {
            return UserRole == role;
        }
    }
}
