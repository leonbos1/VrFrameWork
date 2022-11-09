using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Walls;
    public Transform Spawnpoint;
    public float delay = 5f;
    private bool isPlaying = true;
    private bool start = false;
    private GameObject lastWall;
    public float waitTime = 8;

    public int lives = 3;
    void Start()
    {
        Invoke("startGame", delay);
        //alex
        AudioManager.instance.Play("Belt");
        AudioManager.instance.Play("Background");

    }

    void startGame()
    {
        start = true;
        WaitExtension.Wait(this, waitTime + delay,WallSpawner);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
            return;

        if (start) {
            /*if (lastWall == null)
            {
                int random = Random.Range(0, Walls.Length);
                lastWall = Instantiate(Walls[random], Spawnpoint.position, Quaternion.identity);
            }
            else*/
            {
                /*if (lastWall.transform.position.x < Spawnpoint.position.x)
                {
                    int random = Random.Range(0, Walls.Length);
                    lastWall = Instantiate(Walls[random], Spawnpoint.position, Quaternion.identity);
                }*/
            }

        }
    
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SpawnWall();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Endstate();
        }
        

    }

    public void SpawnWall()
    {
        /*
        int randomWall = Random.Range(0, Walls.Length);
        Instantiate(Walls[randomWall], Spawnpoint.position, Spawnpoint.rotation);
        */
        
        int random = Random.Range(0, Walls.Length);
        lastWall = Instantiate(Walls[random], Spawnpoint.position, Quaternion.identity);
        
    }

    public void Endstate()
    {
        var Walling = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var GameObject in Walling)
        {
            Destroy(GameObject);
        }
    }

    public void WallSpawner()
    {
        SpawnWall();
        if (start)
        {
            WaitExtension.Wait(this,waitTime,WallSpawner);
        }
    }
    
}
