using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Random.rotation;
    }
}
