using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OrbInteractable))]
public class FreezeInteract : MonoBehaviour
{
    OrbInteractable interactable;

    public float TimeIlluminated = 0;


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
            TimeIlluminated += Time.deltaTime;
        }
        else
        {
            TimeIlluminated = 0;
        }

        if(TimeIlluminated > 2)
        {
            SpriteRenderer SR;
            if(TryGetComponent<SpriteRenderer>(out SR))
            {
                SR.color = Color.cyan;
            }
        }
    }
}
