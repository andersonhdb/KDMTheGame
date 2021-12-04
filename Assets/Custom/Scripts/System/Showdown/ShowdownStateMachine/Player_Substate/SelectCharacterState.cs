using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterState : ShowdownState
{
    [SerializeField]
    private MovingSurvivorState _nextState;
    //ShowdownState feed;

    [SerializeField]
    private SurvivorMovement[] _survivors;

    [SerializeField]
    private CameraNav _cam;

    [SerializeField]
    private SurvivorSelection _characterSelect;

    private bool[] _survivorCanGo = new bool[4];

    private void Awake()
    {
        AllowSurvivorsMovements();
    }

    private void OnEnable()
    {
        Input_Manager.Clear();
        _characterSelect.gameObject.SetActive(true);
        Input_Manager.LeftButton.AddListener(_characterSelect.UpAction);
        Input_Manager.RightButton.AddListener(_characterSelect.DownAction);
        Input_Manager.SelectButton.AddListener(_characterSelect.Select);
    }

    private void Update()
    {

    }

    private void OnDisable()
    {
        Input_Manager.Clear();
    }

    public void ToCharacterMovement(int survivorIndex)
    {
        if (_survivorCanGo[survivorIndex])
        {
            _survivors[survivorIndex].GetLantern().NormalLight();
            _survivors[survivorIndex].GetLantern().SetRange(_survivors[survivorIndex].GetMaxMovement());
            _nextState.SetSurvivor(_survivors[survivorIndex]);
            _cam.TransitionTo(survivorIndex + 1);
            ShowDownStateRunner.ToState<MovingSurvivorState>();
            _survivorCanGo[survivorIndex] = false;
        }
        //feed = new MovingSurvivorState(survivor.GetComponent<SurvivorMovement>());
    }

    public SurvivorMovement[] GetSurvivors()
    {
        return _survivors;
    }

    public bool SurvivorCanGo(int survivorIndex)
    {
        return _survivorCanGo[survivorIndex];
    }

    public void AllowSurvivorsMovements()
    {
        for (int i = 0; i < _survivorCanGo.Length; i++)
        {
            _survivorCanGo[i] = true;
        }
    }
}
