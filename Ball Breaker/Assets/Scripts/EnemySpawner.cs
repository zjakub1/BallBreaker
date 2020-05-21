using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // variables
    [SerializeField] Enemy enemy;
    bool hasStarted;

    // cached Objects
    GameSession session;

    // Start is called before the first frame update
    void Update()
    {
        session = FindObjectOfType<GameSession>();
        hasStarted = session.getHasStarted();
        Debug.Log(hasStarted);
        if (hasStarted)
        {
            SpawnAMonster();
        }
    }

    void Start()
    {
        /*
        Debug.Log("In start");
        if (!hasStarted)
        {
            InvokeRepeating("SpawnAMonster", 1f, 5f);
        }
            */
    }

    public void SpawnAMonster()
    {

        Debug.Log("Spawning a monster new way");
        UnityEngine.Vector3 newSpawn = new UnityEngine.Vector3(7, 7, 0);
        Instantiate(enemy, newSpawn, Quaternion.identity);
    }
}
