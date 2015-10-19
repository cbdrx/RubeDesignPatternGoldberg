using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiObserver : MonoObserver {

	// Use this for initialization
    public override void receiveUpdate(rubeState theState)
    {
        if(theState != rubeState.init)
        {
            gameObject.GetComponent<Text>().text = "";
        }
        
    }
}
