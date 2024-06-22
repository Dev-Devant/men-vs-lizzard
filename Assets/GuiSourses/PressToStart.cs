using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour{
    private TextMeshPro text;
    void Start()    {
        text = GetComponent<TextMeshPro>();
        InvokeRepeating("transition",4,0.1f);
    }

    void Update()   {
      //  text.outlineColor = Color.white;
    }       

    void transition(){
        if(Input.anyKey) {
            SceneManager.LoadScene("MainMenu");


        }
    }
}

