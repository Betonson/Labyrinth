namespace RockAndRoll
{
    public interface IInteractable : IAction, IInitialisation
    {
        bool IsInteractable { get; }
    }
}