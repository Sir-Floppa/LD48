using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float timeIlluminated = 0;
    public Sprite openDoor;
    public ChargableObj lens;

    bool ActivatedLens;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (lens.Freeze && !ActivatedLens)
        {
            ActivatedLens = true;
            GetComponentInChildren<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = openDoor;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        if(!lens.Freeze && ActivatedLens)
        {
            ActivatedLens = false;

        }
    }
}
