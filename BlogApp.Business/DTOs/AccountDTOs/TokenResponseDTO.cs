namespace BlogApp.Business.DTOs.AccountDTOs
{
    public class TokenResponseDTO
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}