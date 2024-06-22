using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class IA : MonoBehaviour{

    private string State = "Idle";
    private GameObject player;
    private Stats playerStats;
    private Vector3 spawn;
    private float timeInState = 0;
    private float timeOut = 5;
    private Vector3 Target ;
    private Stats stats;
    private Animator animator;
    private bool onChase = false;

    /****************************************************************************
    Idle : espera de 2, y 5 seg
    Patrol: ir a un punto random cerca en su rango
    Chase: perseguir jugador
    Attack: atacando

    ******************************************************************************/
    void Start()    {
        player = GameObject.Find("Player");
        spawn = transform.position;
        stats = GetComponent<Stats>();
        playerStats = player.GetComponent<Stats>();
        animator = GetComponent<Animator>();
        animator.Play("idle");
    }

    void Update()    {
        // update sensors
        timeInState += Time.deltaTime;
        Vector3 dst = player.transform.position - transform.position;
        if (dst.magnitude < stats.PatrolRadius){
           onChase = true;
        }else{
           onChase = false; 
        }

        if( State != "Attack2" && onChase && dst.magnitude < stats.attackRadius){
            State = "Attack";
        }

        // states
        if (State == "Idle") {
            // funciones
            animator.Play("idle");
            //transicion
            if (timeInState > timeOut) {                
                float x = Random.Range(- stats.PatrolRadius, stats.PatrolRadius);
                float z = Random.Range(- stats.PatrolRadius,stats.PatrolRadius);
                Vector3 position = new Vector3(x, 100.0f, z);
                position += spawn;
                Vector3 direction = Vector3.down;
                // casteo del rayo
                RaycastHit hit;
                if( Physics.Raycast(position,direction,out hit)){
                    if( hit.transform.tag == "Terrain"){
                        position.y = hit.point.y;
                        Target = position;
                        State = "Patrol";
                        timeInState = 0;
                        
                    }                
                }
                if(onChase){
                    State = "Chase";
                }                
            }
            
        }
        if (State == "Patrol") {
            // funciones
            Vector3 dir = Target - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * stats.WalkSpeed/2);
            animator.Play("walk");
            transform.LookAt(-Target);
            //transicion
            if (dir.magnitude < 1){
                State = "Idle";
                timeInState = 0;
            }
            if(onChase){
                State = "Chase";
            }    
        }
        if (State == "Chase"){
            transform.Translate(dst.normalized * Time.deltaTime * stats.WalkSpeed);
            if (!onChase){
                State = "Idle";
            }

        }
        if (State == "Attack"){
            timeInState = 0;
            playerStats.Health -= stats.damage;
            State = "Attack2";
            playerStats.inCombat = true;
            animator.Play("attack1");
        }
        if (State == "Attack2" && timeInState > stats.AttackSpeed){
            State = "Patrol";
        
        }
        if(stats.Health <= 0){
            State = "DEAD";
            animator.Play("die");
        }
    }
}
