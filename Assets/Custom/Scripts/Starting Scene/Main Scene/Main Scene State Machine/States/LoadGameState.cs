using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using commands;

public class LoadGameState : Menu_Navigation_Actions, State {

    private State currentState;
    private State backState;
    private CameraNav cam;

    private Input_Manager inputs;


    public override void Cancel()
    {
        currentState = backState;
        Exit();
    }

    public void Enter()
    {
        currentState = this;
        cam.TransitionTo(2);
        Input_Manager.CancelButton.AddListener(this.Cancel);
        //inputs.SetCancelButton(new MenuCancel(this));
    }

    public void Exit()
    {
        Input_Manager.Clear();
        //inputs.clearInput();
    }

    public override void HighlightElement(GameObject toHighlight)
    {

    }

    public override void LeaveElement(GameObject toLeave)
    {
        
    }

    public State Run()
    {
        return currentState;
    }

    public override void Select()
    {
       
    }

    // Use this for initialization
    void Start () {

        currentState = this;
        backState = GameObject.Find("MainMenuObject").GetComponent<MainMenu>();
        inputs = GameObject.Find("Input Overseer").GetComponent<Input_Manager>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraNav>();

        GameObject[] items = new GameObject[1];
        SetMenuItems(items);
	}
}
