using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public OrbInteractable interactable;
    public GameObject player;
    public GameObject end1;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<OrbInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
        
        if (interactable.Illuminated)
        {
            end1.SetActive(true);
        }
    }
}
