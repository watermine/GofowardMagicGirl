using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererSwitcher : MonoBehaviour
{
    //�_�ł�����Ώ�
    public Renderer target1;
    public Renderer target2;
    public Renderer target3;
    public Renderer target4;
    public Renderer target5;
    public Renderer target6;
    public Renderer target7;
    public Renderer target8;
    public bool isFlashing = false;


    //�_�Ŏ���
    public float cycle = 1;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        if (isFlashing == false)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�������Ԃ̌o��
        time += Time.deltaTime;

        //����cycle�ŌJ��Ԃ��l�̎擾
        //0�`cycle�͈̔͂̒l
        var repeatValue = Mathf.Repeat(time, cycle);

        //���������ɂ����閾�ŏ�Ԃ𔽉f
        target1.enabled = repeatValue >= cycle * 0.5f;
        target2.enabled = repeatValue >= cycle * 0.5f;
        target3.enabled = repeatValue >= cycle * 0.5f;
        target4.enabled = repeatValue >= cycle * 0.5f;
        target5.enabled = repeatValue >= cycle * 0.5f;
        target6.enabled = repeatValue >= cycle * 0.5f;
        target7.enabled = repeatValue >= cycle * 0.5f;
        target8.enabled = repeatValue >= cycle * 0.5f;

       

    }

    public void SwitchRend()
    {

    }

}
