using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField]
    TMP_Text settingText;

    bool isMuted = false;
    public void CheckSound()
    {
        isMuted = !isMuted;
        
        if (isMuted)
        {
            settingText.text = "Sound Off";
            settingText.color = Color.red;
        }
        else
        {
            settingText.text = "Sound On";
            settingText.color = Color.green;
        }
    }

    public void PlayBlockHitSound()
    {
        
        audioSource.mute = isMuted;
        if (audioSource.mute == false)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
  


}
