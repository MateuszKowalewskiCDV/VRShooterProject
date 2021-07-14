using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLights : MonoBehaviour
{
    [SerializeField]
    private Light _mainLight;

    [SerializeField]
    private GameObject _alarmLight;

    [SerializeField]
    private float _rotationValue;

    [SerializeField]
    private float _time;

    void Start()
    {
        StartCoroutine(Lights());
    }

    IEnumerator Lights()
    {
        _alarmLight.gameObject.SetActive(false);
        _mainLight.gameObject.SetActive(true);
        yield return new WaitForSeconds(_time);
        _alarmLight.gameObject.SetActive(true);
        _mainLight.gameObject.SetActive(false);
        yield return new WaitForSeconds(_time);
        StartCoroutine(Lights());
    }
}
