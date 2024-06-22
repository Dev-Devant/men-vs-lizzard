using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour{

    ///////// guis
    public Image healthDisplay;
    public TextMeshProUGUI healthText;

    public Image healthDisplayEnemy;
    public Image EnemyBackGround;
    public TextMeshProUGUI healthTextEnemy;
    public TextMeshProUGUI nameTextEnemy;

    public GameObject target;
    

    ///////// variables utiles
    private Stats playerStats;
    private float maxBarSize;

    void Start()   {
        playerStats = GameObject.Find("Player").GetComponent<Stats>();
        maxBarSize = healthDisplay.rectTransform.sizeDelta.x / playerStats.MaxHealth;
        ErraceTarget();
    }

    void Update()  {
        healthDisplay.rectTransform.sizeDelta = new Vector2(playerStats.Health * maxBarSize ,healthDisplay.rectTransform.sizeDelta.y);
        healthText.text = "Vida: " + Mathf.Floor(playerStats.Health);
        if(target != null) {
            Stats  targetStats = target.GetComponent<Stats>();
            healthTextEnemy.text = "Health: " + Mathf.Floor(targetStats.Health);
            

        }

    }

    public void updateTarget(GameObject tgt){
        target = tgt;
        healthDisplayEnemy.gameObject.SetActive(true);        
        healthTextEnemy.gameObject.SetActive(true);        
        nameTextEnemy.gameObject.SetActive(true);    
        EnemyBackGround.gameObject.SetActive(true);

        nameTextEnemy.text = tgt.name;

    }
    public void ErraceTarget(){
        target = null;
        healthDisplayEnemy.gameObject.SetActive(false);        
        healthTextEnemy.gameObject.SetActive(false);        
        nameTextEnemy.gameObject.SetActive(false);
        EnemyBackGround.gameObject.SetActive(false);

    }

}
