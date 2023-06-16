using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroyText : MonoBehaviour
{

    public float timer = 0.5f;
    void OnEnable()
    {
        timer = 0.5f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        {
            if(timer <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
