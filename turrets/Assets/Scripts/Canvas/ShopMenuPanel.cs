using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ShopMenuPanel : MonoBehaviour
{
    RectTransform MyRect;
    [SerializeField] Ease ease;

    [SerializeField] Text slot1Text,slot2Text,slot3Text,coinText;
    CoinPanelController coinPanelController;
    // Start is called before the first frame update
    void Start()
    {
        MyRect = GetComponent<RectTransform>();
        MyRect.localScale = Vector3.zero;
        MyRect.DOScale(Vector3.one,1f).SetEase(ease).SetDelay(0.5f);
        coinPanelController = GameObject.FindObjectOfType<CoinPanelController>();

        PlayerPrefs.SetInt("Slot1",100);
        PlayerPrefs.SetInt("Slot2",100);
        PlayerPrefs.SetInt("Slot3",100);

        PlayerPrefs.SetFloat("Slot1Value",1);
        PlayerPrefs.SetFloat("Slot2Value",1);
        PlayerPrefs.SetFloat("Slot3Value",1);

        slot1Text.text = PlayerPrefs.GetInt("Slot1").ToString();
        slot2Text.text = PlayerPrefs.GetInt("Slot2").ToString();
        slot3Text.text = PlayerPrefs.GetInt("Slot3").ToString();
    }

    public void DeActiveFunction(){
        MyRect.DOScale(Vector3.zero,0.66f).OnComplete( () => {
            Destroy(this.gameObject);
        });
    }

    public void OnFunction(RectTransform slotRect){
        slotRect.localScale = Vector3.one * 0.90f;
        string slotName = slotRect.gameObject.name;
        int coin = PlayerPrefs.GetInt("Coin");
        int price;
        float value;
        switch(slotName){
            case "Slot1":
                price = PlayerPrefs.GetInt(slotName);
                value = PlayerPrefs.GetFloat(slotName+"Value");
                if(coin >= PlayerPrefs.GetInt(slotName)){
                    coin -= price;
                    PlayerPrefs.SetInt("Coin",coin);
                    price *= 2;
                    PlayerPrefs.SetInt(slotName,price);
                    value *= 1.1f;
                    PlayerPrefs.SetFloat(slotName+"Value",value);
                    coinText.text = coin.ToString();
                    slot1Text.text = price.ToString();
                    coinPanelController.Coin = coin;
                }
            break;
            case "Slot2":
                price = PlayerPrefs.GetInt(slotName);
                value = PlayerPrefs.GetFloat(slotName+"Value");
                if(coin >= PlayerPrefs.GetInt(slotName)){
                    coin -= price;
                    PlayerPrefs.SetInt("Coin",coin);
                    price *= 2;
                    PlayerPrefs.SetInt(slotName,price);
                    value *= 1.1f;
                    PlayerPrefs.SetFloat(slotName+"Value",value);
                    coinText.text = coin.ToString();
                    slot2Text.text = price.ToString();
                    coinPanelController.Coin = coin;
                }
            break;
            case "Slot3":
                price = PlayerPrefs.GetInt(slotName);
                value = PlayerPrefs.GetFloat(slotName+"Value");
                if(coin >= PlayerPrefs.GetInt(slotName)){
                    coin -= price;
                    PlayerPrefs.SetInt("Coin",coin);
                    price *= 2;
                    PlayerPrefs.SetInt(slotName,price);
                    value *= 1.1f;
                    PlayerPrefs.SetFloat(slotName+"Value",value);
                    coinText.text = coin.ToString();
                    slot3Text.text = price.ToString();
                    coinPanelController.Coin = coin;
                }
            break;
        }
    }

    public void UpFunction(RectTransform slotRect){
        slotRect.localScale = Vector3.one;
    }
}
