using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCustomizationMenuStateRunner : MonoBehaviour
{
    private State currentState;
    private State previousState;

    private bool firstloop = true;

    // Use this for initialization
    void Start()
    {
        currentState = GameObject.Find("Main Menu").GetComponent<CharacterCustomizationMainMenu>();
        previousState = currentState;
    }

    // Update is called once per frame
    void Update()
    {

        if (firstloop)
        {
            firstloop = false;
            currentState.Enter();
        }

        currentState = currentState.Run();
        if (currentState != previousState)
        {
            previousState = currentState;
            currentState.Enter();
        }
    }
}
