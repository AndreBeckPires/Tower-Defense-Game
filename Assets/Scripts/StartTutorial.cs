using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class StartTutorial : MonoBehaviour
{
    public GameObject ui;
    public GameObject pause;
    public TMP_Text TMPText;
    [TextArea(3, 10)]
    public string HOVERTEXT;
    // Start is called before the first frame update
    void Start()
    {
        TMPText.text = HOVERTEXT;
    }

    // Update is called once per frame
    public void close()
    {
        ui.SetActive(false);
    }

    void Update()
    {
        if (ui.activeSelf && !pause.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else if(!ui.activeSelf && !pause.activeSelf)
        {
            Time.timeScale = 1.0f;
        }
    }
}
