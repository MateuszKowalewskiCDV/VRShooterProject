using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillTitles : MonoBehaviour
{ 
    [SerializeField]
    private string[] titles;

    private TextMeshPro _text;
    private int _titleNumber;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _text = GetComponent<TextMeshPro>();
        _titleNumber = Random.Range(0, titles.Length);
        StartCoroutine(DestroyAfter1Second());
    }

    void Update()
    {
        transform.LookAt(_player.transform);
    }

    IEnumerator DestroyAfter1Second()
    {
        _text.text = titles[_titleNumber];
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
