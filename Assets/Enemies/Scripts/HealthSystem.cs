using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int _hp;

    private int _actualHp;

    private SpriteRenderer _sprite;

    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private GameObject _textAfterFrag, _money;
    private GameObject _textAfterFragInstance, _moneyInstance;

    [SerializeField]
    private Spawners _spawnersScript;

    private GameObject _player;

    [SerializeField]
    private Material _takeDamage, _enemyMaterial;

    [SerializeField]
    private SkinnedMeshRenderer _meshRenderer;

    [SerializeField]
    private TextMeshPro _actualHpText;

    [SerializeField]
    private GameObject _end;

    private Money _moneyScript;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _moneyScript = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

        _spawnersScript = FindObjectOfType<Spawners>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        _actualHp = _hp;
        _sprite.color = new Color(0.3422728f, 0.6981132f, 0.1218405f, 1f);

        _actualHpText.text = _hp.ToString();
    }

    void Update()
    {
        transform.LookAt(_player.transform);
    }

    public void GetShot(int damage)
    {
        _actualHp -= damage;
        StartCoroutine(TakeDamageRepresentation());
        _actualHpText.text = _actualHp.ToString();

        if(_hp/2 >= _actualHp)
        {
            _sprite.color = new Color(0.8773585f, 0.657487f, 0.128293f, 1f);
        }

        if(_hp/4 >= _actualHp)
        {
            _sprite.color = new Color(0.8784314f, 0.2131751f, 0.1294117f, 1f);
        }

        if(_actualHp <= 0)
        {
            if (_hp == 120)
            {
                _moneyScript.AddMoney(3);
                for(int i = 3; i > 0; i--)
                {
                    _moneyInstance = Instantiate(_money);
                    _moneyInstance.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y + (i/5 + 0.5f), _enemy.transform.position.z);
                }
                
            }

            if (_hp == 40)
            {
                _moneyScript.AddMoney(1);
                for (int i = 1; i > 0; i--)
                {
                    _moneyInstance = Instantiate(_money);
                    _moneyInstance.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y + (i / 5 + 0.5f), _enemy.transform.position.z);
                }
            }

            if (_hp == 80)
            {
                _moneyScript.AddMoney(2);
                for (int i = 2; i > 0; i--)
                {
                    _moneyInstance = Instantiate(_money);
                    _moneyInstance.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y + (i / 5 + 0.5f), _enemy.transform.position.z);
                }
            }

            _textAfterFragInstance = Instantiate(_textAfterFrag);
            _textAfterFragInstance.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y + 1.5f, _enemy.transform.position.z);
            _spawnersScript.CountNextWave();
            Destroy(_enemy);
        }
    }

    IEnumerator TakeDamageRepresentation()
    {
        _meshRenderer.material = _takeDamage;
        yield return new WaitForSeconds(0.05f);
        _meshRenderer.material = _enemyMaterial;
    }
}
