using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class User
    {
        
        public enum UserRoles
        {
            Client,
            Specialist
        }
        
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required] public string Email { get; set; }
        public UserRoles UserRole { get; set; }
        
    }
}