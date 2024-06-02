using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Money money;
    [SerializeField] private Capital capital;
    [SerializeField] private GameObject barObject;
    [SerializeField] private SaveService saveService;
    [SerializeField] private RectTransform healthLine;
    [SerializeField] private TextMeshProUGUI textTarget;
    [SerializeField] private TextMeshProUGUI textLevel;
    private float target = 1000;
    private float maxHealth;
    private float fill=0;
    private int level = 1;

    public float MaxHealth { get=>maxHealth; set => maxHealth = value; }

    public void Awake()
    {
        money.moneyCapitalAdd += UpdateProgress;
    }

    public void Start()
    {
        healthLine.GetComponent<Image>().fillAmount = saveService.Data.capital / saveService.Data.target;
        level=saveService.Data.level;
        target = saveService.Data.target;
        textLevel.text = $"{level}";
        textTarget.text = $"{target}";
    }

    public void UpdateProgress(float bonus)
    {
        fill = capital.GetCapital() / target;
        healthLine.GetComponent<Image>().fillAmount= fill;
        if (fill > 1)
        {
            level += 1;
            target *= 10;
            textLevel.text = $"{level}";
            textTarget.text = $"{target}";
            healthLine.GetComponent<Image>().fillAmount = capital.GetCapital() / target;
        }
        saveService.Data.level = level;
        saveService.Data.target = target;
    }

    private void OnDestroy()
    {
        money.moneyCapitalAdd -= UpdateProgress;    
    }
}
