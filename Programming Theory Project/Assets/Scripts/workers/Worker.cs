using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    public string _name;
    public string _description;

    public float Speed = 3;
    
    protected NavMeshAgent m_Agent;

    protected void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = Speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
    }

    public void Walk(Vector3 position)
    {
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }

    public virtual void DoWork()
    {

    }

    public void Speak()
    {

    }

    public void StopAction()
    {

    }
}
