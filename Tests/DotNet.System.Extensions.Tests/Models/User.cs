using System.ComponentModel.DataAnnotations;
using DotNet.System.Extensions.Tests.Interfaces;

namespace DotNet.System.Extensions.Tests.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        [Display(Name = "User first name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}