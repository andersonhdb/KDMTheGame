using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface State{

    State Run();
    void Enter();
    void Exit();
	
}
