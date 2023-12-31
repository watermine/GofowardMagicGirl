using ClearSky;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerHP : MonoBehaviour
{
    //HPアイコン生成に用いるイメージ画像
    public GameObject playerIcon;
    //親に指定するオブジェクト
    public Transform parentTran;

    private SimplePlayerController player;
    private int beforeHP;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<SimplePlayerController>();
        beforeHP = player.GetHP();
        CreateHPIcon();
    }

    private void CreateHPIcon()
    {
        for(int i = 0; i < player.GetHP(); i++)
        {
            GameObject playerHPobj = Instantiate(playerIcon, transform, false);
            playerHPobj.transform.SetParent(parentTran);
            playerHPobj.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowHPIcon();
    }

    private void ShowHPIcon()
    {
        if (beforeHP == player.GetHP()) return;

        UnityEngine.UI.Image[] icons = transform.GetComponentsInChildren<UnityEngine.UI.Image>();
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].gameObject.SetActive(i < player.GetHP());
        }
        beforeHP = player.GetHP();
    }
}
