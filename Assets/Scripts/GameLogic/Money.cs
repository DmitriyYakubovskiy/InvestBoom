using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    public event Action<float> moneyDepositRemove;
    public event Action<float> moneyDepositAdd;
    public event Action<float> moneyCapitalRemove;
    public event Action<float> moneyCapitalAdd;

    public void AddDepositUpdate(float bonus)
    {
        moneyDepositAdd?.Invoke(bonus);
    }

    public void RemoveDepositUpdate(float minus)
    {
        moneyDepositRemove?.Invoke(minus);
    }

    public void AddCapitalUpdate(float bonus)
    {
        moneyCapitalAdd?.Invoke(bonus);
    }

    public void RemoveCapitalUpdate(float minus)
    {
        moneyCapitalRemove?.Invoke(minus);
    }
}
