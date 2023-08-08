using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlrauneController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject player;
    private float range;

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
                        anim.SetTrigger("ShortRange");

                        //クリアー
                        timeCounter = 0.0f;

                        //状態の遷移
                        stateNumber = 1;
                    }
                    else if (timeCounter > 3.0f && range > 6f && num <= 2)
                    {
                        anim.SetTrigger("ShortRangeDubble");

                        //クリアー
                        timeCounter = 0.0f;

                        //状態の遷移
                        stateNumber = 2;
                    }
                    else if (timeCounter >3.0f &&  range <= 6f)
                    {
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
