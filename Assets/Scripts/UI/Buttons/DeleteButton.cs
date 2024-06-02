using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteButton : MonoBehaviour
{
    [SerializeField] private SaveService saveService;

    public void DeleteSaving()
    {
        saveService.ResetProcess();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
