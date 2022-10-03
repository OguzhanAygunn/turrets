using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelSliderPanelController : MonoBehaviour
{
    RectTransform myRect;
    [SerializeField] Ease scaleEase;
    // Start is called before the first frame update
    void Start()
    {
        myRect = GetComponent<RectTransform>();
        //myRect.DOAnchorPos(targetPos,time).SetDelay(delay);
        myRect.localScale = Vector2.zero;
        myRect.DOScale(Vector2.one,3).SetEase(scaleEase).SetDelay(0.66f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
