using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EAssetT<T>
{
    public event Action<T> OnValueChange;
    [SerializeField]
    protected T _value;
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueChange.Invoke(_value);
        }
    }

    public void EventClear()
    {
        if (OnValueChange.GetInvocationList().Length > 0)
        {
            OnValueChange = null;
        }
    }
}
