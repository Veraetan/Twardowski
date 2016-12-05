using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

    GameObject player;
    Vector3 diff;

    public Texture2D fadeTexture;
    public float fadeSpeed = 90000000000f;

    int drawDepth = -1000;
    public float alpha = 0.0f;
    public int dir = -1;
	// Use this for initialization
	void Start () {
        findPlayer();
        Physics.IgnoreLayerCollision(10, 10, true);
    }
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            gameObject.transform.Translate(player.transform.position - diff);
            diff = player.transform.position;
        }
	}

    public void findPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = (player.transform.position + new Vector3(0, 2, -10));
        diff = player.transform.position;
    }

    void OnGUI()
    {
        alpha += dir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public void fade(Vector3 pos)
    {
        alpha = 1.0f;
        player.transform.position = pos;
    }
}
