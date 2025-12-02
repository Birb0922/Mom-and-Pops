using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public void loadCreateAccountScene()
    {
        SceneManager.LoadScene("CreateAccount");
    }

}
