using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BossSceneManager : MonoBehaviour
{
    //ゲームオーバーテキスト
    private GameObject gameOverText;

    //ゲームオーバーの表示
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");

        //シーンの開始時にシーンモードをボス戦（=1）にする
        SimplePlayerController spc;
        GameObject player = GameObject.Find("Wizard Variant");
        spc = player.GetComponent<SimplePlayerController>();
        spc.sceneMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバーになった場合
        if (this.isGameOver == true)
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

    public void GameClear()
    {
        //ボスを倒したときに、画面上にゲームクリアを表示する
        this.gameOverText.GetComponent<Text>().text = "Game Clear!";
        this.isGameOver = true;
    }

    void TimeStop()
    {
        //画面を止める
        Time.timeScale = 0f;
    }

}
