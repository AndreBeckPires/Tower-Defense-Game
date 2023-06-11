using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverOverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
     public GameObject HoverPanel;
     public TMP_Text TMPText;
      public string HOVERTEXT;


 
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TMPText.text = HOVERTEXT;
        HoverPanel.SetActive(true);
    }


    public void OnPointerExit(PointerEventData pointerEventData)
    {

        HoverPanel.SetActive(false);
    }
}

