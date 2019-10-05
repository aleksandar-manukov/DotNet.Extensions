using System.ComponentModel.DataAnnotations;

namespace DotNet.System.Extensions.Tests.Models
{
    public class User
    {
        [Display(Name = "User first name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}