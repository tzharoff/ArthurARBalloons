using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject BalloonPrefab;
    [SerializeField] private float minSpawnTime = 0.1f;
    [SerializeField] private float maxSpawnTime = 0.25f;

    IEnumerator spawner;
    bool spawning = true;
    private float lastX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartSpawning();
    }

    IEnumerator SpawnBalloons()
    {
        while (spawning)
        {
            Debug.Log("Spawning");
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            float x = RandomX;
            while(x < lastX + 1 && x > lastX - 1)
            {
                x = RandomX;
                yield return null;
            }
            lastX = x;
            GameObject temp = Instantiate(BalloonPrefab);
            temp.transform.position = new Vector3(x, transform.position.y, transform.position.z);
            yield return null;
        }
    }

    private float RandomX
    {
        get
        {
            return Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
        }
    }

    public void StartSpawning(){
        lastX = RandomX;
        spawner = SpawnBalloons();
        StartCoroutine(spawner);
    }

    public void StopSpawning()
    {
        StopCoroutine(spawner);
        spawning = false;
    }

}
