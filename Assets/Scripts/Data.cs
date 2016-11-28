using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour {

    public short hp, hpM;
    public int score;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (PlayerPrefs.HasKey("saved"))
        {
            if(PlayerPrefs.GetInt("saved") == 1)
            {
                PlayerPrefs.SetInt("saved", 0);
            }
        }
    }
}
