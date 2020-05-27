using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceBGM;
    public AudioClip[] audioClipsBGM;

    public AudioSource audioSourceSE;
    public AudioClip[] audioClipsSE;

    #region Singleton
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PlayBGM(string caseName)
    {
        audioSourceBGM.Stop();

        switch (caseName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
                
            case "Town":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
                
            case "Quest":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;
                
            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
                
            case "BossBattle":
                audioSourceBGM.clip = audioClipsBGM[4];
                break;
        }

        audioSourceBGM.Play();
    }

    public void PlayButtonSE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}
