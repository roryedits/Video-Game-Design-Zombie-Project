using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent Mob;
    private string animationState;
    private float waitTime;

    public GameObject Player;
    public float MobDistanceRun = 15.0f;
    public float MobDistanceAttack = 1.0f;
    public Animator animator;

    const string IDLE = "Z_Idle";
    const string CHASE = "Z_Walk";
    const string ATTACK = "Z_Attack";


    public Text Score;
    static public float kills = 0;
    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animationState = IDLE;
        waitTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Zombies Killed: " + kills;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance < MobDistanceRun && distance > MobDistanceAttack){
            if(animationState == ATTACK && (Time.time - waitTime) < 1.0f){ 
            }else{
                Vector3 dirToPlayer = transform.position - Player.transform.position;
                Vector3 newPos = transform.position - dirToPlayer;
                Mob.SetDestination(newPos);
                ChangeAnimationState(CHASE); 
            }            
        }
        if(distance > MobDistanceRun){
            Mob.SetDestination(transform.position);
            ChangeAnimationState(IDLE);
        }
        if(distance < MobDistanceAttack){
            Mob.SetDestination(transform.position);
            ChangeAnimationState(ATTACK);
            waitTime = Time.time;


        }
    }

    void ChangeAnimationState(string newAnimation){
        if(animationState != newAnimation){
            if(animationState == ATTACK && newAnimation == CHASE){}
            animator.Play(newAnimation);
            animationState = newAnimation;
        }
    }

    //killed by bullet
    public int life = 0;

    public void OnTriggerEnter(Collider collision)
    {
        //If the object that triggered this collision is tagged "bullet"
        if (collision.gameObject.tag == "Bullet")
        {
            kills++;
            Destroy(gameObject);
            
        }
    }
    }
