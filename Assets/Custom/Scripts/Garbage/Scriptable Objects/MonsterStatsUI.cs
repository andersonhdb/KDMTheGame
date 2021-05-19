using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatsUI : MonoBehaviour
{
    [SerializeField]
    private MonsterStats _monsterStats;
    [SerializeField]
    private Text _monsterToughnessUI;
    [SerializeField]
    private Text _monsterMovementUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _monsterToughnessUI.text = $"Toughness: {_monsterStats.Toughness}";
        _monsterMovementUI.text = $"Movement: {_monsterStats.Movement}";
    }
}
