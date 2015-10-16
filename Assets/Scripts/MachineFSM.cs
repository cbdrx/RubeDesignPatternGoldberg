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
    dominoStart,
    catapultFired,

    
}

public enum triggerList
{
    started = 0,
    ballFell,
    catapultStart,

}

public class MachineFSM : MonoBehaviour {

    
    private IState currentState;
    private Dictionary<rubeState, IState> stateList =
        new Dictionary<rubeState, IState>();

	// Use this for initialization
	void Awake () 
    {
        stateList.Add(rubeState.init, new InitState());
        stateList.Add(rubeState.dominoStart, new DominoState());
        stateList.Add(rubeState.catapultFired, new CatapultFired());
        
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
            if(message == triggerList.ballFell)
            {
                return rubeState.dominoStart;
            }

            return rubeState.init;
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
            if (message == triggerList.catapultStart)
            {
                return rubeState.catapultFired;
            }

            return rubeState.catapultFired;
        }
    }

}

