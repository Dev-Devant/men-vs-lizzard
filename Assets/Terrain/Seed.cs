using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour{

    public int mapSize = 9;
    public int TreeCount = 500;
    public int rockCount = 1500;
    public int stupmsCount = 200;
    public int houseCount = 3;
    public int spawnCount = 10;
    public GameObject[] terrainBlock ;
    public GameObject[] treeModels ;
    public GameObject[] rockModels ;
    public GameObject[] stupmsModels ;
    public GameObject[] houseModels ;
    public GameObject[] SpawnerModels ;
    private float blockSize = 50;
    void Start()    {
        Vector3 center = new Vector3(0, 0 , 0);        
        generateTerrain(blockSize, center);
        float mapSizeFull = blockSize*mapSize;
        raySpawner(mapSizeFull,spawnCount,SpawnerModels,center);
        bunch(mapSizeFull,houseCount, houseModels,center);
        raySpawner(mapSizeFull,stupmsCount,stupmsModels,center);
        raySpawner(mapSizeFull,rockCount,rockModels,center);
        raySpawner(mapSizeFull,TreeCount,treeModels,center);
    }

    void Update()    {
        
    }
    void Awake() {
        Application.targetFrameRate = 60;
    }
    private void generateTerrain(float blockSize,Vector3 center){
        for (int x = 0; x < mapSize;x++) {            
            Vector3 faceX = blockSize * Vector3.back * x;
            for (int z = 0; z < mapSize;z++) {
                int index = Random.Range(0, terrainBlock.Length);
                if (Random.Range(0.0f,1.0f) < 0.5){
                    index = 0;
                }

                Vector3 faceZ = blockSize * Vector3.left * z;
                Instantiate(terrainBlock[index], center + faceX + faceZ ,terrainBlock[index].transform.rotation );
            }
        }
        

    }
    private GameObject[] raySpawner(float spawArea,int cantidad, GameObject[] models,Vector3 center){
        GameObject[] list = new GameObject[cantidad];

        for (int i = 0; i < cantidad; i++){
            float x = Random.Range(center.x - 0, center.x - spawArea);
            float z = Random.Range(center.z - 0, center.z - spawArea);
            Vector3 position = new Vector3(x, 100.0f, z);
            Vector3 direction = Vector3.down;
            // casteo del rayo
            RaycastHit hit;
            if( Physics.Raycast(position,direction,out hit)){
                if( hit.transform.tag != "Terrain"){
                    continue;
                }                
                position.y = hit.point.y;
            }else{
                continue;
            }
            
            //////////// generamos el objeto de la lista pasada
            int index = Random.Range(0, models.Length);
            Quaternion rotation = new Quaternion (0,Random.Range(0,360),0,0);
            list[i] = Instantiate(models[index],position,rotation);
        }

        return list;
    }

    private GameObject[] bunch(float spawArea,int cantidad, GameObject[] models,Vector3 center){
        GameObject[] list = new GameObject[cantidad];
        for (int i = 0; i < cantidad; i++){
            float x = Random.Range(center.x - 0, center.x - spawArea);
            float z = Random.Range(center.z - 0, center.z - spawArea);
            Vector3 position = new Vector3(x, 100.0f, z);
            Vector3 direction = Vector3.down;
            // casteo del rayo
            RaycastHit hit;
            if( Physics.Raycast(position,direction,out hit)){
                if( hit.transform.tag != "Terrain"){
                    continue;
                }                
                position.y = hit.point.y;
            }else{
                continue;
            }
            raySpawner(spawArea,Random.Range(4,7),models,position);
        }

        return list;
    }
}
