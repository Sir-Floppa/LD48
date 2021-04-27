using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    public List<ChargableObj> Eagles;

    public GameObject Door;

    public bool enableSomthing;
    public GameObject EnabableObj;


    bool CheckEaglesCharged()
    {
        foreach(ChargableObj item in Eagles)
        {
            if (!item.Freeze)
            {
                return false;
            }
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckEaglesCharged())
        {
            Door.SetActive(false);
            if (enableSomthing)
            {
                EnabableObj.SetActive(true);
            }
        }
        else
        {
            if (enableSomthing)
            {
                EnabableObj.SetActive(false);
            }
            Door.SetActive(true);
        }
    }
}
