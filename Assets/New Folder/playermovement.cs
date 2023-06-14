using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("forward");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("backward");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("right");
        }
    }
    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
