using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    private Text myText;

    private void Awake()
    {
        myText = this.GetComponentInChildren<Text>();
    }

    public void setText(string newText)
    {
        myText.text = newText;
    }
}
