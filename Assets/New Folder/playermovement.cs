using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using TMPro;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    //move ut move it
    private float baseMoveSpeed;

    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    public int trapdamage;
    public TextMeshProUGUI healthPoints, coincounter;
    public int HPCounter;
    public int healthPowerupsValue;
    public int speedPowerupsValue;
    public int speedDuration;

    

    public int coinCounter;
    void Start()
    {

        baseMoveSpeed = moveSpeed;
        GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("forward");
        //}
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("backward");
        //}
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("left");
        //}
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("right");
        //}
        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    anim.enabled = false;
        //}
        //if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    anim.enabled = false;
        //}
        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    anim.enabled = false;
        //}
        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    anim.enabled = false;
        //}

        healthPoints.text = HPCounter.ToString();
        coincounter.text = coinCounter.ToString();

        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coinCounter++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Health"))
        {
            HPCounter += healthPowerupsValue;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Speed"))
        {
            moveSpeed += speedPowerupsValue;
            Destroy(collision.gameObject);
            StartCoroutine(returnToBaseSpeed());
        }
    }

    IEnumerator returnToBaseSpeed()
    {
        yield return new WaitForSeconds(speedDuration);
        moveSpeed = baseMoveSpeed;
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
