using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OrbInteractable))]
public class FreezeInteract : MonoBehaviour
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
            TimeIlluminated += Time.deltaTime;
            FreezeLoader.gameObject.SetActive(true);
            FreezeLoader.value = TimeIlluminated / 1f;
        }
        else
        {
            TimeIlluminated = 0;
            FreezeLoader.gameObject.SetActive(false);
            FreezeLoader.value = TimeIlluminated / 1f;
        }

        if(TimeIlluminated > 1f)
        {
            Freeze = true;
            FillImage.color = FreezeColorLoader;
        }
        else
        {
            FillImage.color = LoaderDefaultColor;
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
