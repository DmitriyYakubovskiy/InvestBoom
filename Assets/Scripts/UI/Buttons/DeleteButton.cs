using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteButton : MonoBehaviour
{
    [SerializeField] GameObject[] templates;
    public void DeleteSaving()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < templates.Length; i++)
        {
            templates[i].GetComponent<TemplateObject>().Clear();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
