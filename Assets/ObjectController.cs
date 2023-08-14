using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class ObjectController : MonoBehaviour
{
    private GameObject player;

    //ÉÇÉìÉXÉ^Å[ÇÃçUåÇóÕ
    //public int attackPower;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Wizard Variant");
        Invoke("Move", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector2 force = (new Vector2(0, -20f));
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
