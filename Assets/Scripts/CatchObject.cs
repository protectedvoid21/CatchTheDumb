using UnityEngine;

public class CatchObject : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [HideInInspector]
    public Transform DestinationHole;
    
    private void Awake()
    {
        gameObject.tag = "Catchable";
    }
    
    private void Update()
    {
        MoveTowardsHole();
    }
        
    private void MoveTowardsHole()
    {
        Vector2 direction = DestinationHole.position - transform.position;
        transform.Translate(direction.normalized * (_speed * Time.deltaTime));
        
        if (Vector2.Distance(transform.position, DestinationHole.position) < 0.1f)
        {
            GameManager.Instance.CatchCatchable(new PlayerCatchEventArgs(name, false));
            Destroy(gameObject);
        }
    }
}