using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour{
    public GameObject[] NPC;
    public float range = 50;
    public int cant = 50;
    private int currentNPCS = 0;
    void Start()    {
                
         InvokeRepeating("spawnear",5,1);
    }

    void Update()    {
        
    }

    private void spawnear(){
        if(currentNPCS < cant){
            int dize = Random.Range(0, NPC.Length);

            float x = Random.Range(-range/2, range/2);
            float y = 50.0f;
            float z = Random.Range(-range/2, range/2);

            Vector3 pos = new Vector3(x, y, z);
            pos += transform.position;

            Instantiate(NPC[dize],pos,Quaternion.identity);
            
            
            currentNPCS += 1;
        }

    }
}
