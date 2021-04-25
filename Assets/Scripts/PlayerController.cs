using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement;
    public GameObject ground;
    public Animator anim;

    public float HorizontalInput;
    public float VerticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Defines the direction of the player's movement
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        movement.direction = new Vector3(HorizontalInput, VerticalInput, 0);

        // Set the orb animation
        if (Input.GetKey("mouse 0"))
        {
            anim.SetBool("Orb", true);
        }
        else
        {
            anim.SetBool("Orb", false);
        }
    }

    private void FixedUpdate()
    {
        // w  a  l  k
        movement.Walk();
        anim.SetFloat("HorizontalInput", HorizontalInput);
        anim.SetFloat("VerticalInput", VerticalInput);
        if (HorizontalInput != 0 || VerticalInput != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (HorizontalInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
