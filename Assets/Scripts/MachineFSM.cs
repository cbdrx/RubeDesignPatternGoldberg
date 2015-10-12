using UnityEngine;
using System.Collections;


/// <summary>
/// This enumeration will be kept fully public so that it can be referenced
/// globally by other scripts.
/// </summary>
public enum rubeState
{
    init = 0,
    dominoStart,
    
}

public enum triggerList
{
    started = 0,
    ballFell,

}

public class MachineFSM : MonoBehaviour {

    private rubeState currentState;

	// Use this for initialization
	void Start () 
    {
        currentState = rubeState.init;

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public rubeState getState()
    {
        return currentState;
    }

    public void handleTrigger(triggerList message)
    {
        switch (currentState)
        {
            case (rubeState.init):
            {
                switch(message)
                {
                    case triggerList.started:
                    {
                        break;
                    }
                    case triggerList.ballFell:
                    {
                        currentState = rubeState.dominoStart;
                        break;
                    }
                }
                break;
            }
            
        }
    }
}
