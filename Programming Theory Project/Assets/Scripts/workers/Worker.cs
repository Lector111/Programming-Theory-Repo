using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Worker : MonoBehaviour
{
    public string _name;
    public string _description;
    public int _gatherPerSecond = 10;

    public float Speed = 3;

    public Text _speachTextUI;
    public string _speachText;
    
    protected NavMeshAgent m_Agent;
    private Resource _target;

    public void Start()
    {
        _speachTextUI.text = _speachText;
        _speachTextUI.gameObject.SetActive(false);
    }

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
        Vector3 offset = new Vector3(0f, 0.6f, 0f);
        Vector3 textPos = Camera.main.WorldToScreenPoint(this.transform.position + offset);
        _speachTextUI.transform.position = textPos;
        if (_speachTextUI.IsActive())
        {
            if (_secondsToHideText > 0)
            {
                _secondsToHideText -= Time.deltaTime;
            }
            else
            {
                _speachTextUI.gameObject.SetActive(false);
            }
        }
        
    }

    private float _secondsToHideText = 0;
    public void ShowText()
    {
        if (!_speachTextUI.IsActive())
        {
            _speachTextUI.gameObject.SetActive(true);
            _secondsToHideText = 3;
        }
    }
}
