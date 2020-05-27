using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    private FadeIOManager fadeManager;
    private CanvasGroup dialogCanvas;

    [SerializeField]
    private GameObject playerUI;


    PlayerManager Player        => PlayerManager.instance;
    PlayerUIManager PlayerUI    => PlayerUIManager.instance;
    SoundManager SoundManager   => SoundManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        playerUI.transform.localPosition = new Vector3(-300, -300, 0);

        PlayerUI.SetupUI(Player);

        // ダイアログが非表示になっていたら表示させておく.
        fadeManager = GameObject.Find("FadeCanvas").GetComponent<FadeIOManager>();
        fadeManager.dialogWindow.SetActive(true);
        dialogCanvas = fadeManager.dialogWindow.GetComponent<CanvasGroup>();
        dialogCanvas.ignoreParentGroups = true;
        
        DialogTextManager.instance.SetScenarios(new string[] { "町についた" });
    }

    public void OnClickToQuestButton()
    {
        SoundManager.PlayButtonSE(0);
    }
}
