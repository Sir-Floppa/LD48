using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement;
    public GameObject ground;
    public Animator anim;
    public AudioSource harp;
    public AudioSource strings;

    public float HorizontalInput;
    public float VerticalInput;
    public bool casting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Defines the direction of the player's movement
        if (!casting)
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");
        }
        movement.direction = new Vector3(HorizontalInput, VerticalInput, 0);

        // Set the orb animation
        if (Input.GetKey("mouse 0"))
        {
            anim.SetBool("Orb", true);
            casting = true;
        }
        else
        {
            anim.SetBool("Orb", false);
            casting = false;
        }
        
        if (Input.GetKeyDown("mouse 0"))
        {
            harp.Play();
            StopAllCoroutines();
            StartCoroutine(FadeSound(true));
        }
        if (Input.GetKeyUp("mouse 0"))
        {
            //strings.Stop();
            StopAllCoroutines();
            StartCoroutine(FadeSound(false));
        }
    }

    private void FixedUpdate()
    {
        // w  a  l  k
        if (!casting)
        {
            movement.Walk();
            anim.SetFloat("HorizontalInput", HorizontalInput);
            anim.SetFloat("VerticalInput", VerticalInput);
        }
        if (HorizontalInput != 0 || VerticalInput != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (HorizontalInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public float fadeTime = 0.3f;

    IEnumerator FadeSound(bool Fadein)
    {
        if (Fadein)
        {
            strings.Play();
        }
        float actualVolume = strings.volume;
        for(float t = 0; t < 1; t += Time.deltaTime / fadeTime)
        {
            float DesiredVolume = Fadein ? 1 : 0;
            float NewVolume = Mathf.Lerp(actualVolume, DesiredVolume, t);
            strings.volume = NewVolume;
            yield return null;
        }
        if (!Fadein)
        {
            strings.Stop();
        }
    }
}
