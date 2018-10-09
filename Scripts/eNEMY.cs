using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eNEMY : MonoBehaviour
{

    private State enemy;

    public float rawSpeed = 100f;
    public float Speed = 3f;
    public GameObject Player;

    //public int Isdead;

    private bool isWandering = false;
    private bool isWalking = false;
    //private PlayerHop DeadState;


    private void Start()
    {

        enemy = eNEMY.State.Patrol;
        StartCoroutine("FSM");
       // Isdead = 0;
    }

    private enum State
    {
        Initialize = 0,
        Idle = 1,
        Patrol = 2,
    }

    private IEnumerator FSM()
    {
        while (true)
        {
            switch (enemy)
            {
                case State.Initialize:
                    Initialize();
                    break;
                case State.Idle:
                    Idle();
                    break;
                case State.Patrol:
                    Patrol();
                    break;

            }
            yield return null;
        }
    }

    private void Initialize()
    {
        Debug.Log("initialize");
    }

    private void Idle()
    {
       // Isdead = 1;
    }

    private void Patrol()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());

        }
        if (isWalking == true)
        {
            transform.LookAt(Player.transform);
            transform.position += transform.forward * Time.deltaTime * Speed;
        }
    }

    IEnumerator Wander()
    {
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        isWandering = false;
    }

    private void OnTriggerEnter(Collider walls)
    {
        if (walls.CompareTag("Player"))
        {
            enemy = eNEMY.State.Idle;
        }
    }

   // private void OnTriggerExit(Collider walls)
    //{
      //  if (walls.CompareTag("Player"))
       // {
         //   enemy = eNEMY.State.Idle;
       // }
    //}

}
