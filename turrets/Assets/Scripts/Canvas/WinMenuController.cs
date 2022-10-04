using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class WinMenuController : MonoBehaviour
{
    [SerializeField] RectTransform RewardButtonRect,DefaultButtonRect,flag;
    [SerializeField] Ease ButtonEase;
    [SerializeField] Image Background;
    [SerializeField] Color TargetBackgroundColor;
    [SerializeField] float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActiveFunction(){
        Background.DOColor(TargetBackgroundColor,0.5f).SetDelay(delay).OnComplete( () => {
            RewardButtonRect.DOScale(Vector3.one,1.1f).SetEase(ButtonEase);
            DefaultButtonRect.DOScale(Vector3.one,1f).SetEase(ButtonEase);
            flag.DOScale(Vector3.one,1f).SetEase(ButtonEase);
        });
    }
}
