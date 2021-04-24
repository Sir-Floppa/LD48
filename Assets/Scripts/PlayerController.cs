using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement;
    public GameObject ground;

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
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        movement.direction = new Vector3(HorizontalInput, VerticalInput, 0);
    }

    private void FixedUpdate()
    {
        // w  a  l  k
        movement.Walk();
    }
}
