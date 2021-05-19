using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCharacter : MonoBehaviour
{
    bool isRotating;
    float target_angle = 35;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, target_angle, 0), 0.05f);
            if( Mathf.Abs( transform.rotation.eulerAngles.y - target_angle) < 2)
            {
                isRotating = false;
            }
        }
    }

    public void StartRotation()
    {
        if(target_angle == 35)
        {
            target_angle = 215;
        }
        else if(target_angle == 215)
        {
            target_angle = 35;
        }
        isRotating = true;
    }
}
