namespace RockAndRoll
{
    public interface IInteractable : IUpdatable
    {
        bool IsInteractable { get; set; }
    }
}