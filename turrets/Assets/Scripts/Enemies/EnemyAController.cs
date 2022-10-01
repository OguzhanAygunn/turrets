using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EnemyAController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int health;
    [SerializeField] GameObject MiniEnemy,DestroyEffect;
    private int Health{
        get{
            return health;
        }
        set{
            health = value;
            tmpro.text = health.ToString();
            if(health <= 0){
                if(!ScaleDown){
                    ScaleDown = true;
                    transform.DOScale(Vector3.zero,0.33f).OnComplete( () => {
                        Instantiate(DestroyEffect,transform.position,Quaternion.identity);
                        Destroy(this.gameObject);
                    });
                }
            }
        }
    }
    [SerializeField] Material fontMaterial;
    Transform target;
    MeshRenderer TMPRender;
    GameObject TextObj;
    TextMeshPro tmpro;
    bool ScaleUp,ScaleDown;
    Vector3 upScale,DefaultScale;
    // Start is called before the first frame update
    void Start()
    {
        TextObj = transform.GetChild(0).gameObject;
        TMPRender = TextObj.GetComponent<MeshRenderer>();
        TMPRender.material = fontMaterial;
        tmpro = TMPRender.GetComponent<TextMeshPro>();
        tmpro.text = health.ToString();
        DefaultScale = transform.localScale;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    public Vector3 MiniEnemyPos()
    {
        Vector3 pos = Random.insideUnitSphere*0.5f;
        Vector3 newPos = transform.position + pos;
        newPos.y = transform.position.y + 1.5f;
        return newPos;
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullet")){
            if(ScaleUp == false){
                ScaleUp = true;
                upScale = transform.localScale * 1.1f;
                transform.DOScale(upScale,0.05f).OnComplete( () => {
                    transform.DOScale(DefaultScale,0.05f).OnComplete( () => {
                        ScaleUp = false;
                    });
                });
            }
            Health--;

            Instantiate(MiniEnemy,MiniEnemyPos(),Quaternion.identity);
        }
    }


}
