using UnityEngine;
using System.Collections;

public class GUICtrl : MonoBehaviour {

    GameObject player;
    public Transform healthBar;
    float size;
    float posX;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        size = healthBar.GetComponent<RectTransform>().sizeDelta.x;
        posX = healthBar.GetComponent<RectTransform>().position.x;
    }
	
	// Update is called once per frame
	void Update () {
        RectTransform rt = healthBar.GetComponent<RectTransform>();

        var health = player.GetComponent<PlayerController>().health;
        var mhealth = player.GetComponent<PlayerController>().health_max;

        rt.sizeDelta = new Vector2(((float)health / (float)mhealth)*size, rt.sizeDelta.y);
        rt.position = new Vector3(size/2 + posX - (size-(((float)health / (float)mhealth) * size/2)), rt.position.y, rt.position.z);

        //Debug.Log((float)health / (float)mhealth);
    }
}
