using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OrbInteractable))]
public class FreezeInteract : MonoBehaviour
{
    OrbInteractable interactable;

    public float TimeIlluminated = 0;
    public float FreezeTime = 0;
    public bool Freeze = false;


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

        if(TimeIlluminated > 1.5)
        {
            Freeze = true;
        }

        if (Freeze)
        {
            SpriteRenderer SR;
            if (TryGetComponent<SpriteRenderer>(out SR))
            {
                SR.color = Color.cyan;
            }
        }
        else
        {
            SpriteRenderer SR;
            if (TryGetComponent<SpriteRenderer>(out SR))
            {
                SR.color = Color.white;
            }
        }
    }
}
