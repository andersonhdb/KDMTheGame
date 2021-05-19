using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private bool isOnCharacter;
    [SerializeField]
    private Transform backCameraPosition;
    [SerializeField]
    private Transform tacticalCameraPosition;
    private Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        isOnCharacter = false;
        gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnCharacter)
        {
            gameCamera.transform.position = backCameraPosition.position;
            gameCamera.transform.rotation = backCameraPosition.rotation;
        }
    }

    public void ToggleCameraPosition()
    {
        if (isOnCharacter)
        {
            gameCamera.transform.position = tacticalCameraPosition.position;
            gameCamera.transform.rotation = tacticalCameraPosition.rotation;
        }
        else
        {
            gameCamera.transform.position = backCameraPosition.position;
            gameCamera.transform.rotation = backCameraPosition.rotation;
        }
        isOnCharacter = !isOnCharacter;
    }
}
