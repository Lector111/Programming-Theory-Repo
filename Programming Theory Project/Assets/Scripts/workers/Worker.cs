using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Worker : MonoBehaviour
{
    public string _name;
    public string _description;
    public int _gatherPerSecond = 10;

    public float Speed = 3;
    
    protected NavMeshAgent m_Agent;
    private Resource _target;

    public void SetResource(Resource res)
    {
        _target = res;
        if (_target != null)
        {
            m_Agent.SetDestination(_target.transform.position);
            m_Agent.isStopped = false;
        }
    }
    public Resource GetResource()
    {
        return _target;
    }
    protected void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = Speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
    }

    public void Walk(Vector3 position)
    {
        _target = null;
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }
    public abstract void Walk(Resource target);

    public virtual void DoWork()
    {

    }

    public void Speak()
    {

    }

    public void StopAction()
    {

    }

    private void Update()
    {
        if (_target != null)
        {
            float distance = Vector3.Distance(_target.transform.position, transform.position);
            if (distance < 1.0f)
            {
                m_Agent.isStopped = true;
                UIScript.CountResource(_target._type, _gatherPerSecond);
            }
        }
    }
}
