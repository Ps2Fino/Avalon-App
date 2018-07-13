using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/**
 * Thin layer over the TTS plugin
 */
public class Speaker : MonoBehaviour {
    
    private TextToSpeech tts;

    void Start()
    {
        tts = GetComponent<TextToSpeech>();
    }

    /**
     * Handler for a speech event
     */
    public void GenerateSpeech (Text textUIComponent, string textToSay)
    {
        tts.Speak(textToSay, (string msg) =>
        {
            tts.ShowToast(msg);
        });
    }

    public void StopSpeech()
    {
        tts.StopSpeaking();
    }
}
