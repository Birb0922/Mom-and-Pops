using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SimpleLogin : MonoBehaviour
{
    
    public class AccountData
    {
        public string fullName;
        public string email;
        public string address;
        public string cardNumber;
        public string username;
        public string cvv;
        public string expirationDate;
        public string password;
    }
    private const string VALID_USERNAME = "pizzafan";
    private const string VALID_PASSWORD = "orderit";
    
   
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text loginErrorText;
    
    public void AttemptLogin()
    {
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;
        
        loginErrorText.text = ""; 
        if (username == VALID_USERNAME && password == VALID_PASSWORD)
        {
            HandleSuccessfulLogin(username);
            SceneManager.LoadScene("Order");
        }
        else
        {
          
            loginErrorText.text = "Incorrect username or password.";
            Debug.Log("Login failed: Invalid credentials.");
        }
    }

    private void HandleSuccessfulLogin(string loggedInUsername)
    {
        
        AccountData dummyAccount = new AccountData
        {
            username = loggedInUsername,
            fullName = "Pizza Fanatic",
            email = "pizza@delivery.com",
            address = "123 Main St, Anytown, CA 90210",
            cardNumber = "4111222233334444", 
            expirationDate = "12/25",
            cvv = "123",
            password = VALID_PASSWORD
        };

        
        
    }
}