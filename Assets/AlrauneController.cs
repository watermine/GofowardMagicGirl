using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlrauneController : MonoBehaviour
{
    //�U����
    public int attackPower;
    //HP
    public float bossHP = 10;

    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player;
    private float range;
    


    //��Ԃ̔ԍ�
    private int stateNumber = 0;

    //�ėp�^�C�}�[
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
        Debug.Log(bossHP);

        //�{�X��HP��0�ɂȂ�����N���A

        if (bossHP <= 0)
        {
            timeCounter = 0;
            anim.SetTrigger("Down");

            //Destroy(this.gameObject, 0.4f);
            
        }


        //�X�e�[�g�p�^�[�����򕔕�
        //�^�C�}�[�X�V
        timeCounter += Time.deltaTime;

        //�v���C���[�Ƃ̋������v��
        range = player.transform.position.x + this.transform.position.x;

        //�ߐڍU���p�̗���
        int num = Random.Range(1, 6);

        //��Ԃ̏���
        switch (stateNumber)
        {
            //���̍s��
            case 0:
                {
                    //3�b�o�߁H
                    if (timeCounter > 3.0f && range > 6f && num > 2)
                    {
                        anim.SetTrigger("ShortRange");

                        //�N���A�[
                        timeCounter = 0.0f;

                        //��Ԃ̑J��
                        stateNumber = 1;
                    }
                    else if (timeCounter > 3.0f && range > 6f && num <= 2)
                    {
                        anim.SetTrigger("ShortRangeDubble");

                        //�N���A�[
                        timeCounter = 0.0f;

                        //��Ԃ̑J��
                        stateNumber = 2;
                    }
                    else if (timeCounter > 3.0f && range <= 6f)
                    {
                        anim.SetTrigger("LongRange");

                        //�N���A�[
                        timeCounter = 0.0f;

                        //��Ԃ̑J��
                        stateNumber = 3;
                    }
                }
                break;

            //�ߐڍU����
            case 1:
                {
                    //1.5�b�o��
                    if (timeCounter > 1.5f)
                    {
                        //�N���A�[
                        timeCounter = 0.0f;

                        //��Ԃ̑J��
                        stateNumber = 0;
                    }
                }
                break;
            //�A���U����
            case 2:
                {
                    //1.5�b�o��
                    if (timeCounter > 1.5f)
                    {
                        //�N���A�[
                        timeCounter = 0.0f;

                        //��Ԃ̑J��
                        stateNumber = 0;
                    }
                }
                break;
            //�������U����
            case 3:
                {
                    //1.5�b�o��
                    if (timeCounter > 1.5f)
                    {
                        //�N���A�[
                        timeCounter = 0.0f;

                        //��Ԃ̑J��
                        stateNumber = 0;
                    }
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MagicBall")
        {
            bossHP -= 1;
            
        }

    }


    public void PlayerDamage(SimplePlayerController player)
    {
        player.Damage(attackPower);
    }

    public void BossOnDamage()
    {
        bossHP -= 1;
        
    }

    public void GameEnd()
    {
        
        //�{�X���|���ꂽ�ۂɃQ�[���N���A��\��
        GameObject.Find("Canvas").GetComponent<BossSceneManager>().GameClear();
    }

}
