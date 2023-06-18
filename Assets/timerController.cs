using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerController : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
       if (pauseMenu.activeSelf)
       {
           Time.timeScale = 0f;
       }
    }
}
