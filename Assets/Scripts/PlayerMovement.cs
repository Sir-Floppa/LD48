using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;
    public Vector3 direction;

    // Makes the player w a l k
    public void Walk()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
