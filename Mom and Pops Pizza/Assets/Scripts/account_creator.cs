using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class account_creation : MonoBehaviour
{

    public InputField username;
    public InputField password;
    public Text output;
    public string path;




    void Start()
    {
        path = Application.persistentDataPath + "/credentials.txt";
    }



    public void createAccount()
    {

        string inputted_username = username.text;
        string inputted_password = password.text;

        if (string.IsNullOrEmpty(inputted_username) || string.IsNullOrEmpty(inputted_password))
        {   
            output.text = "Invalid Username or Password";
            return;
        }
        else
        {
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                string on_file_username = parts[0].Trim();
                string on_file_password = parts[1].Trim();

                if (on_file_username == inputted_username && on_file_password == inputted_password)
                {
                    output.text = "Invalid Username and Password";
                    return;
                }
            }

            File.AppendAllText(path, inputted_username + "," + inputted_password + "\n");
            output.text = "Account created";

        }
    }

}
