using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BigSlimeController : MonoBehaviour
{
    Collider[] hitColliders = new Collider[1];
    [SerializeField] float radius,speed;
    [SerializeField] private Transform[] spawnPosS;
    [SerializeField] GameObject MiniSlime,destroyEffect;
    int health = 40,enemyCount = 15;
    int Health{
        get{
            return health;
        }
        set{
            health = value;
            if(health <= 0){
                Destroy(myColl);
                while(enemyCount > 0){
                    MiniSlimeController msc = Instantiate(MiniSlime,MiniEnemyPos(),Quaternion.identity).gameObject.GetComponent<MiniSlimeController>();
                    msc.targetPos = playerPos;
                    enemyCount--;
                }
                Instantiate(destroyEffect,transform.position,Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
    [SerializeField] LayerMask targetLayer;
    Transform targetPos,playerPos;
    bool takeDamageState,changeScaleActive;
    Collider myColl;
    Vector3 targetScale;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        myColl      = GetComponent<Collider>();
        playerPos   = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        targetScale = transform.localScale;
        material    = transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movementOperations();
        lookAtOperations();
        Radar();
        scaleOperations();
    }

    void movementOperations(){
       if(targetPos && !GameManager.GameLose){
           transform.position = Vector3.MoveTowards(transform.position,targetPos.position,speed*Time.fixedDeltaTime);
       } 
    }

    void lookAtOperations(){
        if(targetPos){
            transform.LookAt(targetPos.position,transform.up);
        }
    }

    void Radar(){
        hitColliders = Physics.OverlapSphere(transform.position, radius, targetLayer);
        if(targetPos == null && hitColliders != null){
            foreach(var obj in hitColliders){
                targetPos = obj.transform;
            }
        }
    }

    void scaleOperations(){
        if(health > 0){
            if(transform.localScale != targetScale){
                transform.localScale = Vector3.MoveTowards(transform.localScale,targetScale,1.5f*Time.fixedDeltaTime);
            }
        }
    }

    public Vector3 MiniEnemyPos()
    {
        Vector3 pos = Random.insideUnitSphere*0.02f;
        Vector3 newPos = transform.position + pos;
        newPos.y = transform.position.y;
        return newPos;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullet") && !takeDamageState){
            takeDamageFunction();
            targetScale = transform.localScale;
            targetScale *= 1.02f;
            Color color = material.color;
            color.r += 0.033f;
            material.color = color;
            
        }
    }

    void takeDamageFunction(){
        Health -= 1;
    }
}
