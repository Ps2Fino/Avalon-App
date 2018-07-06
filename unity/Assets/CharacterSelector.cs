using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {

    #region Public variables
    public readonly string MORDRED = "Mordred";
    public readonly string MORGANA = "Morgana";
    public readonly string ASSASSIN = "Assassin";
    public readonly string OBERON = "Oberon";
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * Just listen to the UI and print the
     * name of the button that was clicked
     */
    public void CharacterSelected (Button button)
    {
        if (button.name == MORDRED)
        {
            Debug.Log("Mordred selected");
        }
        else if (button.name == MORGANA)
        {
            Debug.Log("Morgana selected");
        }
        else if (button.name == ASSASSIN)
        {
            Debug.Log("Assassin selected");
        }
        else if (button.name == OBERON)
        {
            Debug.Log("Oberon selected");
        }
    }
}
