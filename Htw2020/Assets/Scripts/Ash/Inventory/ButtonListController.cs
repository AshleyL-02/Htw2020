using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListController : MonoBehaviour
{
    public GameObject buttonPrefab;  //! load from Resources/Prefabs

    private void Awake()
    {
        //set self inactive


        for(int i =0; i<= 20; i++)
        {
            GameObject button = Instantiate(buttonPrefab as GameObject);
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().setText("Button: " + i);

            button.transform.SetParent(buttonPrefab.transform.parent, false);  //what does this do?
        }
        
    }

}
