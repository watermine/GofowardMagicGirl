using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SimplePlayerController.hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("OnTheWayScene");
        }
    }
}
