using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VirtualKeyboardController : MonoBehaviour
{
    [SerializeField]
    private VirtualKeyboardData _toOutput;

    private string _output;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        Output();
    }

    public void Output()
    {
        _toOutput.OutputString.Value = _output;
        _toOutput.OutputString.EventClear();
        _toOutput.OutputString.Value = "";
    }

    public void SetKeyBoardOutput(Action<string> outputCallback)
    {
        _toOutput.OutputString.OnValueChange += outputCallback;
    }
}
