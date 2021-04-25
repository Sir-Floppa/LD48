using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public Animator anim;

    public float speed = 2.25f;
    public float timer = 0;
    public float freezeTime = 2f;
    public bool freeze;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player and sets the moving animation for the enemy
        if (target != null && !freeze)
        {
            transform.Translate((target.transform.position - transform.position) * speed * Time.deltaTime);
        }

        // Sets the order in layer in function of the player's position
        if (player.transform.position.y < transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }

        if (freeze)
        {
            timer += Time.deltaTime;
            if (timer >= freezeTime)
            {
                freeze = false;
                timer = 0;
            }
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
        }

        // Freeze with the light
        if (collision.gameObject.tag == "Orb" && !freeze && timer < 3)
        {
            freeze = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Finds the player and targets him
        if (collision.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}
