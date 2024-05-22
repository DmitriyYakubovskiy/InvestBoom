using TMPro;
using UnityEngine;

public class AnswerPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textAnswer;

    public void IsOpen(string name, string answer)
    {
        textAnswer.text = answer;
        textName.text = name;
    }
}
