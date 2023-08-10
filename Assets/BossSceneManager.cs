using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BossSceneManager : MonoBehaviour
{
    //�Q�[���I�[�o�[�e�L�X�g
    private GameObject gameOverText;

    //�Q�[���I�[�o�[�̕\��
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[���r���[����I�u�W�F�N�g�̎��̂���������
        this.gameOverText = GameObject.Find("GameOver");

        //�V�[���̊J�n���ɃV�[�����[�h���{�X��i=1�j�ɂ���
        SimplePlayerController spc;
        GameObject player = GameObject.Find("Wizard Variant");
        spc = player.GetComponent<SimplePlayerController>();
        spc.sceneMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I�[�o�[�ɂȂ����ꍇ
        if (this.isGameOver == true)
        {
            Invoke("TimeStop", 0.7f);
            //�N���b�N���ꂽ��V�[�������[�h����
            if (Input.GetMouseButtonDown(0))
            {
                //�^�C�g���ɖ߂�
                SceneManager.LoadScene("TitleScene");

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

    public void GameClear()
    {
        //�{�X��|�����Ƃ��ɁA��ʏ�ɃQ�[���N���A��\������
        this.gameOverText.GetComponent<Text>().text = "Game Clear!";
        this.isGameOver = true;
    }

    void TimeStop()
    {
        //��ʂ��~�߂�
        Time.timeScale = 0f;
    }

}
