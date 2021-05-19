using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using commands;

public class NewGameState: Menu_Navigation_Actions, State
{
    private State actualState;
    private State Previous;

    private Input_Manager inputs;
    private CameraNav cam;

    private TextMesh[] itens = new TextMesh[3];
    private bool tutorialEnabled = false;
    private bool ironManEnabled = false;

    private Color unselectedColor = Color.white;
    private Color selectedColor = Color.yellow;

    private GameObject tutoSelectionStone;
    private GameObject ironManSelectionStone;

    public Material rock;
    public Material blood;

    public void Start()
    {
        GameObject[] its = new GameObject[3];

        Previous = GameObject.Find("MainMenuObject").GetComponent<MainMenu>();
        itens[0] = GameObject.Find("Header").GetComponent<TextMesh>();
        itens[1] = GameObject.Find("NoUndo").GetComponent<TextMesh>();
        itens[2] = GameObject.Find("Play").GetComponent<TextMesh>();
        inputs = GameObject.Find("Input Overseer").GetComponent<Input_Manager>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraNav>();

        for(int i=0; i<3; i++)
        {
            its[i] = itens[i].gameObject;
        }

        SetMenuItems(its);

        tutoSelectionStone = GameObject.Find("TutoBool");
        ironManSelectionStone = GameObject.Find("IronManBool");
    }

    public override void Cancel()
    {
        actualState = Previous;
        Exit();
    }

    public void Enter()
    {
        cam.TransitionTo(1);
        actualState = this;
        //inputs.SetUpButton(new MenuUp(this));
        //inputs.SetDownButton(new MenuDown(this));
        //inputs.SetSelectButton(new MenuSelect(this));
        //inputs.SetCancelButton(new MenuCancel(this));
        Input_Manager.UpButton.AddListener(this.UpAction);
        Input_Manager.DownButton.AddListener(this.DownAction);
        Input_Manager.SelectButton.AddListener(this.Select);
        Input_Manager.CancelButton.AddListener(this.Cancel);
        ResetIndex();

        HighlightElement(itens[GetCurrentIndex()].gameObject);
    }

    public void Exit()
    {
        //inputs.clearInput();
        Input_Manager.Clear();
        LeaveElement(itens[GetCurrentIndex()].gameObject);
    }

    public override void HighlightElement(GameObject toHighlight)
    {
        toHighlight.GetComponent<TextMesh>().color = selectedColor;
    }

    public override void LeaveElement(GameObject toLeave)
    {
        toLeave.GetComponent<TextMesh>().color = unselectedColor;
    }

    public State Run()
    {
        return actualState;
    }

    public override void Select()
    {
        int ind = GetCurrentIndex();
        switch (ind)
        {
            case 0:
                tutorialEnabled = !tutorialEnabled;
                if (tutorialEnabled)
                {
                    tutoSelectionStone.GetComponent<Renderer>().material =  blood;
                }
                else
                {
                    tutoSelectionStone.GetComponent<Renderer>().material = rock;
                }

                break;
            case 1:
                ironManEnabled = !ironManEnabled;
                if (ironManEnabled)
                {
                    ironManSelectionStone.GetComponent<Renderer>().material = blood;
                }
                else
                {
                    ironManSelectionStone.GetComponent<Renderer>().material = rock;
                }

                break;
            case 2:
                //Go to next Scene

                break;
            default:
                Debug.Log("Nex Game Menu Selection Exception: Selection Index Out of Bounds");
                break;
        }
    }
}
