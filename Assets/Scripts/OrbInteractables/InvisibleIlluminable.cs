using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OrbInteractable))]

public class InvisibleIlluminable : MonoBehaviour
{
    OrbInteractable interactable;
    bool illuminatedSetted = false;

    SpriteRenderer SR;

    void Illuminated()
    {
        illuminatedSetted = true;
        StopAllCoroutines();
        StartCoroutine(FadeInAlpha(1));
        
    }

    void unilluminated()
    {
        illuminatedSetted = false;
        StopAllCoroutines();
        StartCoroutine(FadeOutAlpha(0));
    }
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<OrbInteractable>();
        SR = GetComponent<SpriteRenderer>();

        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0);


    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.Illuminated && !illuminatedSetted)
        {
            Illuminated();
        }
        if(!interactable.Illuminated && illuminatedSetted)
        {
            unilluminated();
        }
    }

    public float FadeInTime = 0.3f;
    public float FadeOutTime = 0.3f;

    IEnumerator FadeInAlpha(float target)
    {
        
        float actualAlpha = SR.color.a;

        float FadeTime = FadeInTime;


        float t = 0;
        while(SR.color.a < target)
        {
            float NewAlpha = Mathf.Lerp(actualAlpha, target, t);
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, NewAlpha);
            yield return null;
            t += Time.deltaTime / FadeTime;
        }
        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, target);

    }
    IEnumerator FadeOutAlpha(float target)
    {

        float actualAlpha = SR.color.a;

        float FadeTime = FadeOutTime;


        float t = 0;
        while (SR.color.a > target)
        {
            float NewAlpha = Mathf.Lerp(actualAlpha, target, t);
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, NewAlpha);
            yield return null;
            t += Time.deltaTime / FadeTime;
        }
        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, target);

    }
}
