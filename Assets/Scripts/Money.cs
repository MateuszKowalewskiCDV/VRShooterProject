using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int _money;
    public TextMeshPro _moneyIndicator, _moneyIndicatorPlayerView;

    void Start()
    {
        _money = 0;
    }

    public void AddMoney(int value)
    {
        _money += value;
        _moneyIndicator.text = _money.ToString();
        _moneyIndicatorPlayerView.text = _money.ToString();
    }
}
