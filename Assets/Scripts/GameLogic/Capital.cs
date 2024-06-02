using Assets.Scripts;
using Assets.Scripts.GameLogic;
using TMPro;
using UnityEngine;

public class Capital : Sound, TemplateObject
{
    [SerializeField] private SaveService saveService;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject notifyCounter;
    [SerializeField] private Money money;
    [SerializeField] private string tag;
    [SerializeField] private float capital;

    public float GetCapital()
    {
        return capital;
    }

    private void Awake()
    {
        money.moneyCapitalAdd += AddMoneyToCapital;
        money.moneyCapitalRemove += RemoveMoneyToCapital;
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
        capital = saveService.Data.capital;
        UpdateText(capital);
    }

    private void AddMoneyToCapital(float bonus)
    {
        PlaySound(0, volume);
        notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
        notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(bonus);
        capital += bonus;
        saveService.Data.capital = capital;
        UpdateText(capital);
    }

    private void RemoveMoneyToCapital(float minus)
    {
        PlaySound(0,volume);
        notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
        notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(-1 * minus);
        capital -= minus;
        saveService.Data.capital = capital;
        UpdateText(capital);
    }

    private void UpdateText(float capital)
    {
        text.text = $"{capital}";
    }

    private void OnDestroy()
    {
        money.moneyCapitalAdd -= AddMoneyToCapital;
        money.moneyCapitalRemove -= RemoveMoneyToCapital;
    }
}
