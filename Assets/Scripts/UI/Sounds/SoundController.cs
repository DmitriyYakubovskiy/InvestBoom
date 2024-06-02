using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Sprite image1;
    [SerializeField] private Sprite image2;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string volueParameter = "MasterVol";
    [SerializeField] private bool isActive = true;

    private Button button;

    public void Awake()
    {
        button=GetComponent<Button>();
    }

    public void ButtonClick()
    {
        if (isActive)
        {
            button.GetComponent<Image>().sprite = image2;
            mixer.SetFloat(volueParameter, -80);
            isActive = false;
        }
        else
        {
            button.GetComponent<Image>().sprite = image1;
            mixer.SetFloat(volueParameter, 0);
            isActive =true;
        }
    }
}
