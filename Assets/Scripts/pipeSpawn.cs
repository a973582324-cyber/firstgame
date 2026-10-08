using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class pipeSpawn : MonoBehaviour
{
    public float StspawnRate = 4f;
    public float heightoff = 6f;
    public GameObject pipe;
    public logicmanager manager;
    private float spawnRate;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = StspawnRate;
        Spawnpipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= spawnRate)
        {
            Spawnpipe();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
        spawnRate = Mathf.Max(1.0f, StspawnRate - (manager.score / 3) * 0.5f);
    }
    void Spawnpipe()
    {
        float lowestPoint = transform.position.y - heightoff;
        float highestPoint = transform.position.y + heightoff;
        Instantiate(pipe,new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint),0), transform.rotation);
    }
}
