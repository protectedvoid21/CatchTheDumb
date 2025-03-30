using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [HideInInspector]
    public Transform DestinationHole;

    private void Awake()
    {
        gameObject.tag = "Animal";
    }
    
    private void Update()
    {
        MoveTowardsHole();
    }
        
    private void MoveTowardsHole()
    {
        Vector2 direction = DestinationHole.position - transform.position;
        transform.Translate(direction.normalized * (_speed * Time.deltaTime));
    }
}