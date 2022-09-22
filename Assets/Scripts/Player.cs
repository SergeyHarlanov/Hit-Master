using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Move), typeof(Attack))]
public class Player : MonoBehaviour
{
    public bool Move { get;  set; }
    public bool Attack { get;  set; }
    
    private NavMeshAgent _navMeshAgent;
    
    private StateMachine _move;
    private StateMachine _attack;

    public void StartMoveabled()
    {
        StartCoroutine(MoveabledToPoint());
    }
     private  void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _move = GetComponent<Move>();
        _attack = GetComponent<Attack>();

    }

    private IEnumerator MoveabledToPoint()
    {
        int currentPoint = 0;

        while (true)
        {
            if (currentPoint >= GameProperty.Instance.Points.Length)
            {
                yield return new WaitForSeconds(1F);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                
                yield break;
            }
            
            if (currentPoint != 0)  GameProperty.Instance.Points[currentPoint -1].gameObject.SetActive(false);
            _navMeshAgent.SetDestination(GameProperty.Instance.Points[currentPoint].position);
            
            _move.StartState();
            yield return new WaitUntil(() =>  !Move);
            
            _attack.StartState();
            yield return new WaitUntil(() => !Attack);
            
            currentPoint++;
        }
    }
}
