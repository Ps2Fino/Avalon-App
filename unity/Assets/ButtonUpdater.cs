using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This script keeps track of each buttons
 * color and changes it depending on whether
 * the character is selected or not
 * 
 * @author Daniel J. Finnegan
 * @date July 2018
 */
public class ButtonUpdater : MonoBehaviour {

    /**
     * Simply change the color of the button
     */
    public void UpdateButton (Button button, bool selected)
    {
        ColorBlock buttonColors = button.GetComponent<Button>().colors;
        if (selected)
        {
            buttonColors.normalColor = Color.red;
            buttonColors.highlightedColor = Color.red;
        }                     
        else
        {
            buttonColors.normalColor = Color.white;
            buttonColors.highlightedColor = Color.white;
        }           

        button.colors = buttonColors;
    }

    /**
     * Just update the callout text field
     */
    public void UpdateCalloutText(Text calloutTextField, string textToInsert)
    {
        calloutTextField.text = textToInsert;
    }
}
