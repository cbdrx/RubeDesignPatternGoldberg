using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// This enumeration will be kept fully public so that it can be referenced
/// globally by other scripts.
/// </summary>
public enum rubeState
{
    init = 0,
    started,
    dominoStart,
    catapultFired,
    wallDestroyed,
    buttonPressed,
    moveCameraToFinalPos,
    targetDestroyed   
}

/// <summary>
/// triggerList enumerates the "inputs" to the FSM, namely, the actions that
/// can occur that cause the machine to transition.
/// </summary>
public enum triggerList
{
    started = 0,
    ballFell,
    catapultStart,
    wallDestroyed,
    buttonPressed,
    finalCameraPos,
    targetHit
}

public class MachineFSM : MonoBehaviour {

    
    private IState currentState;
    private Dictionary<rubeState, IState> stateList =
        new Dictionary<rubeState, IState>();

	// Use this for initialization
	void Awake () 
    {
        stateList.Add(rubeState.init, new InitState());
        stateList.Add(rubeState.started, new StartedState());
        stateList.Add(rubeState.dominoStart, new DominoState());
        stateList.Add(rubeState.catapultFired, new CatapultFired());
        stateList.Add(rubeState.wallDestroyed, new WallDestroyed());
        stateList.Add(rubeState.buttonPressed, new ButtonPresed());
        stateList.Add(rubeState.moveCameraToFinalPos, new FinalCameraPos());
        stateList.Add(rubeState.targetDestroyed, new TargetDestroyed());
        
        currentState = stateList[rubeState.init];

	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log("Current State: " + currentState.toEnum().ToString());
	}

    public rubeState getState()
    {
        return currentState.toEnum();
    }

    public void handleTrigger(triggerList message)
    {
        currentState = stateList[currentState.transition(message)];
    }
    
    private interface IState
    {
        rubeState toEnum();

        rubeState transition(triggerList message);
    }

    private class InitState : IState
    {
        public rubeState toEnum()
        {
            return rubeState.init;
        }

        public rubeState transition(triggerList message)
        {
            if (message == triggerList.started)
            {
                return rubeState.started;
            }

            return rubeState.init;
        }
    }

    private class StartedState : IState
    {
        public rubeState toEnum()
        {
            return rubeState.started;
        }

        public rubeState transition(triggerList message)
        {
            if(message == triggerList.ballFell)
            {
                return rubeState.dominoStart;
            }

            return rubeState.started;
        }
    }

    private class DominoState : IState
    {
        public rubeState toEnum()
        {
            return rubeState.dominoStart;
        }

        public rubeState transition(triggerList message)
        {
            if (message == triggerList.catapultStart)
            {
                return rubeState.catapultFired;
            }

            return rubeState.dominoStart;
        }
    }

    private class CatapultFired : IState
    {
        public rubeState toEnum()
        {
            return rubeState.catapultFired;
        }

        public rubeState transition(triggerList message)
        {
            if (message == triggerList.wallDestroyed)
            {
                return rubeState.wallDestroyed;
            }

            return rubeState.catapultFired;
        }
    }

    private class WallDestroyed : IState
    {
        public rubeState toEnum()
        {
            return rubeState.wallDestroyed;
        }
        
        public rubeState transition(triggerList message)
        {
            if(message == triggerList.buttonPressed)
            {
                return rubeState.buttonPressed;
            }

            return rubeState.wallDestroyed;
        }
    }

    public class ButtonPresed : IState
    {
        public rubeState toEnum()
        {
            return rubeState.buttonPressed;
        }

        public rubeState transition(triggerList message)
        {
            if(message == triggerList.finalCameraPos)
            {
                return rubeState.moveCameraToFinalPos;
            }

            return rubeState.buttonPressed;
        }
    }
    public class FinalCameraPos : IState
    {
        public rubeState toEnum()
        {
            return rubeState.moveCameraToFinalPos;
        }

        public rubeState transition(triggerList message)
        {
            if(message == triggerList.targetHit)
            {
                return rubeState.targetDestroyed;
            }
            return this.toEnum();
        }
    }

    public class TargetDestroyed : IState
    {
        public rubeState toEnum()
        {
            return rubeState.targetDestroyed;
        }

        public rubeState transition(triggerList message)
        {
            return this.toEnum();
        }
    }
    
}

