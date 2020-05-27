using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject toTownButton;
    public GameObject stageClearImage;


    #region Singleton
    public static StageUIManager instance;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateUI(int currentStage)
    {
        stageText.text = string.Format("ステージ：{0} / 10", currentStage + 1);
    }

    public void ButtonUIAppearance(bool isTrue)
    {
        stageClearImage.SetActive(false);
        nextButton.SetActive(isTrue);
        toTownButton.SetActive(isTrue);
    }
    public void ClearUIAppearance()
    {
        stageClearImage.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }
}
