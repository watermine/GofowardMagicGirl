using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト
    private GameObject gameOverText;

    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    private float len = 0;

    //走る速度
    private float speed = 5f;

    //ゲームオーバーの表示
    private bool isGameOver = false;

    

    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");

        //シーンの開始時にシーンモードを通常（=0）にする
        SimplePlayerController spc;
        GameObject player = GameObject.Find("Wizard Variant");
        spc = player.GetComponent<SimplePlayerController>();
        spc.sceneMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            //走った距離を更新する
            this.len += this.speed * Time.deltaTime;

            //走った距離を表示する
            this.runLengthText.GetComponent<Text>().text = "Distance：" + len.ToString("F2") + "m";
        }

        //一定距離以上走ればボスシーンへ
        if (this.len >= 100)
        {
            SceneManager.LoadScene("BossBattleScene");

            /*this.gameOverText.GetComponent<Text>().text = "Game Clear";
            this.isGameOver = true;
            */
        }

        //ゲームオーバーになった場合
        if(this.isGameOver == true)
        {
            Invoke("TimeStop", 0.7f);
            //クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //タイトルに戻る
                SceneManager.LoadScene("TitleScene");

                Time.timeScale = 1.0f;
            }
        }
    }
    public void GameOver()
    {
        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
    void TimeStop()
    {
        //画面を止める
        Time.timeScale = 0f;
    }
}
