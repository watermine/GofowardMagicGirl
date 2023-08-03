using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //�Q�[���I�[�o�[�e�L�X�g
    private GameObject gameOverText;

    //���s�����e�L�X�g
    private GameObject runLengthText;

    //����������
    private float len = 0;

    //���鑬�x
    private float speed = 5f;

    //�Q�[���I�[�o�[�̕\��
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[���r���[����I�u�W�F�N�g�̎��̂���������
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            //�������������X�V����
            this.len += this.speed * Time.deltaTime;

            //������������\������
            this.runLengthText.GetComponent<Text>().text = "Distance�F" + len.ToString("F2") + "m";
        }

        //��苗���ȏ㑖��΃{�X�V�[����
        if (this.len >= 100)
        {
            SceneManager.LoadScene("BossBattleScene");

            /*this.gameOverText.GetComponent<Text>().text = "Game Clear";
            this.isGameOver = true;
            */
        }

        //�Q�[���I�[�o�[�ɂȂ����ꍇ
        if(this.isGameOver == true)
        {
            Invoke("TimeStop", 0.5f);
            //�N���b�N���ꂽ��V�[�������[�h����
            if (Input.GetMouseButtonDown(0))
            {
                //OnTheWayscene��ǂݍ���
                SceneManager.LoadScene("OnTheWayScene");

                Time.timeScale = 1.0f;
            }
        }
    }
    public void GameOver()
    {
        //�Q�[���I�[�o�[�ɂȂ����Ƃ��ɁA��ʏ�ɃQ�[���I�[�o�[��\������
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
    void TimeStop()
    {
        //��ʂ��~�߂�
        Time.timeScale = 0f;
    }
}
