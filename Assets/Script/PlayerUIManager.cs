using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    private Text hpText;
    [SerializeField]
    private Text levelText;

    [SerializeField]
    private GameObject hpGage;

    PlayerManager Player => PlayerManager.instance;

    #region Singleton
    public static PlayerUIManager instance;

    private void Awake()
    {
        if(instance == null)
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


    public void SetupUI(PlayerManager player)
    {
        GameObject obj = player.gameObject;
        hpGage.GetComponent<HPGage>().SetHPBar(obj);

        levelText.text = string.Format("LEVEL : {0}", player.Level);
        hpText.text = string.Format("HP : {0}", player.Hp);
    }

    public void UpdateUI(PlayerManager player)
    {
        GameObject obj = player.gameObject;
        hpGage.GetComponent<HPGage>().SetHPBar(obj);

        levelText.text = string.Format("LEVEL : {0}", player.Level);
        hpText.text = string.Format("HP : {0}", player.Hp);

        if(player.Hp <= 0)
        {
            // ToDeadPanel();
        }
    }

}
