using ClearSky;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //モンスターの移動速度
    private float speed = -2;

    //消滅位置
    private float deadLine = -10;

    Animator animator;
    //モンスターの攻撃力
    public int attackPower;

    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //モンスターを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDamage(SimplePlayerController player)
    {
        player.Damage(attackPower);
    }
    
    //モンスターオブジェクトが破棄される処理を遅らせて実行
    public void OnDamage()
    {
        animator.SetTrigger("isDeath");
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        Invoke("Destroy", 0.4f);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MagicBall")
        {
            Destroy(other.gameObject);
            animator.SetTrigger("isDeath");
            boxCollider2D = this.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
            Invoke("Destroy", 0.4f);


        }
    }
}
