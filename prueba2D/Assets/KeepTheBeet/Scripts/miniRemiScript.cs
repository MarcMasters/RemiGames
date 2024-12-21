using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniRemiScript : MonoBehaviour
{
    Animator anim;
    private KTBLogicScript logic;
    private Rigidbody2D rb;
    [SerializeField] private float jumpStrength = 1f;
    private bool isGrounded;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();
    }

    void Update()
    {
        if (logic.checkScoreChanges())
        {
            rb.velocity = Vector2.up * jumpStrength;
        }
        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D()
    {
        isGrounded = false;
    }

}
