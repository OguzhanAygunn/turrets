using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CoinPanelController : MonoBehaviour
{
    RectTransform MyRect;
    [SerializeField] Ease ease;
    [SerializeField] Text coinText;
    [SerializeField] float speed;
    int coin;
    bool deActive,scaleUp;

    public int Coin{
        get{
            return coin;
        }
        set{
            coin = value;
            coinText.text = coin.ToString();
            scaleUp = true;
        }
    }
    Vector3 upScale,defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        MyRect = GetComponent<RectTransform>();
        upScale = MyRect.localScale * 1.25f;
        defaultScale = MyRect.localScale;
    }

    private void FixedUpdate() {
        scaleOperations();
    }

    void scaleOperations(){
        if(!deActive){
            if(scaleUp){
                MyRect.localScale = Vector3.MoveTowards(MyRect.localScale,upScale,speed*Time.deltaTime);
                if(MyRect.localScale == upScale){
                    scaleUp = false;
                }
            }
            else{
                if(MyRect.localScale != defaultScale){
                    MyRect.localScale = Vector3.MoveTowards(MyRect.localScale,defaultScale,speed*Time.deltaTime);
                }
            }
        }
    }

    public void DeActiveFunction(){
        deActive = true;
        MyRect.DOScale(Vector3.zero,0.5f).SetEase(ease);
    }
}
