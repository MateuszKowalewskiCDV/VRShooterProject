using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLights : MonoBehaviour
{
    private Light _light;
    private float _time;

    void Start()
    {
        _light = GetComponent<Light>();
        StartCoroutine(Lights());
    }

    IEnumerator Lights()
    {
        _light.color = new Color(1, 1, 1, 1);
        _light.range = 10;
        yield return new WaitForSeconds(8f);
        _light.color = new Color(1, 0, 0, 1);
        _light.range = 100;
        yield return new WaitForSeconds(8f);
        StartCoroutine(Lights());
    }
}
