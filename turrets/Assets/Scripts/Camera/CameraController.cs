using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] float FollowSpeed;
    [SerializeField] Vector3 posOffset,lookOffset,LoseOffset,targetOffset;
    Vector3 myVector;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.To(()=> targetOffset, x=> targetOffset = x, posOffset, 1);
        playerPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        playerMovement = playerPos.gameObject.GetComponent<PlayerMovement>();
    }   

    // Update is called once per frame
    private void LateUpdate()
    {
        FollowOperations();
        LookatOperations();
    }

    void FollowOperations(){
        transform.position = Vector3.MoveTowards(transform.position,playerPos.position + targetOffset, FollowSpeed*Time.deltaTime);
    }
    
    void LookatOperations(){
        transform.LookAt(playerPos.position + lookOffset);
    }

    public void GameDeathController(){
        bool y = false;

        foreach(GameObject obj in PlayerCollision.turrets){
            if(obj){y = true;}
        }

        if(y == false){
            DOTween.To(()=> targetOffset, x=> targetOffset = x, LoseOffset, 2);
            GameManager.GameLose = true;
            Camera.main.DOShakePosition(1,1);
            playerMovement.AddExplosionFunc();
        }
    }
}
