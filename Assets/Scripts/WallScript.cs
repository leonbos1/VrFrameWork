using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallScript : MonoBehaviour
{
    // private float speed = -1f; 

    float speed;
    public Transform wall;
    // Dear reader from here till comment is alex code (all other instances of my code will be marked with a //
    public GameObject goForward;
    public bool arrived;
    public bool onTheMove;
    [Header("====Speed====")]
    public float maxSpeed = -3f;
    public float minSpeed = -1f;
    void Start()
    {
        speed = Random.Range(maxSpeed, minSpeed);
       // gameObject.transform.Rotate(-90, 0, 0);
        arrived = false;
        onTheMove = false;
        gameObject.transform.localScale = new Vector3(1.21210003f,1.21210003f,1.21210003f);

    }

    // Update is called once per frame
    void Update()
    {
        //alex
        if (!arrived)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        
        //not alex
        if (arrived)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }

        //CheckRotation();

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (onTheMove)
        {
            Debug.Log("Collided with " + other.gameObject.name);
            Destroy(this.gameObject);
        }
    }
    //alex
    private void OnTriggerEnter(Collider other)
    {
        arrived = true;
        AudioManager.instance.Play("Bonk");
        WaitExtension.Wait(this, 3f, () => { onTheMove = true;} );
    }

    /*public void CheckRotation()
    {
        if(speed != gameObject())
    }*/
}
