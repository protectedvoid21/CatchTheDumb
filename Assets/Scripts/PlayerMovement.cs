using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    [SerializeField, Min(0)]
    private float _speed;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private AudioClip _walkingSound;
    private AudioSource _audioSource;
    

    private InputAction _moveAction;

    private void Awake()
    {
        var inputSystemActions = new InputSystemActions();
        _moveAction = inputSystemActions.Player.Move;
        _moveAction.Enable();
        
        _audioSource = GetComponent<AudioSource>();
        
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
            
            if (!_audioSource.isPlaying)
            {
                _audioSource.clip = _walkingSound;
                _audioSource.loop = true;
                _audioSource.Play();
            }
        }
        else
        {
            _animator.SetBool(IsMoving, false);
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }
    }
}