using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, IReadsInput
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void readInput()
    {
        // delegate array for nested windows


        readCancelInput();

    }

    private void readCancelInput()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            //!
            // Hide inventory window, set any bools
            //

            GameEventManager.current.onControllerChange(InputController.PLAYER);
        }
    }

}
