using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject dialogWindow;
    private CanvasGroup dialogCanvas;

    PlayerManager Player => PlayerManager.instance;
    SoundManager SoundManager => SoundManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        // ダイアログウィンドウを非表示にしておく.
        dialogCanvas = dialogWindow.GetComponent<CanvasGroup>();
        dialogCanvas.ignoreParentGroups = false;
        dialogWindow.SetActive(false);
    }

    public void OnClickNewGameButoon()
    {
        Player.Level = 5;
        Player.Init_PlayerParameter();

        SoundManager.PlayButtonSE(0);
    }
}
