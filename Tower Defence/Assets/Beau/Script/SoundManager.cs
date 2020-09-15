using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class AmbientSounds
    {
        public AudioSource backGroundMusic, ambientWind, ambientVogels;
    }
    [System.Serializable]
    public class PlayerVoiceLines
    {
        public AudioSource baseUnderAttackVoiceLine1, baseUnderAttackVoiceLine2, baseUnderAttackVoiceLine3;
    }

    public AmbientSounds ambientSounds;
    public PlayerVoiceLines playerVoiceLines;
}
