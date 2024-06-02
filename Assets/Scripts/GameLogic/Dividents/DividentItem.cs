using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DividentItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textDividents_plus;
    [SerializeField] private TextMeshProUGUI textDividents_minus;
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private SaveService saveService;
    [SerializeField] private Text textDescription;
    [SerializeField] private Text textAnswer;
    [SerializeField] private GameObject divident;
    [SerializeField] private Image panel;
    [SerializeField] private Button goButton;
    [SerializeField] private Money money;

    [SerializeField] private string dividentName;
    [SerializeField] private float potential;
    [SerializeField] private float dividents_plus;
    [SerializeField] private float dividents_minus;
    [SerializeField] private float price;
    [SerializeField] private int id;
    [SerializeField] private bool check;
    //[SerializeField] private TextMeshProUGUI textPotential_plus;
    //[SerializeField] private TextMeshProUGUI textPotential_minus;

    public string DividentName => dividentName;
    public float Potential => potential;
    public float Dividents_plus => dividents_plus;
    public float Dividents_minus => dividents_minus;
    public float Price => price;    
    public bool Check => check;

    private void Start()
    {
        if (saveService.Data.lockedDividents.Length != 0)
        {
            if (saveService.Data.lockedDividents[id] == true) Lock();
        }
        textName.text = dividentName;
        //textPotential_plus.text = potential.ToString();
        //textPotential_minus.text = "-" +  potential.ToString();
        textDividents_plus.text = "+" + dividents_plus.ToString();
        textDividents_minus.text = dividents_minus.ToString();
        textPrice.text = price.ToString();
    }

    public void Lock()
    {
        goButton.interactable = false;
        panel.color = new Color(0,0,0,0.80f);  
        textDividents_minus.gameObject.SetActive(false);
        textDividents_plus.gameObject.SetActive(false);

    }

    public void OpenCompanyWindow()
    {
        divident.GetComponent<Divident>().IsOpen(gameObject,textAnswer.text, textDescription.text, id);
        divident.SetActive(true);
    }
}

