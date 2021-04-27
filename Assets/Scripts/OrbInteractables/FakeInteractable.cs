using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OrbInteractable))]
public class FakeInteractable : MonoBehaviour
{
    OrbInteractable interactable;
    public float timeIlluminated = 0;
    public Sprite openDoor;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<OrbInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.Illuminated)
        {
            timeIlluminated += Time.deltaTime;
        }
        else
        {
            timeIlluminated = 0;
        }

        if (timeIlluminated > 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
