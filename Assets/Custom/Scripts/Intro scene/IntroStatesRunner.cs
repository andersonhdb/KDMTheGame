using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStatesRunner : MonoBehaviour
{
    [SerializeField]
    private static IntroState _currentState;

    private static Dictionary<Type, IntroState> _stateList;

    [SerializeField]
    private GameObject[] _survivors;

    private void Awake()
    {
        _stateList = new Dictionary<Type, IntroState>();
        foreach (var state in GetComponentsInChildren<IntroState>(true))
        {
            state.gameObject.SetActive(false);
            var type = state.GetType();
            _stateList.Add(type, state);
        }
    }

    private void OnEnable()
    {
        ToState<IntroStartState>();
    }

    public static void ToState<T>() where T : IntroState
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
