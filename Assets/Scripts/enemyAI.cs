using UnityEngine;
using UnityEngine.AI;
//using System.Collections;
//using UnityEditor;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public enum State { Idle, Aggressive, Attack }
    public State currentState = State.Idle;

    private NavMeshAgent agent;
    private Animator anim;
    public Transform player;

    [Header("Настройки дистанции")]
    public float detectionRange = 1.5f;
    public float attackRange = 1f; // Уменьшили, чтобы он подходил ближе

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        // Если забыла перетащить камеру в инспекторе, скрипт попытается найти её сам
        if (player == null && Camera.main != null)
            player = Camera.main.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Вот тот самый метод UpdateState (логика переключения состояний)
        UpdateState(distance);
        HandleBehavior();
    }

    void UpdateState(float distance)
    {
        if (distance > detectionRange)
            currentState = State.Idle;
        else if (distance <= detectionRange && distance > attackRange)
            currentState = State.Aggressive;
        else
            currentState = State.Attack;
    }

    //IEnumerator ChangeState()
    //{
        //yield return new WaitForSeconds(2f);
        //currentState = State.Aggressive;
    //}

    void HandleBehavior()
    {
        switch (currentState)
        {
            case State.Idle:
                agent.isStopped = true;
                if (anim) anim.SetBool("isMoving", false);
                break;

            case State.Aggressive:
                agent.isStopped = false;
                agent.SetDestination(player.position);
                if (anim) anim.SetBool("isMoving", true);
                break;

            case State.Attack:
                agent.isStopped = true;
                if (anim) anim.SetBool("isMoving", false);
                if (anim) anim.SetTrigger("attack");
                LookAtPlayer(); // Поворачиваемся лицом к игроку
                break;
        }
    }

    void LookAtPlayer()
    {
        // Вычисляем направление, игнорируя высоту (чтобы враг не заваливался назад/вперед)
        Vector3 targetPostition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPostition);
    }
}