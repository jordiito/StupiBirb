using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float despawnPos = -45;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameObject.Find("Birb").GetComponent<BirbScript>().birdIsAlive) 
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        


        if (transform.position.x < despawnPos) Object.Destroy(gameObject);
    }
}
