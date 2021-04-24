using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    public int speed = 200;
    public string lastDirection;
    public Vector3 direction;

    // Makes the player w a l k
    public void Walk()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        // Defines the animation of the character in function of his movement
        if (direction.x > 0)
        {
            /// Set the walking right animation        
            lastDirection = "Right";
        }
        else if (direction.x < 0)
        {
            /// Set the walking left animation
            lastDirection = "Left";
        }
        else if (direction.y > 0)
        {
            /// Set the walking up animation
            lastDirection = "Up";
        }
        else if (direction.y < 0)
        {
            /// Set the walking down animation
            lastDirection = "Down";
        }
        else
        {
            // Set the idle animation
            switch (lastDirection)
            {
                case "Right":
                    /// Set idle right animation
                    break;
                case "Left":
                    /// Set idle left animation
                    break;
                case "Up":
                    /// Set idle right animation
                    break;
                case "Down":
                    /// Set idle left animation
                    break;
            }
        }
    }
}
