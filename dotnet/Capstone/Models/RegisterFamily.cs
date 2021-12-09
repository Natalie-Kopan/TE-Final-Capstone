namespace Capstone.Models
{
    /// <summary>
    /// Model to accept registration parameters
    /// </summary>
    public class RegisterFamily
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }                                                                                                                                                                                                                          
        public string Role { get; set; }
    }
}
