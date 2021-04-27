using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OrbInteractable))]
public class ChargableObj : MonoBehaviour
{
    OrbInteractable interactable;

    public float TimeIlluminated = 0;
    public float FreezeTime = 0;
    public bool Freeze = false;

    public GameObject FreezeLoaderPrefab;
    public GameObject Canvas;
    GameObject LoaderInstance;
    Slider FreezeLoader;
    public Vector2 FollowOffset;
    public Color FreezeColorLoader;

    Image FillImage;
    Color LoaderDefaultColor;

    public Sprite SpriteToChange;
    public bool Changematerial;
    public Material MaterialTochange;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<OrbInteractable>();

        LoaderInstance = Instantiate(FreezeLoaderPrefab) as GameObject;
        LoaderInstance.transform.parent = Canvas.transform;

        FreezeLoader = LoaderInstance.GetComponent<Slider>();

        FreezeLoader.gameObject.SetActive(false);

        FillImage = FreezeLoader.fillRect.gameObject.GetComponent<Image>();
        LoaderDefaultColor = FillImage.color;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 ThisPosition = transform.position;
        Vector3 LoaderPosition = new Vector3(ThisPosition.x + FollowOffset.x, ThisPosition.y + FollowOffset.y, ThisPosition.z);
        FreezeLoader.transform.position = Camera.main.WorldToScreenPoint(LoaderPosition);
        if (interactable.Illuminated)
        {
            if (!Freeze)
            {
                TimeIlluminated += Time.deltaTime;
                FreezeLoader.value = TimeIlluminated / 1f;
            }
            FreezeLoader.gameObject.SetActive(true);
        }
        else
        {
            if (!Freeze)
            {
                TimeIlluminated = 0;
                FreezeLoader.value = TimeIlluminated / 1f;
            }
            FreezeLoader.gameObject.SetActive(false);
        }

        if (TimeIlluminated > 1f)
        {
            Freeze = true;
            
        }

        if (Freeze)
        {
            FillImage.color = FreezeColorLoader;
            SpriteRenderer SR;
            if (TryGetComponent<SpriteRenderer>(out SR))
            {
                SR.sprite = SpriteToChange;
            }
            if (Changematerial)
            {
                Renderer MR;

                if (TryGetComponent<Renderer>(out MR))
                {
                    MR.material = MaterialTochange;
                }
            }
        }
        else
        {
            FillImage.color = LoaderDefaultColor;
            SpriteRenderer SR;
            if (TryGetComponent<SpriteRenderer>(out SR))
            {
                SR.color = Color.white;
            }
        }
    }
}
