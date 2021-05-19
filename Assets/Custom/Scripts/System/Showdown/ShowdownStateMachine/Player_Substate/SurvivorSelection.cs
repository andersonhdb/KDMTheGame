using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorSelection : Menu_Navigation_Actions
{
    [SerializeField]
    private SelectCharacterState _currentState;

    private void OnEnable()
    {
        SurvivorMovement[] survivors = _currentState.GetSurvivors();
        GameObject[] lanternObjects = new GameObject[survivors.Length];
        for (int i = 0; i < survivors.Length; i++)
        {
            lanternObjects[i] = survivors[i].GetLantern().gameObject;
        }
        SetMenuItems(lanternObjects);
        HighlightElement(lanternObjects[0]);
    }

    public override void Cancel()
    {
        //End Player Turn
    }

    public override void HighlightElement(GameObject toHighlight)
    {
        if (_currentState.SurvivorCanGo(currentIndex))
        {
            toHighlight.GetComponent<Lantern>().HoveringLight();
        }
        else
        {
            toHighlight.GetComponent<Lantern>().UnavailableLight();
        }
    }

    public override void LeaveElement(GameObject toLeave)
    {
        toLeave.GetComponent<Lantern>().NormalLight();
    }

    public override void Select()
    {
        _currentState.ToCharacterMovement(currentIndex);
    }
}
