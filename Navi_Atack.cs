using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Navi_Atack : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    //public GameObject target;
    public GameObject[] targets;
    private int point=0;
    Animator animator;

    private BoxCollider R;

    //距離算出＆計算用
    public GameObject Player;
    //public float D;
    Vector3 diff;


    

    // Use this for initialization
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();//アタッチされているNavMeshAgentを取得
        animator = GetComponent<Animator>();
        R = GetComponent<BoxCollider>();
        agent.SetDestination(targets[0].transform.position);

        //距離計算
        diff=Player.transform.position-agent.transform.position;
    }

    //public int point=0;



    private void Update()
    {
        Debug.Log(agent.isStopped);
        //if(!agent.pathPending && agent.remainingDistance < 0.5f)
        if(agent.remainingDistance < 0.5f)
        {
            agent.isStopped = true;
            Debug.Log(agent.isStopped);
            //Setmotion(ref agent,ref animator,ref targets[point]);
            
            if (agent.isStopped == true)
            {

                animator.SetBool("Attack",true);
            
                agent.isStopped = false;
                //agent.SetDestination(target.transform.position);
    
                   
                    Setposition(ref point,targets);
                    Debug.Log(point);
                

            }

            /*Setposition(ref point,targets);
            Debug.Log(point);*/
            

        }
        else
        {
            
            animator.SetBool("Attack",false);
        }


        //agent.SetDestination(targets[point].transform.position);

        //距離計算
        diff=Player.transform.position-agent.transform.position;
        if(diff.magnitude < 5.5f) //magnitudeは絶対値
        {
            agent.SetDestination(Player.transform.position);
            
        }
        else
        {
            agent.SetDestination(targets[point].transform.position);
            
        }
        
    
    }

    

    void Setposition(ref int point,GameObject[] targets)
    //void Setposition(ref int point)
    {

        if(point==(targets.Length-1))
        //if (point==0)
        {
            point=0;
        }
        else
        {
            point++;
        }

    }

    //オブジェクトと接触した瞬間に呼び出される
    void OnTriggerEnter(Collider other)
    {

        
 
        //攻撃した相手がEnemyの場合
        if(other.CompareTag("PlayerA")){
            
            animator.SetTrigger("A");
            //Destroy(other.gameObject);
 
        }
    }


//ここまで！

    
    

    /*void Setmotion(ref UnityEngine.AI.NavMeshAgent agent,ref Animator animator,ref GameObject target)
    {
        Debug.Log(target.tag);
        if(agent.remainingDistance < 0.5f)
        {
            Debug.Log(agent.isStopped);
            agent.isStopped = true;
            if (agent.isStopped == true)
            {
                if(target.tag=="PlayerA")
                {
                    animator.SetBool("W",true);
                }
                else
                {
                    animator.SetBool("V",true);
                }
            }
            else
            {
                if(target.tag=="PlayerA")
                {
                    animator.SetBool("W",false);
                }
                else
                {
                    animator.SetBool("V",false);
                }
            }

        }


        agent.SetDestination(targets[point].transform.position);
     
    }*/
    


}