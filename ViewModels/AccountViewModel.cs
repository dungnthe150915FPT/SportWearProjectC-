namespace SportWearManage.ViewModels
{
    public class AccountViewModel
    {
        public AccountViewModel() { }

        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Fullname { get; set; }
        public bool? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public int? IsAdmin { get; set; }
    }
}
