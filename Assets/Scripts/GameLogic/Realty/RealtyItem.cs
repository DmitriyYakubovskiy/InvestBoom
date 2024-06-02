using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RealtyItem : MonoBehaviour
{
    [SerializeField] private SaveService saveService;
    [SerializeField] private RectTransform healthLine;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI collectText;
    [SerializeField] protected TextMeshProUGUI statusText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button collectButton;
    [SerializeField] private Deposit deposit;
    [SerializeField] private Money money;
    [SerializeField] private string name;
    [SerializeField] private float price;
    [SerializeField] private float bonus;
    [SerializeField] private float startTime;
    [SerializeField] private float arentStartTime;
    [SerializeField] private float arentTime;
    [SerializeField] private int id;

    private bool isBuy = false;
    private bool isSearchArent=false;
    private float sumMoney = 0;
    private float fill = 0;
    private float time = 0;
    private float timeA = 0;

    private void Awake()
    {
        priceText.text = price.ToString();
    }

    private void Start()
    {
        healthLine.GetComponent<Image>().fillAmount = time / startTime;
        isBuy = saveService.Data.openRealtyAndBusiness[id];
        sumMoney = saveService.Data.sumRealtyAndBusiness[id];
        collectText.text = sumMoney.ToString();
        if (isBuy)
        {
            buyButton.interactable = false;
            collectButton.interactable = true;
        }
        else
        {
            buyButton.interactable = true;
            collectButton.interactable = false;
        }
    }

    public void Update()
    {
        if (isBuy)
        {
            StartAddBonus();
            time += Time.deltaTime;
            timeA+= Time.deltaTime; 
        }
    }

    public void Buy()
    {
        if (deposit.GetDeposit() >= price)
        {
            saveService.Data.openRealtyAndBusiness[id] = true;
            money.RemoveDepositUpdate(price);
            buyButton.interactable = false;
            collectButton.interactable = true;
            isBuy = true;
        }
    }

    public void Collect()
    {
        if (!isBuy) return;
        money.AddCapitalUpdate(sumMoney);
        money.AddDepositUpdate(sumMoney);
        sumMoney = 0;
        saveService.Data.sumRealtyAndBusiness[id] = sumMoney;
        collectText.text = sumMoney.ToString();
    }

    private void AddBonus()
    {
        sumMoney += bonus;
        collectText.text = sumMoney.ToString();
        saveService.Data.sumRealtyAndBusiness[id] = sumMoney;
    }

    private void StartAddBonus()
    {
        if (time >= startTime && !isSearchArent)
        {
            time = 0;
            AddBonus(); 
        }
        if (timeA >= arentTime && isSearchArent)
        {
            time = 0;
            timeA = 0;  
            isSearchArent = false;  
        }
        if(timeA >= arentStartTime && !isSearchArent)
        {
            timeA = 0;
            isSearchArent = true;
        }
        if (isSearchArent)
        {
            healthLine.GetComponent<Image>().fillAmount = timeA / arentTime;
            statusText.text = "Поиск арендатора";
        }
        else
        {
            healthLine.GetComponent<Image>().fillAmount = time / startTime;
            statusText.text = "";
        }
    }
}
