using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameInterface : MonoBehaviour
{
    private int _catchablesLeft;
    private int _pickedCatchables;
    
    [SerializeField]
    private TextMeshProUGUI _catchablesLeftText;
    [SerializeField]
    private TextMeshProUGUI _pickedCatchablesText;

    private Dictionary<string, int> _removedCatchables;

    private void Start()
    {
        var animalSpawner = FindFirstObjectByType<CatchablesSpawner>();
        _catchablesLeft = animalSpawner.CatchablesToSpawnCount;
        _pickedCatchables = 0;
        _catchablesLeftText.text = _catchablesLeft.ToString();
        _pickedCatchablesText.text = _pickedCatchables.ToString();
    }
    
    public void ReceiveCatchEvent(PlayerCatchEventArgs value)
    {
        if (value.IsCaught)
        {
            _pickedCatchables++;
        }
        _catchablesLeft--;
        
        _pickedCatchablesText.text = _pickedCatchables.ToString(); 
        _catchablesLeftText.text = _catchablesLeft.ToString();
    }
}