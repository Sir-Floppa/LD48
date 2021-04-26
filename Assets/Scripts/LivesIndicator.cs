using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesIndicator : MonoBehaviour
{
    public Text livesText;
    public GameObject player;
    public int lifes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifes = player.GetComponent<PlayerController>().lives;
        if (lifes == 3)
        {
            livesText.text = "    "; 
        }
        else if (lifes == 2)
        {
            livesText.text = "   ";
        }
        else if (lifes == 1)
        {
            livesText.text = "  ";
        }
        else
        {
            livesText.text = "";
        }
    }
}
