using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlrauneController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
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
                    else if (timeCounter >3.0f &&  range <= 6f)
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
}
