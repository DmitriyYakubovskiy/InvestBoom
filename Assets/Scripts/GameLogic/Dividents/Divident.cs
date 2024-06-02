using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Divident : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textDescription;
    [SerializeField] private DividentCounter counter;
    [SerializeField] protected GameObject answerPanel;
    [SerializeField] private SaveService saveService;
    [SerializeField] private Deposit deposit;
    [SerializeField] private Money money;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;

    private GameObject dividentItem;
    private string answer;
    private bool check;
    private float price;
    private float dividents_plus = 0;
    private float dividents_minus = 0;
    private int id;

    public void IsOpen(GameObject dividentItem, string answer, string description, int id)
    {
        this.dividentItem = dividentItem;
        var item = dividentItem.GetComponent<DividentItem>();
        this.price = item.Price;
        if (deposit.GetDeposit() >= price)
        {
            buyButton.interactable = true;
            sellButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
            sellButton.interactable = false;
        }
        this.answer = answer;
        this.check = item.Check;
        this.dividents_plus = item.Dividents_plus;
        this.dividents_minus = item.Dividents_minus;
        this.id = id;
        textDescription.text = "Описание: " + description;
        textName.text = item.DividentName;
    }

    public void BuyX1()
    {
        if (deposit.GetDeposit() >= price)
        {
            buyButton.interactable = true;
            sellButton.interactable = true;
            if (check)
            {
                counter.Bonus += dividents_plus;
                money.RemoveDepositUpdate(price);
                money.AddCapitalUpdate(price);

            }
            else
            {
                counter.Bonus += 0;
                money.RemoveDepositUpdate(0);
                money.RemoveCapitalUpdate(0);
            }
            answerPanel.GetComponent<AnswerPanel>().IsOpen(textName.text, answer);
            answerPanel.SetActive(true);
            DividentItemLock();
        }
        else
        {
            buyButton.interactable = false;
            sellButton.interactable = false;
        }
    }

    public void BuyX2()
    {
        if (deposit.GetDeposit() >= price)
        {
            buyButton.interactable = true;
            sellButton.interactable = true;
            if (check)
            {
                counter.Bonus += 0;
                money.RemoveDepositUpdate(0);
                money.AddCapitalUpdate(0);

            }
            else
            {
                counter.Bonus += dividents_plus;
                money.RemoveDepositUpdate(price);
                money.AddCapitalUpdate(price);
            }
            answerPanel.GetComponent<AnswerPanel>().IsOpen(textName.text, answer);
            answerPanel.SetActive(true);
            DividentItemLock();
        }
        else
        {
            buyButton.interactable = false;
            sellButton.interactable = false;
        }
    }

    public void Buy()
    {
        if (deposit.GetDeposit() >= price)
        {
            buyButton.interactable = true;
            sellButton.interactable = true;
            if (check)
            {
                counter.Bonus += dividents_plus;
                money.RemoveDepositUpdate(price);
                money.AddCapitalUpdate(price);

            }
            else
            {
                counter.Bonus += dividents_minus;
                money.RemoveDepositUpdate(price);
                money.RemoveCapitalUpdate(price);
            }
            answerPanel.GetComponent<AnswerPanel>().IsOpen(textName.text, answer);
            answerPanel.SetActive(true);
            DividentItemLock();
        }
        else
        {
            buyButton.interactable = false;
            sellButton.interactable = false;
        }
    }

    public void Sell()
    {
        if (deposit.GetDeposit() >= price)
        {
            buyButton.interactable = true;
            sellButton.interactable = true;
            if (check)
            {
                money.RemoveDepositUpdate(price);
                money.RemoveCapitalUpdate(price);
                counter.Bonus += 0;
            }
            else
            {
                money.RemoveDepositUpdate(0);
                money.RemoveCapitalUpdate(0);
                counter.Bonus += 0;
            }
            answerPanel.GetComponent<AnswerPanel>().IsOpen(textName.text, answer);
            answerPanel.SetActive(true);
            DividentItemLock();
        }
        else
        {
            buyButton.interactable = false;
            sellButton.interactable = false;
        }
    }

    private void DividentItemLock()
    {
        dividentItem.GetComponent<DividentItem>().Lock();
        saveService.Data.lockedDividents[id]=true;
    }
}
