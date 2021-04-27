using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OrbInteractable))]
public class DoorController : MonoBehaviour
{
    OrbInteractable interactable;
    public float timeIlluminated = 0;
    public Sprite openDoor;
    public GameObject lens;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        interactable = lens.GetComponent<OrbInteractable>();
        if (interactable.Illuminated)
        {
            timeIlluminated += Time.deltaTime;
        }
        else
        {
            timeIlluminated = 0;
        }

        if (timeIlluminated > 1.5f)
        {
            GetComponentInChildren<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = openDoor;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
