using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGage : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private Image sliderImage;

    private float currentValue;
    private float maxValue;
    private float coValue;

    PlayerManager Player => PlayerManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
    }

    public void SetHPBar(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Player":
                currentValue = Player.Hp;
                maxValue = Player.MaxHP;

                slider.value = currentValue;
                slider.maxValue = maxValue;

                sliderImage.GetComponent<Image>().fillAmount = currentValue / maxValue;

                GageChangeColor();

                break;

            case "Enemy":
            case "Boss":

                break;

            default:
                Debug.Log("いずれにも属していない");
                break;
        }
    }

    public void UpdateHPBar(GameObject obj)
    {

    }

    private void GageChangeColor()
    {
        if(currentValue < maxValue / 4)
        {
            sliderImage.color = Color.red;
        }
        else if(currentValue <= (maxValue / 2))
        {
            sliderImage.color = Color.yellow;
        }
        else if(currentValue >= (maxValue / 4 * 3))
        {
            sliderImage.color = Color.cyan;
        }
        else
        {
            sliderImage.color = Color.green;
        }
    }
}
