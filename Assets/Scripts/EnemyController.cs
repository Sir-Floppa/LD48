using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public Animator anim;
    public float speed = 2.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player and sets the moving animation for the enemy
        if (target != null)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
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
