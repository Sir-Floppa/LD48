using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 2;
    public Vector3 direction;

    // Makes the player w a l k
    public void Walk()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        // Defines the animation of the character in function of his movement
        if (direction.x > 0)
        {
            /// Set the walking right animation
        }
        else if (direction.x < 0)
        {
            /// Set the walking left animation
        }
        else if (direction.y > 0)
        {
            /// Set the walking up animation
        }
        else if (direction.y < 0)
        {
            /// Set the walking down animation
        }
        else
        {
            // Set the idle animation
        }
    }
}
