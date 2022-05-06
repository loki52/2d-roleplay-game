using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Clip", menuName = "AudioSystem/AudioClip")]
public class Sound : ScriptableObject
{
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    
    [Range (.1f, 3f)]
    public float pitch; 

    [HideInInspector]
    public AudioSource source;

}
