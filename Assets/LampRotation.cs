using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampRotation : MonoBehaviour
{
    [SerializeField]
    private float _rotationValue;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotationValue));
    }
}
