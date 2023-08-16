using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] AudioSource[] sfxChannel;
    public void PlaySfx(AudioClip clip) { 
        for (int i = 0; i < sfxChannel.Length; i++) { 
            if (sfxChannel[i] == null)
            {
                sfxChannel[i].clip = clip;
                sfxChannel[i].Play();
                StartCoroutine(CleanAudioChannel(clip.length, i));
                break;            
            }
        }
    
    }

    IEnumerator CleanAudioChannel(float length, int channel) {
        yield return new WaitForSeconds(length);
        sfxChannel[channel].clip = null;

    }

}
