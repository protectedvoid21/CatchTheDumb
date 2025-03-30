using System;
using UnityEngine;

public class PlayerCatchHandler : MonoBehaviour
{
    private IObserver<object> _observable;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Animal"))
        {
            return;
        }
        
        print("Caught an animal!");
        Destroy(collision.gameObject);
    }
}