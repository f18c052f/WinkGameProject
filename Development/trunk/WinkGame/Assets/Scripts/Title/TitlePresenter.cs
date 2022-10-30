using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePresenter : MonoBehaviour
{
    public void OnNewGameButton()
    {
        SceneManager.LoadScene("Game");
    }

}
