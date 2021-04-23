using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    private ButtonMappings _buttonMap;

    public Dictionary<ButtonMappings.Keys, UnityEvent> KeyEvents;
    // Start is called before the first frame update
    private void OnEnable()
    {
        KeyEvents = new Dictionary<ButtonMappings.Keys, UnityEvent>();
        foreach(KeyValuePair<ButtonMappings.Keys, KeyCode> keyBinding in _buttonMap.KeyBindings)
        {
            KeyEvents.Add(keyBinding.Key, new UnityEvent());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<ButtonMappings.Keys, KeyCode> keyBinding in _buttonMap.KeyBindings)
        {
            if (Input.GetKey(keyBinding.Value))
            {
                KeyEvents[keyBinding.Key].Invoke();
            }
        }
    }

    public void ClearInput()
    {
        foreach(KeyValuePair<ButtonMappings.Keys, UnityEvent> inputEvent in KeyEvents)
        {
            inputEvent.Value.RemoveAllListeners();
        }
    }
}
