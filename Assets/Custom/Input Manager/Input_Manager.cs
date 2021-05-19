using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Input_Manager : MonoBehaviour {

    public static UnityEvent UpButton = new UnityEvent();
    public static UnityEvent DownButton = new UnityEvent();
    public static UnityEvent LeftButton = new UnityEvent();
    public static UnityEvent RightButton = new UnityEvent();
    
    
    public static UnityEvent SelectButton = new UnityEvent();
    public static UnityEvent CancelButton = new UnityEvent();
    public static UnityEvent PauseButton = new UnityEvent();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical")>0)
        {
            //_upButton.Execute();
            UpButton.Invoke();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            //_downButton.Execute();
            DownButton.Invoke();
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            //_rightButton.Execute();
            RightButton.Invoke();
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            //_leftButton.Execute();
            LeftButton.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //_selectButton.Execute();
            SelectButton.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //_cancelButton.Execute();
            CancelButton.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //_pauseButton.Execute();
            PauseButton.Invoke();
        }
	}

    public static void Clear(){
        UpButton.RemoveAllListeners();
        DownButton.RemoveAllListeners();
        LeftButton.RemoveAllListeners();
        RightButton.RemoveAllListeners();
        SelectButton.RemoveAllListeners();
        CancelButton.RemoveAllListeners();
        PauseButton.RemoveAllListeners();
    }
}
