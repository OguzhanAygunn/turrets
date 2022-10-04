using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static List<GameObject> turrets = new List<GameObject>();
    PlayerMovement playerMovement;
    WinMenuController winMenuController;
    CoinPanelController cpc;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.PlayerDestroyable = false;
        playerMovement = GetComponent<PlayerMovement>();
        winMenuController = GameObject.FindObjectOfType<WinMenuController>();
        cpc = GameObject.FindObjectOfType<CoinPanelController>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("FinishGround") && !GameManager.GameWin){
            GameManager.GameWin = true;
            playerMovement.FinishMoveActive();
            cpc.DeActiveFunction();
        }
    }
}