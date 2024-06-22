using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour{
   public float Health;
   public float MaxHealth = 100;
   public float HealthRegen = 30;
   public bool inCombat = false;
   public float damage = 10;
   public float attackRadius = 5;
   public float PatrolRadius = 30;
   public float WalkSpeed = 10;
   public float AttackSpeed = 1;
   private float lastTimeAttack = 0;

    public bool Alive = true;
    void Start(){
        Health = MaxHealth;
    }

    void Update(){
        if(inCombat){
            lastTimeAttack += Time.deltaTime;
            if(lastTimeAttack > 10){
                inCombat = false;
                lastTimeAttack = 0;
            }
        }
        if (!inCombat && Health > 0 && Health < MaxHealth){
            Health += HealthRegen * Time.deltaTime;
        }
    }

    public void takeDamage(float dmg){
        Health -= dmg;
        if(Health <= 0){
            Alive = false;      
            Health = 0;
        }
        lastTimeAttack = 0;
    }

}
