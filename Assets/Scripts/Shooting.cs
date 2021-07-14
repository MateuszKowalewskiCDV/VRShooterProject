using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using Valve.VR;
using TMPro;

public class Shooting : MonoBehaviour
{
    public SteamVR_Action_Boolean booleanAction;
    private bool _triggerValue;
    private bool isReady = true;
    private AudioSource _sound;
    private ParticleSystem _particle;

    [SerializeField]
    private GameObject _explosion, _end;

    private GameObject _enemy;

    [SerializeField]
    private Spawners _spawnersScript;

    private HealthSystem _enemyHP;

    [SerializeField]
    private Light laser1, laser2;

    [SerializeField]
    private int _weaponDamage;

    [SerializeField]
    private Shooting _secondWeapon;

    public TextMeshPro _coinsIndicator;

    [SerializeField]
    private Money _moneyScript;

    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _particle = GetComponentInChildren<ParticleSystem>();
        _moneyScript._moneyIndicatorPlayerView.text = _moneyScript._money.ToString();
    }

    private void Update()
    {
        _triggerValue = booleanAction.state;

        if (_triggerValue == true)
        {
            if(isReady == true)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
                {
                    _sound.PlayOneShot(_sound.clip);
                    _particle.Play();

                    if (hit.transform.gameObject.CompareTag("Start"))
                    {
                        Destroy(hit.transform.gameObject);
                        _spawnersScript.gameObject.SetActive(true);
                    }

                    if (hit.transform.gameObject.CompareTag("Enemy"))
                    {
                        _enemy = hit.transform.gameObject;
                        _enemyHP = _enemy.GetComponentInChildren<HealthSystem>();
                        _enemyHP.GetShot(_weaponDamage);
                    }

                    if (hit.transform.gameObject.CompareTag("Head"))
                    {
                        Debug.Log("HEADSHOT");
                        _enemy = hit.transform.gameObject;
                        _enemyHP = _enemy.GetComponentInChildren<HealthSystem>();
                        _enemyHP.GetShot(_weaponDamage*2);
                    }

                    if (hit.transform.gameObject.CompareTag("End"))
                    {
                        _spawnersScript._waveNumber = 0;
                        _spawnersScript.Next(_spawnersScript._waveNumber);
                        _end.SetActive(false);
                    }

                    if (hit.transform.gameObject.CompareTag("Upgrade1") && _moneyScript._money >= 20)
                    {
                        _moneyScript._money -= 20;
                        _moneyScript._moneyIndicatorPlayerView.text = _moneyScript._money.ToString();
                        _coinsIndicator.text = _moneyScript._money.ToString();
                        laser1.gameObject.SetActive(true);
                        laser2.gameObject.SetActive(true);
                        hit.transform.gameObject.SetActive(false);
                    }

                    if (hit.transform.gameObject.CompareTag("Upgrade2") && _moneyScript._money >= 40)
                    {
                        _moneyScript._money -= 40;
                        _moneyScript._moneyIndicatorPlayerView.text = _moneyScript._money.ToString();
                        _coinsIndicator.text = _moneyScript._money.ToString();
                        _weaponDamage *= 2;
                        _secondWeapon._weaponDamage *= 2;
                        hit.transform.gameObject.SetActive(false);
                    }

                    Instantiate(_explosion, hit.point, Quaternion.identity);
                    isReady = false;
                    StartCoroutine("ShootsCooldown");
                }
            }
        }
    }

    IEnumerator ShootsCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        isReady = true;
    }
}

