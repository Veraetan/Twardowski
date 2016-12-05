using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level_Controller : MonoBehaviour {

    List<GameObject> spawners = new List<GameObject>();
    
    public void register(GameObject sp)
    {
        spawners.Add(sp);
    }

    public void spawn()
    {
        foreach(GameObject spawn in spawners)
        {
            spawn.GetComponent<Enemy_Spawner>().spawn();
        }
    }

    public void despawn()
    {
        foreach (GameObject spawn in spawners)
        {
            spawn.GetComponent<Enemy_Spawner>().despawn();
        }
    }
}
