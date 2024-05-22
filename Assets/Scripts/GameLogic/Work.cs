using UnityEngine;

public class Work : MonoBehaviour
{
    [SerializeField] private Money money;
    public int bonus=1;

    private void Start()
    {

    }

    public void ButtonClick()
    {
        money.AddCapitalUpdate(bonus);
        money.AddDepositUpdate(bonus);
    }
}
