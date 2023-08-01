using ClearSky;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //�����X�^�[�̈ړ����x
    private float speed = -2;

    //���ňʒu
    private float deadLine = -10;

    Animator animator;
    //�����X�^�[�̍U����
    public int attackPower;

    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�����X�^�[���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDamage(SimplePlayerController player)
    {
        player.Damage(attackPower);
    }
    
    //�����X�^�[�I�u�W�F�N�g���j������鏈����x�点�Ď��s
    public void OnDamage()
    {
        animator.SetTrigger("isDeath");
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        Invoke("Destroy", 0.4f);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MagicBall")
        {
            Destroy(other.gameObject);
            animator.SetTrigger("isDeath");
            boxCollider2D = this.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
            Invoke("Destroy", 0.4f);


        }
    }
}
