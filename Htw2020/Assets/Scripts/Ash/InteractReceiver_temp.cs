using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractReceiver_temp : MonoBehaviour
{
    private List<string> inventory_temp = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //add oninteractaddtoinventory to list of subscribed methods when event is triggered
        GameEvents_temp.current.onInteractTrigger += OnInteractAddToInventory;
        Debug.Log("Subscribed the method");
       
    }

    private void OnInteractAddToInventory()
    {
        inventory_temp.Add("new item");
        printInventory();
    }

    private void printInventory()
    {
        string message = "";

        foreach (string s in inventory_temp)
        {
            message += (s + ", ");
        }

        Debug.Log(message);
    }
}
