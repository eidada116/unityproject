using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapanimations : MonoBehaviour
{
    public Animator anim;
    public playermovement playerMovement;
    public int trapDamage;
    // Start is called before the first frame update
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            anim.SetBool("isActive", true);
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isActive", false);
        }
    }

    public void PlayerDamage()
    {
        playerMovement.HPCounter = playerMovement.HPCounter - trapDamage;
    }

   


}
