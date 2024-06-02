using Assets.Scripts;
using Assets.Scripts.GameLogic;
using TMPro;
using UnityEngine;

public class DividentCounter : Sound,TemplateObject
{
    [SerializeField] private SaveService saveService;
    [SerializeField] private GameObject notifyCounter;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Money money;
    [SerializeField] string tag;
    [SerializeField] private float bonus;
    private float startTime = 12;
    private float time=0;

    public float Bonus
    {
        get => bonus;
        set
        {
            PlaySound(0, volume);
            notifyCounter.GetComponent<NotifyMoneyCounter>().Activate();
            notifyCounter.GetComponent<NotifyMoneyCounter>().AddMoney(value-bonus);
            bonus = value;
            saveService.Data.divident = bonus;
            UpdateText();
        }
    }

    private void Awake()
    {
        time=startTime;
    }

    private void Start()
    {
        Initialized();
    }

    private void Update()
    {
        if (RecounterTime())
        {
            money.AddCapitalUpdate(bonus);
            money.AddDepositUpdate(bonus);
            time = startTime;
        }    
    }

    public void Clear()
    {
        Initialized();
    }

    private void Initialized()
    {
        bonus = saveService.Data.divident;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = $"{bonus}";
    }

    private bool RecounterTime()
    {
        if (time <= 0) return true;
        time -= Time.deltaTime;
        return false;
    }
}
