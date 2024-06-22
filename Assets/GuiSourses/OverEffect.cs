using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverEffect : MonoBehaviour{
    
    private RectTransform image;
    void Start()    {
        image = GetComponent<RectTransform>();
        
    }

    void Update()    {       
        if(Input.anyKey) {
            SceneManager.LoadScene("Open world");


        }
    }

    void Awake() {
        Application.targetFrameRate = 60;
    }
}
