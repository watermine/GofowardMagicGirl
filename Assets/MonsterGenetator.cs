using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenetator : MonoBehaviour
{
    //�S�u������Prefab
    public GameObject GoblinPrefab;

    //���Ԍv���p�̕ϐ�
    private float delta = 0;

    //�����X�^�[�̐����Ԋu
    private float span = 1.0f;

    //�����X�^�[�̐����ʒu�FX���W
    private float genPosX = 12;

    //�L���[�u�̐����ʒu�I�t�Z�b�g�FX���W
    private float offsetX = 0.5f;

    //�����X�^�[�̐����ʒu�FY���W
    private float genPosY = -3.12f;

    //�����X�^�[�̉������̊Ԋu
    private float spaceX = 1.4f;

    //�����X�^�[�̐������̏��
    private int maxBlocknum = 1;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span�ȏ�̎��Ԃ��o�߂��������ׂ�
        if(this.delta > this.span)
        {
            this.delta = 0;
            //��������L���[�u���������_���Ɍ��߂�
            int n =Random.Range(1, maxBlocknum+1);

            //�w�肵���������L���[�u�𐶐�����
            for(int i = 0; i < n; i++)
            {
                //�L���[�u�̐���
                GameObject go = Instantiate(GoblinPrefab);
                go.transform.position = new Vector2(this.genPosX, this.genPosY);
            }
            //���̃L���[�u�܂ł̐������Ԃ����߂�
            this.span = this.offsetX + this.spaceX * n;
        }
    }
}
