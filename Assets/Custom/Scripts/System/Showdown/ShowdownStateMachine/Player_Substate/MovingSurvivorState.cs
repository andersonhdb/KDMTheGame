using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSurvivorState : ShowdownState
{
    [SerializeField]
    private Input_Manager iM;
    [SerializeField]
    private SurvivorMovement _sm;
    [SerializeField]
    private CameraNav _cam;

    private void OnEnable()
    {

        if (_sm == null)
        {
            Debug.Log("Go back to selectState");
            ShowDownStateRunner.ToState<SelectCharacterState>();
        }

        if (iM == null)
        {
            iM = GameObject.Find("Input Manager").GetComponent<Input_Manager>();
        }

        //iM.clearInput();
        //iM.SetUpButton(new SurvivorMoveForward(sm));
        //iM.SetDownButton(new SurvivorMoveBackward(sm));
        //iM.SetRightButton(new SurvivorTurnRight(sm));
        //iM.SetLeftButton(new SurvivorTurnLeft(sm));
        //iM.SetCancelButton(new MovingSurvivorBackCommand(this));
        Input_Manager.Clear();
        Input_Manager.UpButton.AddListener(_sm.MoveForward);
        Input_Manager.DownButton.AddListener(_sm.MoveBackward);
        Input_Manager.RightButton.AddListener(_sm.TurnRight);
        Input_Manager.LeftButton.AddListener(_sm.TurnLeft);
        Input_Manager.CancelButton.AddListener(Exit);

        _sm.ResetMovement();
        _sm.SetTemplateVisibility(true);
    }

    public void Exit()
    {
        //iM.clearInput();
        Input_Manager.Clear();
        _sm.SetTemplateVisibility(false);
        _sm.GetLantern().SetRange(_sm.GetMaxMovement());
        _cam.TransitionTo(0);
        ShowDownStateRunner.ToState<SelectCharacterState>();
    }

    private void Update()
    {

    }

    public void SetSurvivor(SurvivorMovement survivor)
    {
        _sm = survivor;
    }

    public void Back()
    {
        Exit();
    }


}
