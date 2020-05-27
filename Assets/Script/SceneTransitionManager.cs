using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    #region Singleton
    public static SceneTransitionManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    SoundManager SoundManager => SoundManager.instance;
    FadeIOManager FadeIOManager => FadeIOManager.instance;

    public void LoadTo(string sceneName)
    {
        FadeIOManager.FadeOutToIn(() => Load(sceneName));
    }

    public void Load(string sceneName)
    {
        SoundManager.PlayBGM(sceneName);
        SceneManager.LoadScene(sceneName);
    }

}
