using Assets.Scripts;
using Assets.Scripts.GameLogic;
using TMPro;
using UnityEngine;

public class Deposit : Sound, TemplateObject
{
    [SerializeField] private SaveService saveService;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject notifyCounter;
    [SerializeField] private Money money;
    [SerializeField] private string tag;
    [SerializeField] private float deposit;

    public float GetDeposit()
    {
        return deposit;
    }

    private void Awake()
    {
        money.moneyDepositAdd += AddMoneyToDeposit;
        money.moneyDepositRemove += RemoveMoneyToDeposit;
    }

    private void Start()
    {
        Initialized();
    }

    public void Clear()
    {
        Initialized();
    }

    private void Initialized()
    {
        deposit = saveService.Data.deposit;
        UpdateText(deposit);
    }

    private void AddMoneyToDeposit(float bonus)
    {
        PlaySound(0, volume);
        notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
        notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(bonus);
        deposit += bonus;
        saveService.Data.deposit = deposit;
        UpdateText(deposit);
    }

    private void RemoveMoneyToDeposit(float minus)
    {
        PlaySound(0, volume);
        notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
        notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(-1 * minus);
        deposit -= minus;
        saveService.Data.deposit = deposit;
        UpdateText(deposit);
    }

    private void UpdateText(float deposit)
    {
        text.text = $"{deposit}";
    }

    private void OnDestroy()
    {
        money.moneyDepositAdd -= AddMoneyToDeposit;
        money.moneyDepositRemove -= RemoveMoneyToDeposit;
    }
}
