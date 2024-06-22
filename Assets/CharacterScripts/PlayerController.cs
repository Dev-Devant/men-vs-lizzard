using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Stats playerStats;
    private Rigidbody playerRB;
    private GameObject[] spawns;
    private HUD mainHud;
    private Animator animator;
    void Start()
    {
        playerStats = GetComponent<Stats>();
        playerRB = GetComponent<Rigidbody>();
        spawns = GameObject.FindGameObjectsWithTag("Spawn");
        int index = Random.Range(0, spawns.Length);
        transform.position = spawns[index].transform.position + Vector3.up * 10;
        mainHud = GameObject.Find("Canvas").GetComponent<HUD>();
        animator = GetComponent<Animator>();

        animator.Play("Idle");    

    }

    void Update()
    {
        sprint();
        movement();
        rotate();
        respawn();
        attact();

    }

    private void respawn()
    {

        if (playerStats.Health <= 0)
        {
            playerStats.Health = playerStats.MaxHealth;
            int index = Random.Range(0, spawns.Length);
            transform.position = spawns[index].transform.position + Vector3.up * 10;
        }
    }
    private void rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up);
        }


    }

    private void movement()
    {
        bool isMoving = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * 10, ForceMode.Impulse);
            animator.Play("JumpUp");
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * playerStats.WalkSpeed * Time.deltaTime);
            animator.Play("WalkForward");
             isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * playerStats.WalkSpeed * Time.deltaTime);
             isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * playerStats.WalkSpeed * Time.deltaTime);
             isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerStats.WalkSpeed * Time.deltaTime);
             isMoving = true;
        }
        if (!isMoving){
            animator.Play("Idle");

        }
    }

    private void sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerStats.WalkSpeed = 20;
        }
        else
        {
            playerStats.WalkSpeed = 10;
        }
    }

    private void attact()
    {
        float raycastRange = 30.0f;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 direction = transform.forward * raycastRange;
            if (Physics.Raycast(transform.position, direction, out hit))
            {
                Stats targetStats = hit.transform.gameObject.GetComponent<Stats>();
                if (targetStats != null)
                {
                    mainHud.updateTarget(hit.transform.gameObject);
                    targetStats.Health -= 30;
                }

            }
        }

    }
}
