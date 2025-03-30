using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Level[] Levels { get; private set; }
    
    private void Start()
    {
        var json = Resources.Load<TextAsset>("levels");
        Levels = JsonUtility.FromJson<LevelMetadata>(json.text).Levels;
    }
}

public class LevelMetadata
{
    public Level[] Levels;
}