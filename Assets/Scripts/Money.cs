using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int _money;
    public TextMeshPro _moneyIndicator;

    void Start()
    {
        _money = 0;
    }

    public void AddMoney()
    {
        _money += 2;
        _moneyIndicator.text = _money.ToString();
    }
}
