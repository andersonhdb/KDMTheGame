using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _toFollow;
    [SerializeField]
    private Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _toFollow.position - Offset;    
    }
}
