using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public SOInt SeedsSO => _seedsSO;
    public SOInt CarrotsSO => _carrotsSO;

    [Header("Components")]
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Interactor _interactor;
    [SerializeField] private AudioSource _interactAudio;

    [Header("Stats")]
    [SerializeField] private float _moveSpeed = 10f;

    [Header("Inventory")]
    [SerializeField] private SOInt _seedsSO;
    [SerializeField] private SOInt _carrotsSO;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _inputReader.InteractEvent += OnInteract;

        _seedsSO.Value = 3;
        _carrotsSO.Value = 0;
    }

    private void FixedUpdate()
    {
        Vector2 movement = _inputReader.MovementValue;

        if (movement != Vector2.zero)
        {
            _interactor.transform.position = (Vector2)transform.position + movement;
        }

        _rigidbody2D.velocity = movement.normalized * _moveSpeed;

        // Graphics v1
        // if (movement.x > 0)
        // {
        //     transform.rotation = Quaternion.Euler(0, 0, 0);
        // }
        // else if (movement.x < 0)
        // {
        //     transform.rotation = Quaternion.Euler(0, 180, 0);
        // }
        //  _animator.SetFloat("MovementBlend", movement.magnitude);

        // Graphics v2
        _animator.SetFloat("MoveBlendX", movement.x);
        _animator.SetFloat("MoveBlendY", movement.y);
    }

    private void OnInteract()
    {
        if (_interactor.Interaction == null) return;

        _interactAudio.Play();
        _interactor.Interaction.Interact();
    }
}