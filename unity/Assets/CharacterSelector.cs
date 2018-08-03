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
        string callout = "";

        // Create the preamble
        callout = "Ok: everybody close your eyes and put your fist into the table. ";
        callout += "Bad guys: that is ";

        // Go through the set and create the callout

        // First we look for bad guys
        int headCount = 0;
        if (characters.Contains(MORDRED))
        {
            callout += "MORDRED, ";
            headCount++;
        }
        if (characters.Contains(MORGANA))
        {
            callout += "MORGANA, ";
            headCount++;
        }

        if (characters.Contains(ASSASSIN) && characters.Contains(OBERON))
        {
            headCount++; // Oberon doesn't count in the callout
            callout += "and ASSASSIN, but not OBERON: ";
        }
        else if (characters.Contains(ASSASSIN))
        {
            headCount++;
            callout += "and ASSASSIN: ";
        }
        else if (characters.Contains(OBERON))
        {
            callout += "but not OBERON: ";
        }

        // Never any thumbs unless morgana and assassin are in the game
        if (characters.Contains(MORGANA) || characters.Contains(ASSASSIN) || characters.Contains(MORDRED))
        {
            callout += "raise your thumbs and open your eyes. ";
            callout += "There should only be " + headCount + " of you with your eyes open ";
            if (headCount > 1)
            {
                callout += "and " + headCount + " thumbs raised. \n\n";
            }
            else
            {
                callout += "and a single thumb raised. \n\n";
            }
            

            callout += "Thats enough time. ";
            callout += "Everyone close your eyes and lower your thumbs. ";
        }

        // Now check for good guys

        callout += "";
        headCount = 0;
        if (characters.Contains(MERLIN))
        {
            if (characters.Contains(MORGANA))
            {
                headCount++;
                callout += "Now, MORGANA, ";
                if (characters.Contains(ASSASSIN))
                {
                    headCount++;
                    if (characters.Contains(OBERON))
                    {
                        headCount++;
                        callout += "ASSASSIN, and OBERON only: ";
                    }
                    else
                    {
                        callout += "and ASSASSIN only: ";
                    }
                }
            }
            else if (characters.Contains(ASSASSIN))
            {
                headCount++;
                callout += "Now, ASSASSIN ";
                if (characters.Contains(OBERON))
                {
                    headCount++;
                    callout += "and OBERON only: ";
                }
                else
                {
                    callout += "only: ";
                }
            }
            else if (characters.Contains(OBERON))
            {
                headCount++;
                callout += "Now OBERON only; ";
            }

            if (characters.Contains(MORGANA) || characters.Contains(ASSASSIN) || characters.Contains(OBERON))
            {
                callout += "raise your thumb but keep your eyes closed. ";
                callout += "MERLIN: open your eyes. ";
                if (headCount > 1)
                {
                    callout += "You should see " + headCount + " thumbs raised but nobody else should have their eyes open.\n\n";
                }
                else
                {
                    callout += "You should see a single thumb raised but nobody else should have their eyes open.\n\n";
                }


                callout += "Thats enough time. ";
                callout += "Everyone: close your eyes and lower your thumbs.\n\n";
            }
        }

        headCount = 0;
        if (characters.Contains(PERCIVAL))
        {
            if (characters.Contains(MERLIN) && characters.Contains(MORGANA))
            {
                headCount = 2;
                callout += "Now; MORGANA and MERLIN only: ";
            }
            else if (characters.Contains(MERLIN))
            {
                headCount = 1;
                callout += "Now; MERLIN only: ";
            }
            else if (characters.Contains(MORGANA))
            {
                headCount = 1;
                callout += "Now; MORGANA only: ";
            }

            if (characters.Contains(MERLIN) || characters.Contains(MORGANA))
            {
                callout += "Keep your eyes closed, but raise your thumbs. ";
                callout += "PERCIVAL: open your eyes! ";
                if (headCount > 1)
                {
                    callout += "You should see " + headCount + " thumbs raised";                    
                }
                else
                {
                    callout += "You should see a single thumb raised";
                }

            }

            if (characters.Contains(MERLIN) && characters.Contains(MORGANA))
            {
                callout += ", one of which belongs to MERLIN. The other belongs to MORGANA. ";
            }
            else if (characters.Contains(MERLIN))
            {
                callout += ": it belongs to MERLIN. ";
            }
            else if (characters.Contains(MORGANA))
            {
                callout += ": it belongs to MORGANA. ";
            }

            if (characters.Contains(MERLIN) || characters.Contains(MORGANA))
            {
                callout += "Nobody else should have their eyes open.\n\n";
                callout += "Thats enough time. ";                
            }
        }

        callout += "Everyone: keeping your eyes closed, retract your fists from the table. ";
        callout += "Now open your eyes.";

        // Trigger the UI updater script
        OnCalloutGenerated.Invoke(calloutText, callout);
    }

    public void ResetCharacterSet()
    {
        characters = new HashSet<string>();
    }
}
