using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioSource audioSource;
    
    public AudioClip ghostNormalAudio;

    // Start is called before the first frame update
    void Start()
    {
        // introduction music play
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // ghosts normal state play
        if (!audioSource.isPlaying)
        {
            audioSource.clip = ghostNormalAudio;
            audioSource.Play();
        }
    }
}
