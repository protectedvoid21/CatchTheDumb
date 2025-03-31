using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level")]
public class Level : ScriptableObject
{
    public int Number;
    public int CatchableCount;
    public int TimeLimit;
    public int SpawnInterval;
    public int CatchableSpeed;
    [CanBeNull] 
    public Level NextLevel;
}
