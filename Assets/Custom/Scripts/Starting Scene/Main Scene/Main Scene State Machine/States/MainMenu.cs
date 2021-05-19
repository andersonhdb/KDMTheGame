using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using commands;
using UnityEngine.UI;

public class MainMenu : Menu_Navigation_Actions, State
{
    public State actualState;
    public State newGameState;
    private State loadGameState;
    private State optionsState;

    private TextMesh[] items = new TextMesh[4];
    private Color unselectedColor = Color.white;
    private Color selectedColor = Color.yellow;
    private Input_Manager inputs;
    private CameraNav cam;

    /*public MainMenu(Input_Manager inpu)
    {
        inp = inpu;
        inpu.clearInput();
        inpu.SetUpButton(new MenuUp(this));
        inpu.SetDownButton(new MenuDown(this));
        inpu.SetSelectButton(new MenuSelect(this));
    }*/

    public void Start()
    {
        actualState = this;
        newGameState = GameObject.Find("NewGameObject").GetComponent<NewGameState>();
        loadGameState = GameObject.Find("LoadGameObject").GetComponent<LoadGameState>();

        inputs = GameObject.Find("Input Overseer").GetComponent<Input_Manager>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraNav>();

        GameObject[] itns = new GameObject[4];
        items[0] = GameObject.Find("New Game").GetComponent<TextMesh>();
        items[1] = GameObject.Find("Load Game").GetComponent<TextMesh>();
        items[2] = GameObject.Find("Options").GetComponent<TextMesh>();
        items[3] = GameObject.Find("Exit").GetComponent<TextMesh>();
        for (int i=0; i<4; i++)
        {
            itns[i] = items[i].gameObject;
        }
        SetMenuItems(itns);
    }

    public override void HighlightElement(GameObject toHighlight)
    {
        toHighlight.GetComponent<TextMesh>().color = selectedColor;
    }

    public override void LeaveElement(GameObject toLeave)
    {
        toLeave.GetComponent<TextMesh>().color = unselectedColor;
    }

    public override void Select()
    {
        switch (GetCurrentIndex())
        {
            case 0:
                Exit();
                actualState = newGameState;
                break;

            case 1:
                Exit();
                actualState = loadGameState;
                break;

            case 2:

                break;

            case 3:

                break;

            default:
                Debug.Log("Main Menu index Exception: Index Out of Bounds");
                break;
        }
    }

    public State Run()
    {
        return actualState;
    }

    public void Enter()
    {
        actualState = this;
        cam.TransitionTo(0);
        //inputs.clearInput();
        //inputs.SetUpButton(new MenuUp(this));
        //inputs.SetDownButton(new MenuDown(this));
        //inputs.SetSelectButton(new MenuSelect(this));
        Input_Manager.Clear();
        Input_Manager.UpButton.AddListener(this.UpAction);
        Input_Manager.DownButton.AddListener(this.DownAction);
        Input_Manager.SelectButton.AddListener(this.Select);
        HighlightElement(items[GetCurrentIndex()].gameObject);
    }

    public void Exit()
    {
        //inputs.clearInput();
        Input_Manager.Clear();
        LeaveElement(items[GetCurrentIndex()].gameObject);
    }

    public override void Cancel()
    {
        
    }
}
