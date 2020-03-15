using System;
using System.Collections.Generic;
using UnityEngine;

public enum InputController
{
    MENU,
    PLAYER,
    INVENTORY,
    DESCRIPTION,
}

public class ControllerManager : MonoBehaviour
{
    public Component[] controllerComponents_temp = new Component[System.Enum.GetNames(typeof(InputController)).Length];  //helps serialize interfaces

    private IReadsInput[] controllers;
    private int currentController = 1;


    // normal game controls, inventory controls, description box controls,

    private void Awake()
    {
        GameEventManager.current.onControllerChangeTrigger += onControllerChangeEvent;


    }
    // Start is called before the first frame update
    void Start()
    {
        controllers = new IReadsInput[controllerComponents_temp.Length];
        for (int i = 0; i < controllerComponents_temp.Length; i++)
        {
            controllers[i] = controllerComponents_temp[i] as IReadsInput;
        }
    }

    // Update is called once per frame
    void Update()
    {
        controllers[currentController].readInput();
    }


    // METHODS
    private void onControllerChangeEvent(InputController nextController)
    {
        currentController = (int)nextController;

        Debug.Log("Changed controller to: " + System.Enum.GetName(typeof(InputController), nextController));
    }



}
