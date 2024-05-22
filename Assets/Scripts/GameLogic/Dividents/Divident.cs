using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Divident : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textDescription;
    [SerializeField] private DividentCounter counter;
    [SerializeField] protected GameObject answerPanel;
    [SerializeField] private Deposit deposit;
    [SerializeField] private Money money;
    [SerializeField] private Button buyButton;

    private GameObject dividentItem;
    private string answer;
    private bool check;
    private float price;
    private float dividents_plus = 0;
    private float dividents_minus = 0;

    public void IsOpen(GameObject dividentItem, string answer, string description)
    {
        this.dividentItem = dividentItem;
        var item = dividentItem.GetComponent<DividentItem>();
        if (deposit.GetDeposit() >= price) buyButton.interactable = true;
        else buyButton.interactable = false;
        this.answer = answer;
        this.price = item.Price;
        this.check = item.Check;
        this.dividents_plus = item.Dividents_plus;
        this.dividents_minus = item.Dividents_minus;
        textDescription.text = "Описание: " + description;
        textName.text = item.DividentName;
    }

    public void BuyX1()
    {
        if (deposit.GetDeposit() >= price)
        {
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
    }

    public void BuyX2()
    {
        if (deposit.GetDeposit() >= price)
        {
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
    }

    public void Buy()
    {
        if (deposit.GetDeposit() >= price)
        {
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
    }

    public void Sell()
    {
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

    private void DividentItemLock()
    {
        dividentItem.GetComponent<DividentItem>().Lock();
        PlayerPrefs.SetInt(textName.text, 1);
    }
}
