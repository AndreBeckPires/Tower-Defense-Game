using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonColor : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;

    public float value;

    void Start()
    {
        button = GetComponent<Button>();
      
        // button.onClick.AddListener(ChangeColor);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("poor");
        button.interactable = false;
    }
}