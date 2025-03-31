using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    [SerializeField, Min(0)]
    private float _speed;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Animator _animator;

    private InputAction _moveAction;

    private void Awake()
    {
        var inputSystemActions = new InputSystemActions();
        _moveAction = inputSystemActions.Player.Move;
        _moveAction.Enable();
        
        if (_animator == null)
        {
            Debug.LogError("Animator component is not assigned to the PlayerMovement script on " + gameObject.name);
            enabled = false;
        }
    }

    public void OnDestroy()
    {
        _moveAction.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = _moveAction.ReadValue<Vector2>();
        transform.Translate(movement * (_speed * Time.deltaTime));
        
        if (movement != Vector2.zero)
        {
            _animator.SetBool(IsMoving, true);
            _spriteRenderer.flipX = movement.x < 0;
        }
        else
        {
            _animator.SetBool(IsMoving, false);
        }
    }
}