using DAL.Enum;

namespace Services
{
    public class CreateAppUserRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Position Position { get; set; }
    }
}