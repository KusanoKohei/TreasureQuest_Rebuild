using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class FadeIOManager : MonoBehaviour
{
    public float fadeTime = 1.0f;

    #region Singleton
    public static FadeIOManager instance;

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

    public CanvasGroup canvasGroup;

    public GameObject dialogWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, fadeTime)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, fadeTime)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeOutToIn(TweenCallback action)
    {
        canvasGroup.blocksRaycasts = true;

        canvasGroup.DOFade(1, fadeTime)
            .OnComplete(() =>
            {
                action();
                FadeIn();
            });
    }
}
