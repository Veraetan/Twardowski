using UnityEngine;
using System.Collections;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject enemy;
    GameObject instance;
    public GameObject lvlCtrl;
	
    void Start()
    {
        lvlCtrl.GetComponent<Level_Controller>().register(gameObject);
    }

    public void spawn()
    {
        instance = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
    }

    public void despawn()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
    }
}
