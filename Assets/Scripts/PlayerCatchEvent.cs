public class PlayerCatchEvent
{
    public string AnimalName { get; }
    public bool IsCaught { get; }
    
    public PlayerCatchEvent(string animalName, bool isCaught)
    {
        AnimalName = animalName;
        IsCaught = isCaught;
    }
}