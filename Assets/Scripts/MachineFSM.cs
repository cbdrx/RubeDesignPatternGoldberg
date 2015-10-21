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

    /// <summary>
    /// This stores the current state of the machine
    /// </summary>
    private IState currentState;

    /// <summary>
    /// Maps rubeStates to an IState object
    /// </summary>
    private Dictionary<rubeState, IState> stateList =
        new Dictionary<rubeState, IState>();

	// Initializes the stateList
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
	
	/* Update is called once per frame
	void Update () 
    {
        Debug.Log("Current State: " + currentState.toEnum().ToString());
	}*/

    /// <summary>
    /// Acessor for the current state
    /// </summary>
    /// <returns>The rubeState representing the current state</returns>
    public rubeState getState()
    {
        return currentState.toEnum();
    }

    /// <summary>
    /// Handles input sent from the controller by using the state's
    /// transition function.
    /// </summary>
    /// <param name="message">the trigger that the FSM should respond to
    /// </param>
    public void handleTrigger(triggerList message)
    {
        currentState = stateList[currentState.transition(message)];
    }
    
    /// <summary>
    /// Interface for implementing the state classes. Each state's valid 
    /// transitions are implemented in the transition function.
    /// </summary>
    private interface IState
    {
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum representing the state</returns>
        rubeState toEnum();

        /// <summary>
        /// Handles the input and returns the enum representing the state to 
        /// transition to
        /// </summary>
        /// <param name="message">The trigger the state should respond to
        /// </param>
        /// <returns>The rubeState enum that represents the state a valid 
        /// transition leads to, OR the enum representing the current state
        /// on an invalid transition.</returns>
        rubeState transition(triggerList message);
    }

    private class InitState : IState
    {
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum rubeState.init</returns>
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
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum rubeState.started</returns>
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
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum rubeState.dominoStart</returns>
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
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum rubeState.catapultFired</returns>
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
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum rubeState.wallDestroyed</returns>
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
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum rubeState.buttonPressed</returns>
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
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum rubeState.moveCameraToFinalPos</returns>
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
        /// <summary>
        /// Returns the enum representing the state
        /// </summary>
        /// <returns>the enum rubeState.targetDestroyed</returns>
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

