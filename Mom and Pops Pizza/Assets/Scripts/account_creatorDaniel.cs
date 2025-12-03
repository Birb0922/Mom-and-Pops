using System.IO;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class AccountManager : MonoBehaviour
{
    public TMP_InputField fullNameInput;
    public TMP_InputField emailInput;
    public TMP_InputField addressInput;
    public TMP_InputField cardNumberInput;
    public TMP_InputField expirationDateInput;
    public TMP_InputField cvvInput;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField reenterPasswordInput;
    public TMP_Text accountErrorText;

    private string filePath;
    
    [Serializable]
    public class AccountData
    {
        public string fullName;
        public string email;
        public string address;
        public string cardNumber;
        public string expirationDate;
        public string cvv;
        public string username;
        public string password;
    }
    void Start()
    {
        filePath = Application.persistentDataPath + "/accounts.txt";

        // Make sure file exists
        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "");
    }

    public void CreateAccount()
    {
        string username = usernameInput.text.Trim();

       
        if (username == "" || passwordInput.text == "" || fullNameInput.text == "")
        {
            Debug.Log("Missing required fields.");
            accountErrorText.text = "Missing required fields!";
            return;
        }

       
        if (passwordInput.text != reenterPasswordInput.text)
        {
            Debug.Log("Passwords do not match!");
            accountErrorText.text = "Passwords do not match!";
            return;
        }

        
        if (DoesAccountExist(username))
        {
            Debug.Log("Username already exists!");
            accountErrorText.text = "Username already exists!";
            return;
        }

       
        AccountData newAccount = new AccountData
        {
            fullName = fullNameInput.text,
            email = emailInput.text,
            address = addressInput.text,
            cardNumber = cardNumberInput.text,
            expirationDate = expirationDateInput.text,
            cvv = cvvInput.text,
            username = usernameInput.text,
            password = passwordInput.text
        };

       
        string json = JsonUtility.ToJson(newAccount);

        
        File.AppendAllText(filePath, json + "\n");

        Debug.Log("Account created successfully!");
        SceneManager.LoadScene("Order");
    }

    private bool DoesAccountExist(string usernameToCheck)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            AccountData acc = JsonUtility.FromJson<AccountData>(line);

            if (acc.username == usernameToCheck)
                return true;
        }

        return false;
    }
}
