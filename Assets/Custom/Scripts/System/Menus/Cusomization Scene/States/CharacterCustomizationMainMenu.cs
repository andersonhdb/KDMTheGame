using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using commands;

public class CharacterCustomizationMainMenu : Menu_Navigation_Actions, State
{
    State currentState;
    [SerializeField]
    Text[] items = new Text[4];
    int currentCharacterIndex;
    //Input_Manager iM;

    State Keyboard;
    State backToMainMenu;

    [SerializeField]
    Toggle[] genderOptions =  new Toggle[2];
    [SerializeField]
    Transform pivot;
    bool isMale;

    private Color highlightColor = Color.yellow;
    private Color unselectedColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacterIndex = 0;
        //iM = GameObject.Find("Input Manager").GetComponent<Input_Manager>();
        GameObject[] itns = new GameObject[4];
        for(int i=0; i<4; i++)
        {
            itns[i] = items[i].gameObject;
        }
        SetMenuItems(itns);
    }

    public override void Cancel()
    {
        //prompt back to menu
        currentState = backToMainMenu;
    }

    public void Enter()
    {
        currentState = this;
        Input_Manager.Clear();
        Input_Manager.UpButton.AddListener(this.UpAction);
        Input_Manager.DownButton.AddListener(this.DownAction);
        Input_Manager.SelectButton.AddListener(this.Select);
        Input_Manager.CancelButton.AddListener(this.Cancel);
        // iM.clearInput();
        // iM.SetUpButton(new MenuUp(this));
        // iM.SetDownButton(new MenuDown(this));
        // iM.SetSelectButton(new MenuSelect(this));
        // iM.SetCancelButton(new MenuCancel(this));
        HighlightElement(items[GetCurrentIndex()].gameObject);

    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void HighlightElement(GameObject toHighlight)
    {
        toHighlight.GetComponent<Text>().color = highlightColor;
    }

    public override void LeaveElement(GameObject toLeave)
    {
        toLeave.GetComponent<Text>().color = unselectedColor;
    }

    public State Run()
    {
        return currentState;
    }

    public override void Select()
    {
        int index = GetCurrentIndex();
        switch (index)
        {
            case 0:
                //keyboard name
                break;
            case 1:
                //switch gender
                genderOptions[0].isOn = !genderOptions[0].isOn;
                genderOptions[1].isOn = !genderOptions[1].isOn;
                isMale = !isMale;
                pivot.GetComponent<PivotCharacter>().StartRotation();
                //rotate pivot 180 degrees
                break;
            case 2:
                //next character
                break;
            case 3:
                //to Showdown
                break;
            default:
                //error
                break;
        }
    }
}
