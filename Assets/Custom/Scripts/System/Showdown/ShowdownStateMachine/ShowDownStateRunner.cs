using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDownStateRunner : MonoBehaviour
{

    [SerializeField]
    private static ShowdownState _currentState;

    private static Dictionary<Type, ShowdownState> _stateList;

    [SerializeField]
    private GameObject[] _survivors;

    private void Awake()
    {
        _stateList = new Dictionary<Type, ShowdownState>();
        foreach (var state in GetComponentsInChildren<ShowdownState>(true))
        {
            state.gameObject.SetActive(false);
            var type = state.GetType();
            _stateList.Add(type, state);
        }
        ToState<SelectCharacterState>();
    }

    private void OnEnable()
    {

    }

    public static void ToState<T>() where T : ShowdownState
    {
        if (_currentState != null)
        {
            _currentState.gameObject.SetActive(false);
        }

        Type type = typeof(T);
        _currentState = _stateList[type];
        _currentState.gameObject.SetActive(true);
    }
}
