using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public void loadCreateAccountScene()
    {
        SceneManager.LoadScene("CreateAccount");
    }

    public void loadOrderScene()
    {
        SceneManager.LoadScene("Order");
    }
    public void loadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadLoginScene()
    {
        SceneManager.LoadScene("logIn");
    }

}
