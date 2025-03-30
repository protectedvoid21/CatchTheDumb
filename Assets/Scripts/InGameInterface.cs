using System.Collections;
using TMPro;
using UnityEngine;

public class InGameInterface : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _catchablesLeftText;
    [SerializeField]
    private TextMeshProUGUI _timerText;
    [SerializeField]
    private int _gameDurationInSeconds;
    
    private void Start()
    {
        var catchablePool = FindFirstObjectByType<CatchablePool>();
        _catchablesLeftText.text = catchablePool.RemainingCatchablesCount.ToString();
        
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        while (_gameDurationInSeconds > 0)
        {
            _gameDurationInSeconds--;
            _timerText.text = _gameDurationInSeconds.ToString();
            yield return new WaitForSeconds(1);
        }
        GameManager.Instance.FinishGame();
    }
    
    public void UpdateCatchableCountUI(int catchablesLeft)
    {
        _catchablesLeftText.text = catchablesLeft.ToString();
    }
}