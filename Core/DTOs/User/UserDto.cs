

using Core.Dtos.Auth;

namespace Core.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? JobTitle { get; set; }

        public string Login { get; set; } = null!;
        public string Mail { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Photo { get; set; }
        public string? ConnectionId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public AuthDto Auth { get; set; } = new AuthDto();
        public List<MemberOfDto> MemberOf { get; set; } = new List<MemberOfDto>();
    }
}
