using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("Object to Spawn")]
    [Tooltip("The item you wish to spawn")]
    public GameObject ObjectSpawned;

    private float spawningClock;
    // Start is called before the first frame update
    void Start()
    {
        ResetClock();
    }

    // Update is called once per frame
    void Update()
    {
        spawningClock -= Time.deltaTime;
	if (spawningClock <= 0.0f)
	{
		Instantiate(ObjectSpawned, transform.position, Quaternion.identity);
		ResetClock();
	}
    }
    void ResetClock()
    {
	spawningClock = 3;
    }
}
