using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCast : MonoBehaviour
{
    [Range(0, 1)]
    public float RadioOrb = 1;
    public LayerMask layers;

    public List<Light> OrbLights;

    bool LightingOrb = false;

    public List<OrbInteractable> illuminatedObjects;

    void LightsEnabled(bool enable)
    {
        LightingOrb = enable;
        foreach(Light item in OrbLights)
        {
            item.enabled = enable;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LightsEnabled(false);
        illuminatedObjects = new List<OrbInteractable>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            LightsEnabled(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            LightsEnabled(false);
        }

        List<OrbInteractable> newIlluminated = new List<OrbInteractable>();
        if (LightingOrb)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(MousePos.x, MousePos.y, transform.position.z);

            RaycastHit2D[] hit2D = Physics2D.CircleCastAll(transform.position, RadioOrb, Vector2.zero, 0, layers.value);
            
            foreach (RaycastHit2D hit in hit2D)
            {

                GameObject GO = hit.collider.gameObject;
                OrbInteractable interactable;
                if(GO.TryGetComponent<OrbInteractable>(out interactable)){
                    interactable.Illuminated = true;
                    newIlluminated.Add(interactable);
                }
                //Debug.Log(GO.name);
            }
        }

        foreach(OrbInteractable item in illuminatedObjects)
        {
            int index = newIlluminated.FindIndex(x => x=item);
            if(index == -1)
            {
                item.Illuminated = false;
            }
        }

        illuminatedObjects = newIlluminated;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RadioOrb);
    }
}
