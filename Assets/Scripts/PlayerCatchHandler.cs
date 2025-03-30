using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerCatchHandler : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private static readonly int IsCatching = Animator.StringToHash("IsCatching");
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Catchable"))
        {
            return;
        }
        
        Destroy(collision.gameObject);
        _animator.SetTrigger(IsCatching);
        
        GameManager.Instance.CatchCatchable();
    }
}