using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawners : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _mobList, _spawners;

    [SerializeField]
    private int[] _bigOnesAmmount, _walkersAmmount, _runnersAmmount;

    [SerializeField]
    private GameObject _end;

    public int mobCounter;

    public int _waveNumber;

    private int _randomSpawnValue;

    [SerializeField]
    public int _lastStageIndex;

    [SerializeField]
    private TextMeshPro _levelIndicator;

    void Start()
    {
        _waveNumber = 0;
        Next(_waveNumber);
    }

    void SpawnThem(int _bigOnes, int _walkers, int _runners)
    {
        for (int i = _bigOnes; i > 0; i--)
        {
            Instantiate(_mobList[0], _spawners[Random.Range(0, 4)].transform.position, Quaternion.identity);
        }
        for (int i = _walkers; i > 0; i--)
        {
            Instantiate(_mobList[1], _spawners[Random.Range(0, 4)].transform.position, Quaternion.identity);
        }
        for (int i = _runners; i > 0; i--)
        {
            Instantiate(_mobList[2], _spawners[Random.Range(0, 4)].transform.position, Quaternion.identity);
        }
    }
    public void CountNextWave()
    {
        mobCounter--;
        if (mobCounter == 0)
        {
            if (_waveNumber == _lastStageIndex)
            {
                _levelIndicator.text = "The end";
                _end.SetActive(true);
            }
            else
            {
                _waveNumber++;
                Next(_waveNumber);
            }
        }
    }

    public void Next(int waveNumber)
    {
        _levelIndicator.text = "Level: " + (waveNumber + 1);
        mobCounter = _bigOnesAmmount[waveNumber] + _walkersAmmount[waveNumber] + _runnersAmmount[waveNumber];
        SpawnThem(_bigOnesAmmount[waveNumber], _walkersAmmount[waveNumber], _runnersAmmount[waveNumber]);
    }
}
