using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlrauneController : MonoBehaviour
{
    //攻撃力
    public int attackPower;
    //HP
    public float bossHP = 10;

    //public GameObject sword;
    //public GameObject plant;

    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player;
    private float range;
    private float damageTimer = 0;
    

    //状態の番号
    private int stateNumber = 0;

    //汎用タイマー
    private float timeCounter = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Wizard Variant");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(damageTimer);

        damageTimer += Time.deltaTime;

        if (damageTimer >= 1.6f)
        {
            GetComponent<RendererSwitcher>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = true;
            damageTimer = 0;
        }
        //Debug.Log(bossHP);

        //ボスのHPが0になったらクリア

        if (bossHP <= 0)
        {
            timeCounter = 0;
            GetComponent<RendererSwitcher>().enabled = false;

            anim.SetBool("ShortRange",false);
            anim.SetBool("ShortRangeDubble",false);
            anim.SetBool("LongRange", false);

            anim.SetTrigger("Down");

            //Destroy(this.gameObject, 0.4f);
            
        }
        else
        {


            

            //ステートパターン分岐部分
            //タイマー更新
            timeCounter += Time.deltaTime;

            //プレイヤーとの距離を計測
            range = player.transform.position.x + this.transform.position.x;

            //近接攻撃用の乱数
            int num = Random.Range(1, 6);

            //状態の処理
            switch (stateNumber)
            {
                //次の行動
                case 0:
                    {
                        //3秒経過？
                        if (timeCounter > 3.0f && range > 6f && num > 2)
                        {
                            GetComponent<ObjectInstantiate>().CreateSword();
                            anim.SetTrigger("ShortRange");

                            //クリアー
                            timeCounter = 0.0f;

                            //状態の遷移
                            stateNumber = 1;
                        }
                        else if (timeCounter > 3.0f && range > 6f && num <= 2)
                        {
                            GetComponent<ObjectInstantiate>().CreateSwordDubble();
                            anim.SetTrigger("ShortRangeDubble");

                            //クリアー
                            timeCounter = 0.0f;

                            //状態の遷移
                            stateNumber = 2;
                        }
                        else if (timeCounter > 3.0f && range <= 6f)
                        {
                            GetComponent<ObjectInstantiate>().CreatePlant();
                            anim.SetTrigger("LongRange");

                            //クリアー
                            timeCounter = 0.0f;

                            //状態の遷移
                            stateNumber = 3;
                        }
                    }
                    break;

                //近接攻撃中
                case 1:
                    {
                        //1.5秒経過
                        if (timeCounter > 1.5f)
                        {
                            //クリアー
                            timeCounter = 0.0f;

                            //状態の遷移
                            stateNumber = 0;
                        }
                    }
                    break;
                //連続攻撃中
                case 2:
                    {
                        //1.5秒経過
                        if (timeCounter > 1.5f)
                        {
                            //クリアー
                            timeCounter = 0.0f;

                            //状態の遷移
                            stateNumber = 0;
                        }
                    }
                    break;
                //遠距離攻撃中
                case 3:
                    {
                        //1.5秒経過
                        if (timeCounter > 1.5f)
                        {
                            //クリアー
                            timeCounter = 0.0f;

                            //状態の遷移
                            stateNumber = 0;
                        }
                    }
                    break;
            }
        }


        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MagicBall" )
        {
            
            bossHP -= 1;
            GetComponent<RendererSwitcher>().enabled = true;
            GetComponent<CapsuleCollider2D>().enabled = false;
            damageTimer = 0;
            
        }


    }


    public void PlayerDamage(SimplePlayerController player)
    {
        player.Damage(attackPower);
    }

    public void BossOnDamage()
    {
        bossHP -= 1;

        GetComponent<RendererSwitcher>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = false;

        damageTimer = 0;
    }

    public void GameEnd()
    {
        
        //ボスが倒された際にゲームクリアを表示
        GameObject.Find("Canvas").GetComponent<BossSceneManager>().GameClear();
    }

}
