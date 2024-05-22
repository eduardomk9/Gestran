namespace Core.Dtos.User
{
    public class MemberOfDto
    {
        public int Id { get; set; }
        public int IdMeof { get; set; }
        public string Name { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
    }
}
