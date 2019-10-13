using DotNet.System.Extensions.Tests.Interfaces;

namespace DotNet.System.Extensions.Tests.Models.BaseModels
{
    public abstract class UserBaseModel : IUser
    {
        public int Id { get; set; }
    }
}