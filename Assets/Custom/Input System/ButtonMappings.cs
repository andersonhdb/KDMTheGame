using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyBindings")]
public class ButtonMappings : ScriptableObject
{
    public enum Keys { UP,DOWN,LEFT,RIGHT,SELECT,CANCEL,START,ESCAPE}

    [SerializeField]
    private KeyCode _upKey;
    [SerializeField]
    private KeyCode _downKey;
    [SerializeField]
    private KeyCode _leftKey;
    [SerializeField]
    private KeyCode _rightKey;
    [SerializeField]
    private KeyCode _selectKey;
    [SerializeField]
    private KeyCode _cancelKey;
    [SerializeField]
    private KeyCode _StartKey;
    [SerializeField]
    private KeyCode _EnterKey;

    private Dictionary<Keys, KeyCode> _keyBidings = new Dictionary<Keys, KeyCode>
    {
        {Keys.UP,KeyCode.UpArrow},
        {Keys.DOWN,KeyCode.DownArrow},
        {Keys.LEFT,KeyCode.LeftArrow},
        {Keys.RIGHT,KeyCode.RightArrow},
        {Keys.SELECT,KeyCode.Z},
        {Keys.CANCEL,KeyCode.X},
        {Keys.START,KeyCode.Return},
        {Keys.ESCAPE,KeyCode.Escape},
    };

    public Dictionary<Keys, KeyCode> KeyBindings => _keyBidings;
}
