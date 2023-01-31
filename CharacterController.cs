using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 500f;
    public Rigidbody2D _rigidBody2D;
    public Animator _animator;

    private bool grounded;
    bool started;
    bool jumping;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        grounded = true;

    }
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            if (started && grounded)
            {
                _animator.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                started = true;
            }
        }
       
            _animator.SetBool("Grounded", grounded);
    }
    void FixedUpdate()
    {
        if (started)
        {
            _rigidBody2D.velocity = new Vector2(speed, _rigidBody2D.velocity.y);
        }
        if (jumping)
        {
            _rigidBody2D.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}