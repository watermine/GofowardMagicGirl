using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlantController : MonoBehaviour
{
    private float moveTimer = 0;
    private float damageTimer = 0;

    public AudioClip seFire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(moveTimer);
        moveTimer += Time.deltaTime;

        if (moveTimer > 0 && moveTimer < 0.3f)
        {
            transform.Translate(0, +3.00f * Time.deltaTime, 0);
        }
        else if (moveTimer > 0.4f && moveTimer < 0.8f)
        {
            transform.Translate(0, -3.00f * Time.deltaTime, 0);
        }
        else if (moveTimer > 1.2f && moveTimer < 1.5f)
        {
            transform.Translate(0, 12.0f * Time.deltaTime, 0);
        }

        damageTimer += Time.deltaTime;

        if(damageTimer > 0.5f)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            damageTimer = 0;
        }

        if (other.gameObject.tag == "MagicBall")
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(seFire, transform.position);
        }
    }

}
