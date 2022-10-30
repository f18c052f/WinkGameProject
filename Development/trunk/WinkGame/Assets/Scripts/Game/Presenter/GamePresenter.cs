using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePresenter : MonoBehaviour
{
    public void OnReturnButton()
    {
        SceneManager.LoadScene("Title");
    }

}
