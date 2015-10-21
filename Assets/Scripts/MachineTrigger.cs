using UnityEngine;
using System.Collections;

/// <summary>
/// This monobehavior is the main way that different parts of the machine 
/// communicate with each other
/// </summary>
public class MachineTrigger : MonoBehaviour {
    /// <summary>
    /// This is the message sent to the machine manager when the trigger is
    /// activated
    /// </summary>
    [SerializeField]
    private triggerList messageToSend;
    /// <summary>
    /// this is the object that, upon collision, will cause the machienTrigger
    /// to notify the machine manager
    /// </summary>
    [SerializeField]
    private GameObject triggerTarget;

    /// <summary>
    /// the manager to send a message to
    /// </summary>
    private MachineManager theManager;  

    /// <summary>
    /// Whether or not the trigger has been triggered previously
    /// </summary>      
    private bool triggered;

    void Start()
    {
        theManager = MachineManager.Instance;            
        triggered = false;
    }   

    /// <summary>
    /// When the target enters the trigger area, the message is sent
    /// </summary>
    /// <param name="other">The object entering the trigger</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.Equals(triggerTarget) && !triggered)
        {
            triggered = true;
            theManager.receiveControl(messageToSend);
        }
    }
	
}
