public class PlayerCatchEventArgs
{
    public string CatchableName { get; }
    public bool IsCaught { get; }
    
    public PlayerCatchEventArgs(string catchableName, bool isCaught)
    {
        CatchableName = catchableName;
        IsCaught = isCaught;
    }
}