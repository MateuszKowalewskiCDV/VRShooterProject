using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private NavMeshAgent _agent;
    private Animator _anim;
    private bool _attacking;
    private AudioSource _audio;
    private Money _moneyScript;

    void Start()
    {
        _attacking = false;
        _player = GameObject.FindGameObjectWithTag("Player");

        _audio = GetComponent<AudioSource>();
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        _moneyScript = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();
    }

    void Update()
    {
        if(_attacking == false)
        {
            _agent.SetDestination(_player.transform.position);
        }

        else
        {
            _agent.SetDestination(transform.position);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_audio.isPlaying)
            {
                _audio.Play();
                if(_moneyScript._money > 0)
                {
                    _moneyScript._money--;
                    _moneyScript._moneyIndicator.text = _moneyScript._money.ToString();
                }
            }
            
            if (_attacking != true || _anim.GetInteger("ZombieState") != 2)
            {
                _attacking = true;
                _anim.SetInteger("ZombieState", 2);
            }

            transform.LookAt(_player.transform);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _anim.SetInteger("ZombieState", 1);
            _attacking = false;
            _agent.SetDestination(_player.transform.position);
        }
    }
}
