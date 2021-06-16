using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Stats")]
public class MonsterStats : ScriptableObject
{
    [SerializeField]
    private int _toughness = 6;
    public int Toughness => _toughness;

    [SerializeField]
    private int _movement = 6;
    public int Movement => _movement;

    //Tokens:



    //functions
    public void SetToughness(int toughness)
    {
        _toughness = toughness;
    }

    public void SetMovement(int movement)
    {
        _movement = movement;
    }




}
