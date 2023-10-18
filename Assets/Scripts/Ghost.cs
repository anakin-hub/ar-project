using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    [SerializeField] UI_Manager ui_manager;
    Animator animator;
    GameObject alvo;
    float maxTempo;

    [SerializeField] protected int hp;
    [SerializeField] protected bool hit;
    [SerializeField] protected bool movingRight;
    [SerializeField] protected bool dead;

    void Start()
    {
        ui_manager = GameObject.FindWithTag("UI_Manager").GetComponent<UI_Manager>();
        alvo = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().gameObject;
        animator = GetComponent<Animator>();
        hp = 1;
        dead = hit = false;
        maxTempo = 5f - (0.1f * (float)ui_manager.GetScore());
        if (maxTempo < 2 ) { maxTempo = 2; }
        if (alvo != null)
        {
            if (transform.position.x - alvo.transform.position.x < 0)
                movingRight = false;
            else
                movingRight = true;
        }
    }

    void Update()
    {
        maxTempo-=Time.deltaTime;

        if (maxTempo <= 0 && !dead)
        {
            dead = true;
            ui_manager.LostTarget();
            Death();
            return;
        }

        if (hp <= 0 && !dead)
        {
            dead = true;
            ui_manager.ScoreUp();
            animator.SetBool("dead", dead);
            return;
        }
        else if (alvo != null)
            transform.LookAt(alvo.transform);

        if(hit)
        {
            hit = false;
            animator.SetBool("hitted", true);
            hp--;
        }

        if (alvo != null && !dead)
        {            
            if (!movingRight)
                transform.Translate(Vector3.left * 0.5f * Time.deltaTime);
            else
                transform.Translate(Vector3.right * 0.5f * Time.deltaTime);
            //transform.Translate(Vector3.back * 0.5f * Time.deltaTime);
        }
    }

    public void GetHitted()
    {
        animator.SetBool("hitted", false);
    }

    public static explicit operator Ghost(GameObject v)
    {
        throw new NotImplementedException();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Hit()
    {
        hit = true;
    }

    public void SetUI_Manager(UI_Manager manager)
    {
        ui_manager = manager;
    }
}
