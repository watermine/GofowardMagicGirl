﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace ClearSky
{
    public class SimplePlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 60f; //Set Gravity Scale in Rigidbody2D Component to 5
        public Transform attackPoint;
        public float attackRadius;
        public LayerMask enemyLayer;
        public int hp;
        public GameObject MagicBall;
        public AudioClip seSwing;
        public AudioClip seAttack;
        public AudioClip seCast;
        

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        private bool isJumping = false;
        private bool alive = true;
        private float speed = 10f;
        AudioSource audioSource;
        private float coolTime = 0.0f;

        BoxCollider2D bc;
        CapsuleCollider2D cc;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();

        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                //Hurtアニメーション以外は動けるようにする
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") == false)
                {
                    //Hurt();
                    Die();
                    Attack();
                    Shot();
                    Jump();
                    Run();
                }
               

            }
            Debug.Log(hp);

            if (alive == false)
            {
                // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
                GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            }

        }

        public int GetHP()
        {
            return hp;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == "Monster" && (anim.GetCurrentAnimatorStateInfo(0).IsName("Die") == false))
            {
                Debug.Log("Damage!");
                anim.SetTrigger("hurt");
                other.gameObject.GetComponent<EnemyManager>().PlayerDamage(this);
                audioSource.PlayOneShot(seAttack);


                if (direction == 1)
                    rb.AddForce(new Vector2(-12f, 1f), ForceMode2D.Impulse);

            }
        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0 && this.transform.position.x >= -6.9f)
            {
                direction = 1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0 && this.transform.position.x <= 7.4f)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {

            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("attack");
                audioSource.PlayOneShot(seSwing);
            }
            
   
        }
        void Shot()
        {
            //クールタイムを減ずる
            this.coolTime -= Time.deltaTime;

            //マイナスなら受け付ける
            if (this.coolTime < 0.0f)

                //マウス右クリック
                if (Input.GetMouseButtonDown(1))
            {
                //Trigger shot
                anim.SetTrigger("shot");
                    
                //クールタイム
                this.coolTime = 0.98f;
            }
        }

        public void GenerateMagic()
        {
            GameObject magicBall = Instantiate(MagicBall);
            magicBall.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 5);
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,-5,0);
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;
            magicBall.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
            audioSource.PlayOneShot(seCast);
        }
        public void HitCheck()
        {
            
                Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
                foreach (Collider2D hitEnemy in hitEnemys)
                {
                    Debug.Log(hitEnemy.gameObject.name + "に攻撃");
                    hitEnemy.GetComponent<EnemyManager>().OnDamage();
                    audioSource.PlayOneShot(seAttack);
     
                }

            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }

        public void Damage(int damage)
        {
            hp = Mathf.Max(hp - damage, 0);
        }
       
        void Die()
        {
            /*if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("die");
                alive = false;
            }*/
            if (hp == 0)
            {
                anim.SetTrigger("die");
                alive = false;
                //bc.enabled = false;
                //cc.isTrigger = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
   
    }
}