using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public void loadCompletedScene()
    {
        SceneManager.LoadScene("orderComplete");
    }
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

    public void loadCheckOutScene()
    {
        SceneManager.LoadScene("CheckOut");
    }

}
