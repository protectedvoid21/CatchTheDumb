using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerCatchHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Catchable"))
        {
            return;
        }
        
        print("Caught an object!");
        string catchableName = collision.gameObject.name;
        Destroy(collision.gameObject);
        
        GameManager.Instance.CatchCatchable();
    }
}