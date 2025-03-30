using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0)]
    private float _speed;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    
    private InputAction _moveAction;

    private void Awake()
    {
        var inputSystemActions = new InputSystemActions();
        _moveAction = inputSystemActions.Player.Move;
        _moveAction.Enable();
    }
    
    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        Vector2 movement = _moveAction.ReadValue<Vector2>();
        transform.Translate(movement * (_speed * Time.deltaTime));

        if (movement.x != 0)
        {
            _spriteRenderer.flipX = movement.x < 0;
        }
    }
}