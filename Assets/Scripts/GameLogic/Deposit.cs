using Assets.Scripts;
using Assets.Scripts.GameLogic;
using TMPro;
using UnityEngine;

public class Deposit : Sound, TemplateObject
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject notifyCounter;
    [SerializeField] private Money money;
    [SerializeField] private string tag;
    [SerializeField] private float deposit;

    public float GetDeposit()
    {
        return deposit;
    }

    private void Start()
    {
        money.moneyDepositAdd += AddMoneyToDeposit;
        money.moneyDepositRemove += RemoveMoneyToDeposit;
        Initialized();
    }

    public void Clear()
    {
        Initialized();
    }

    private void Initialized()
    {
        if (!PlayerPrefs.HasKey(tag)) PlayerPrefs.SetFloat(tag, 100);
        deposit = PlayerPrefs.GetFloat(tag);
        UpdateText(deposit);
    }

    private void AddMoneyToDeposit(float bonus)
    {
        PlaySound(0, volume);
        notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
        notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(bonus);
        deposit += bonus;
        UpdateText(deposit);
    }

    private void RemoveMoneyToDeposit(float minus)
    {
        PlaySound(0, volume);
        notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
        notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(-1 * minus);
        deposit -= minus;
        UpdateText(deposit);
    }

    private void UpdateText(float deposit)
    {
        text.text = $"{deposit}";
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(tag,deposit);
        money.moneyDepositAdd -= AddMoneyToDeposit;
        money.moneyDepositRemove -= RemoveMoneyToDeposit;
    }
}
