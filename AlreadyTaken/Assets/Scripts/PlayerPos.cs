using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject transformPos;

    void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float pX = playerPos.transform.position.x;
            float pY = playerPos.transform.position.y;


            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            playerPos.transform.position = new Vector3(pX, pY, 0f);
            transformPos.transform.position = new Vector3(pX, pY, 0f);
            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
        
    }

    public void PlayerPosSave()
    {
        PlayerPrefs.SetFloat("p_x", playerPos.transform.position.x);
        PlayerPrefs.SetFloat("p_y", playerPos.transform.position.y);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
}
