namespace Opslagsværk_API.DTOs.UserDTOs
{
    public class AuthenticateUserDTO
    {
        public string Username { get; set; }

        public string Hashed_password { get; set; }
    }
}
