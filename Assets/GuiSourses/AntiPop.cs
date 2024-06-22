using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiPop : MonoBehaviour{
    private Image atributes;
    void Start()    {    
        atributes = GetComponent<Image>();
        atributes.color = new Color (255,255,255,0);
    }

    void Update()    {        
        atributes.color = atributes.color + new Color (0,0,0,0.1f * Time.deltaTime);
    }

    void Awake() {
        Application.targetFrameRate = 60;
    }
}
