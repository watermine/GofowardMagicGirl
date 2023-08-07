using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenetator : MonoBehaviour
{
    //ゴブリンのPrefab
    public GameObject GoblinPrefab;

    public GameObject FlyingeyePrefab;

    //モンスターの生成間隔
    public float span = 1.0f;

    //モンスターの生成位置：X座標
    private float genPosX;

    //モンスターの生成位置オフセット：X座標
    private float offsetX = 0.5f;

    //モンスターの生成位置：Y座標
    private float genPosY = -3.12f;

    //モンスターの生成位置オフセット：Y座標
    private float offsetY;

    //モンスターの横方向の間隔
    private float spaceX = 1.4f;

    //モンスターの生成個数の上限
    //private int maxBlocknum = 1;

    //時間計測用の変数
    private float delta = 0;

   

   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span以上の時間が経過したか調べる
        if(this.delta > this.span)
        {
            this.delta = 0;

    //生成するモンスターをランダムに決める
    int num = Random.Range(1, 5);

            if (num <= 2)
            {
                //ゴブリンの生成
                genPosX = Random.Range(11.0f, 13.0f);
                GameObject go = Instantiate(GoblinPrefab);
                go.transform.position = new Vector2(this.genPosX, this.genPosY);
            }

            else
            {
                //フライングアイの生成
                genPosX = Random.Range(12.0f, 13.0f);
                offsetY = Random.Range(4.0f, 5.0f);
                GameObject go = Instantiate(FlyingeyePrefab);
                go.transform.position = new Vector2(this.genPosX, this.genPosY + offsetY);
            }
           
            
                
            
            //次のモンスターまでの生成時間を決める
            this.span = this.offsetX + this.spaceX;
        }
    }
}
