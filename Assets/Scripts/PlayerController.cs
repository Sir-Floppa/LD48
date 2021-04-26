using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement;
    public Animator anim;
    public AudioSource harp;
    public AudioSource strings;
    public Light selfLight;

    public float HorizontalInput;
    public float VerticalInput;
    public bool casting = false;
    public bool dead = false;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        selfLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Defines the direction of the player's movement
        if (!casting && !dead)
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
            selfLight.enabled = true;
        }
        if (Input.GetKeyUp("mouse 0"))
        {
            //strings.Stop();
            StopAllCoroutines();
            StartCoroutine(FadeSound(false));
            selfLight.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        // w  a  l  k
        if (!casting && (HorizontalInput != 0 || VerticalInput != 0))
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
        else if (HorizontalInput > 0)
        { 
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public float fadeTime = 0.3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !collision.gameObject.GetComponent<EnemyController>().freeze)
        {
            lives--;
            if (lives > 0)
            {
                anim.SetTrigger("Hit");
                GetComponent<Rigidbody2D>().AddForce(225 * new Vector2(transform.position.x - collision.gameObject.transform.position.x, transform.position.y - collision.gameObject.transform.position.y), ForceMode2D.Impulse);
            }
            else
            {
                anim.SetTrigger("Death");
                dead = true;
            }
        }
    }

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
