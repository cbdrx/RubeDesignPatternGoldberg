using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiObserver : MonoObserver {

	/// <summary>
	/// This implements the receieve update function for the GUI.
    /// When the state is no longer init, we will blank the GUI out.
	/// </summary>
	/// <param name="theState">current state</param>
    public override void receiveUpdate(rubeState theState)
    {
        if(theState != rubeState.init)
        {
            gameObject.GetComponent<Text>().text = "";
        }
        
    }
}
