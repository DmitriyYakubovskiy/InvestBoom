using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class NotifyMoneyCounter : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private float startTime = 1;
        private float time;
        private float money;

        private void Start ()
        {
            text=gameObject.GetComponent<TextMeshProUGUI>();
            time = startTime;
        }

        private void Update ()
        {
            if (gameObject.activeSelf == false) return;
            if (time <= 0)
            {
                time = startTime;
                money = 0;
                gameObject.SetActive(false);
            }
            else
            {
                if (money > 0)
                {
                    text.text = $"+ {money}";
                    text.color = Color.green;
                }
                else if (money == 0)
                {
                    text.text = $"{money}";
                    text.color = Color.white;
                }
                else
                {
                    text.text = $"- {-1*money}";
                    text.color = Color.red;
                }
                time -=Time.deltaTime;
            }
        }

        public void Activate()
        {
            if (!gameObject.activeSelf) gameObject.SetActive(true);
        }

        public void AddMoney(float bonus)
        {
            money += bonus;
            time = startTime;
        }
    }
}
