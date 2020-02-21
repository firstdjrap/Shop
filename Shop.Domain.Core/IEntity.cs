namespace Shop.Domain.Core
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }
}