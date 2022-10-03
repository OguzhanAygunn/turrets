using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static List<GameObject> turrets = new List<GameObject>();
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.PlayerDestroyable = false;
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate() {
        Debug.Log(turrets.Count.ToString());
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("FinishGround") && !GameManager.GameWin){
            GameManager.GameWin = true;
            playerMovement.FinishMoveActive();
        }
    }
}
