public interface IInteractable
{
    float MaxRange { get; }

    void Interact();
    void InRange();
    void NotInRange();
}
