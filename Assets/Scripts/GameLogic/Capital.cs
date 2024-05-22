using Assets.Scripts;
using Assets.Scripts.GameLogic;
using TMPro;
using UnityEngine;

public class Capital : Sound, TemplateObject
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject notifyCounter;
    [SerializeField] private Money money;
    [SerializeField] private string tag;
    [SerializeField] private float capital;

    public float GetCapital()
    {
        return capital;
    }

    private void Start()
    {
        money.moneyCapitalAdd += AddMoneyToDeposit;
        money.moneyCapitalRemove += RemoveMoneyToDeposit;
        Initialized();
    }

    public void Clear()
    {
        Initialized();
    }

    private void Initialized()
    {
        if (!PlayerPrefs.HasKey(tag)) PlayerPrefs.SetFloat(tag, 100);
        capital = PlayerPrefs.GetFloat(tag);
        UpdateText(capital);
    }

    private void AddMoneyToDeposit(float bonus)
    {
        PlaySound(0, volume);
        notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
        notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(bonus);
        capital += bonus;
        UpdateText(capital);
    }

    private void RemoveMoneyToDeposit(float minus)
    {
        PlaySound(0,volume);
        notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
        notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(-1 * minus);
        capital -= minus;
        UpdateText(capital);
    }

    private void UpdateText(float capital)
    {
        text.text = $"{capital}";
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(tag, capital);
        money.moneyCapitalAdd -= AddMoneyToDeposit;
        money.moneyCapitalRemove -= RemoveMoneyToDeposit;
    }
}
