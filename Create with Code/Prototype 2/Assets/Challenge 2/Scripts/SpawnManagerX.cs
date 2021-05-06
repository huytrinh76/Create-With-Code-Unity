using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float timer;
    private float minTime=3.0f;
    private float maxTime = 5.0f;
    private float spawnTimeInterval;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimeInterval = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTimeInterval)
        {
            SpawnRandomBall();
            spawnTimeInterval = Random.Range(minTime, maxTime);
            timer = 0;
        }
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        int ball = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ball], spawnPos, ballPrefabs[ball].transform.rotation);
    }

}
