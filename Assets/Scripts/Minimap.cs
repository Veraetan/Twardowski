using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour
{

    GameObject player;
    Vector3 diff;
    
    
    // Use this for initialization
    void Start()
    {
        findPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            gameObject.transform.Translate(player.transform.position - diff);
            diff = player.transform.position;
        }
    }

    public void findPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = (player.transform.position + new Vector3(0, 0, -50));
        diff = player.transform.position;
    }
    
}
