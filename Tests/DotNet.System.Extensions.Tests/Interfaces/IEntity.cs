namespace DotNet.System.Extensions.Tests.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}