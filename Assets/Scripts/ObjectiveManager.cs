using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour{

    public GameObject objective;
    private Vector3 center = new Vector3(0, 0 , 0); 
    public float spawArea = 50*9;
    void Start()    {
        Casting();

    }

    void Update()    {
        
    }

    private void Casting() {
        float x = Random.Range(center.x - 0, center.x - spawArea);
        float z = Random.Range(center.z - 0, center.z - spawArea);
        //do{
            Vector3 position = new Vector3(x, 100.0f, z);
            Vector3 direction = Vector3.down;
        
            // casteo del rayo
            RaycastHit hit;
            if( Physics.Raycast(position,direction,out hit)){
                if( hit.transform.tag == "Terrain"){
                    position.y = hit.point.y;
                }                                
            }
            
            //////////// generamos el objeto de la lista pasada
            
            Instantiate(objective,position,objective.transform.rotation);
       // } while (valid);        


    }

}
