using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Money money;
    [SerializeField] private Capital capital;
    [SerializeField] private GameObject barObject;
    [SerializeField] private RectTransform healthLine;
    private float target = 1000000;
    private float maxHealth;
    private float fill=0;

    public float MaxHealth { get=>maxHealth; set => maxHealth = value; }

    public void Awake()
    {
        money.moneyCapitalAdd += UpdateProgress; 
        fill = capital.GetCapital() / target;
    }

    public void FixedUpdate()
    {
        if (healthLine.GetComponent<Image>().fillAmount != fill)
        {
            healthLine.GetComponent<Image>().fillAmount = fill;
        }
    }

    public void UpdateProgress(float bonus)
    {
        fill = capital.GetCapital() / target;
    }

    private void OnDestroy()
    {
        money.moneyCapitalAdd -= UpdateProgress;    
    }
}
