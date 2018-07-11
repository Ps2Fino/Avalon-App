# Avalon-App

I really like the game [Avalon](https://boardgamegeek.com/boardgame/128882/resistance-avalon).
I mean, REALLY like it!
I play it as often as I can.

However, sometimes the callout can be tricky to remember as the game grows: for example, games with Merlin, Percival and Oberon for example.
This application automates the callout.
The goal is to have an application where players can choose which characters are active in the game, and then the app will generate a sound clip of the callout and then play it.
For the moment, the app uses a TTS plugin for the speech output.

This project is [Updater](https://github.com/Ps2Fino/Updater) compatible.

# Dependencies
As of v03-alpha, the android version uses [Hosein Porazar's Andoid TTS Plugin](https://github.com/HoseinPorazar/Android-Native-TTS-plugin-for-Unity-3d/tree/Modified) for text-to-speech conversion of the callout.
I will implement a functionality to stop the speech when I get a chance, but for now this is a working prototype.
I had to unzip the aar and add just the compiled java classes (luckily there was no jni funny business to tackle).
I've placed a [packaged binary](https://github.com/Ps2Fino/Avalon-App/releases/tag/v0.2.1-android-alpha) in the releases.

@author Daniel J. Finnegan  
@date July 2018
