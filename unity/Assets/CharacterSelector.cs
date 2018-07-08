using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/**
 * This script implements the callback from the UI.
 * Its main role is to populate the set with
 * the charcaters for the game
 * 
 * @author Daniel J. Finnegan
 * @date July 2018
 */
public class CharacterSelector : MonoBehaviour {

    // So we can connect it in the editor
    [System.Serializable]
    public class CharacterSelectedEvent : UnityEvent<Button, bool>
    {}

    [System.Serializable]
    public class CalloutGeneratedEvent : UnityEvent<Text, string>
    {}

    #region Public variables
    public readonly string MORDRED = "pMordred";
    public readonly string MORGANA = "pMorgana";
    public readonly string ASSASSIN = "pAssassin";
    public readonly string OBERON = "pOberon";

    public readonly string MERLIN = "pMerlin";
    public readonly string PERCIVAL = "pPercival";

    public CharacterSelectedEvent OnCharacterSelected;
    public CalloutGeneratedEvent OnCalloutGenerated;
    #endregion

    #region Private variables
    private HashSet<string> characters;
    #endregion

    // Use this for initialization
    void Start () {
#if ANDROID
        Screen.fullscreen = false;
#endif
        characters = new HashSet<string>();
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
        // Check the name of the button and 
        // update the set as well as the button
        if (characters.Contains(button.name))
        {
            characters.Remove(button.name);
            OnCharacterSelected.Invoke(button, false);
        }
        else
        {
            characters.Add(button.name);
            OnCharacterSelected.Invoke(button, true);
        }
    }

    /**
     * This is the primary piece of logic
     * for the whole application.
     * It analyses the set of characters 
     * and generates an appropriate call out
     */
    public void GenerateCallout (Text calloutText)
    {
        string callout = "This is the new callout";
        OnCalloutGenerated.Invoke(calloutText, callout);
    }
}
