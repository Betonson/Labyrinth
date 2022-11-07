namespace Asteroids
{
    public interface IInteractable : IUpdatable
    {
        bool IsInteractable { get; set; }
    }
}