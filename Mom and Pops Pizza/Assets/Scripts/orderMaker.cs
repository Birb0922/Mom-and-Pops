using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    public class CartItem
    {
        public string Name;      
        public float Price;        
        public int Quantity;
        public string Details;    
    }

    public TMP_Dropdown crustDropdown;
    public TMP_Dropdown sizeDropdown;
    public TMP_Dropdown pizzaQuantityDropdown; 


    public Toggle pepperoniToggle;
    public Toggle cheeseToggle;
    public Toggle sausageToggle;
    public Toggle hamToggle;
    public Toggle greenPepperToggle;
    public Toggle onionToggle;
    public Toggle tomatoToggle;
    public Toggle mushroomToggle;
    public Toggle pineappleToggle;


    public TMP_Dropdown pepsiSizeDropdown; public TMP_Dropdown pepsiQuantityDropdown;
    public TMP_Dropdown dietPepsiSizeDropdown; public TMP_Dropdown dietPepsiQuantityDropdown;
    public TMP_Dropdown rootBeerSizeDropdown; public TMP_Dropdown rootBeerQuantityDropdown;
    public TMP_Dropdown dietRootBeerSizeDropdown; public TMP_Dropdown dietRootBeerQuantityDropdown;
    public TMP_Dropdown starrySizeDropdown; public TMP_Dropdown starryQuantityDropdown;
    public TMP_Dropdown lemonadeSizeDropdown; public TMP_Dropdown lemonadeQuantityDropdown;
    public TMP_Dropdown dietOrangeSizeDropdown; public TMP_Dropdown dietOrangeQuantityDropdown;
    public TMP_Dropdown orangeSizeDropdown; public TMP_Dropdown orangeQuantityDropdown;


    public TMP_Dropdown breadsticksQuantityDropdown;
    public TMP_Dropdown breadstickBitesQuantityDropdown;
    public TMP_Dropdown bigCookieQuantityDropdown;

   
    public Button addButton;             
    public Button viewCartButton;        
    public GameObject checkoutPanel;     


    public TMP_Text itemizedListText;    
    public TMP_Text finalTotalText;      
    
 
    public List<CartItem> shoppingCart = new List<CartItem>();

    void Start()
    {

        addButton.onClick.AddListener(ProcessAndDisplayOrder);
        viewCartButton.onClick.AddListener(ToggleCheckoutPanel);
        
  
        
        if (checkoutPanel != null)
        {
            checkoutPanel.SetActive(false);
        }
        
        // Initial call to display the empty cart message
        UpdateCartDisplay(); 
    }

 

    public void ProcessAndDisplayOrder()
    {
 
        // 🚨 REMOVED: shoppingCart.Clear(); 
        // This allows new items to be added to the existing list.
        
        ProcessPizzaOrder();
        ProcessDrinkOrders();
        ProcessSideOrders();

        // This will update the display with the newly added items
        UpdateCartDisplay();
    }
    

    
    public void ToggleCheckoutPanel()
    {
        if (checkoutPanel != null)
        {
            bool newState = !checkoutPanel.activeSelf;
            checkoutPanel.SetActive(newState);
            
            if (newState)
            {
                UpdateCartDisplay(); 
            }
        }
    }
    


    public void UpdateCartDisplay()
    {
        float totalOrderPrice = 0f;
        string itemListString = "";
        foreach (CartItem item in shoppingCart)
        {
            float lineTotal = item.Price * item.Quantity;
            
         
            string displayName = item.Name;
            if (!string.IsNullOrEmpty(item.Details))
            {
                displayName += $" ({item.Details})";
            }
         
            string itemLine = $"{item.Quantity}x {displayName} @ ${item.Price:F2} ea. = ${lineTotal:F2}\n";
            
            itemListString += itemLine;
            totalOrderPrice += lineTotal;
        }

 
        if (itemizedListText != null)
        {
            if (shoppingCart.Count == 0)
            {
                itemizedListText.text = "Your order input fields are currently empty.";
            }
            else
            {
                itemizedListText.text = itemListString; 
            }
        }


        if (finalTotalText != null)
        {
            finalTotalText.text = $"Total: ${totalOrderPrice:F2}";
        }
    }


    private void ProcessPizzaOrder()
    {
        int pizzaQuantity = GetDropdownValue(pizzaQuantityDropdown);
        if (pizzaQuantity <= 0) return; 

        string selectedSize = sizeDropdown.options[sizeDropdown.value].text;
        List<string> selectedToppings = new List<string>();
        if (pepperoniToggle.isOn) selectedToppings.Add("Pepperoni");
        if (cheeseToggle.isOn) selectedToppings.Add("Cheese");
        if (sausageToggle.isOn) selectedToppings.Add("Sausage");
        if (hamToggle.isOn) selectedToppings.Add("Ham");
        if (greenPepperToggle.isOn) selectedToppings.Add("Green Pepper");
        if (onionToggle.isOn) selectedToppings.Add("Onion");
        if (tomatoToggle.isOn) selectedToppings.Add("Tomato");
        if (mushroomToggle.isOn) selectedToppings.Add("Mushroom");
        if (pineappleToggle.isOn) selectedToppings.Add("Pineapple");

        float basePrice = GetPizzaBasePrice(selectedSize);
        float toppingPricePerUnit = GetToppingPrice(selectedSize);
        float totalToppingsPrice = selectedToppings.Count * toppingPricePerUnit;
        float unitPrice = basePrice + totalToppingsPrice;

        string selectedCrust = crustDropdown.options[crustDropdown.value].text;
        string toppingsList = selectedToppings.Count > 0 ? string.Join(", ", selectedToppings) : "None";

        CartItem newPizza = new CartItem
        {
            Name = "Custom Pizza",
            Price = unitPrice,
            Quantity = pizzaQuantity,
            Details = $"{selectedSize}, {selectedCrust} Crust, Toppings: {toppingsList}"
        };
        shoppingCart.Add(newPizza);
    }
    
    private void ProcessDrinkOrders()
    {
        const float drinkPrice = 1.75f; 
        
        AddDrinkItem("Pepsi", pepsiSizeDropdown, pepsiQuantityDropdown, drinkPrice);
        AddDrinkItem("Diet Pepsi", dietPepsiSizeDropdown, dietPepsiQuantityDropdown, drinkPrice);
        AddDrinkItem("Root Beer", rootBeerSizeDropdown, rootBeerQuantityDropdown, drinkPrice);
        AddDrinkItem("Diet Root Beer", dietRootBeerSizeDropdown, dietRootBeerQuantityDropdown, drinkPrice);
        AddDrinkItem("Starry", starrySizeDropdown, starryQuantityDropdown, drinkPrice);
        AddDrinkItem("Lemonade", lemonadeSizeDropdown, lemonadeQuantityDropdown, drinkPrice);
        AddDrinkItem("Diet Orange", dietOrangeSizeDropdown, dietOrangeQuantityDropdown, drinkPrice);
        AddDrinkItem("Orange", orangeSizeDropdown, orangeQuantityDropdown, drinkPrice);
    }
    
    private void ProcessSideOrders()
    {
        AddSideItem("Breadsticks", breadsticksQuantityDropdown, 4.00f);
        AddSideItem("Breadstick Bites", breadstickBitesQuantityDropdown, 2.00f);
        AddSideItem("Big Chocolate Chip Cookie", bigCookieQuantityDropdown, 4.00f);
    }

    // ===================================
    // HELPER FUNCTIONS 
    // ===================================

    private int GetDropdownValue(TMP_Dropdown dropdown)
    {
        if (dropdown == null || dropdown.options.Count == 0) return 0;
        string selectedText = dropdown.options[dropdown.value].text;
        int quantity = 0;
        int.TryParse(selectedText, out quantity);
        return quantity;
    }
    
    private string GetDropdownText(TMP_Dropdown dropdown)
    {
        if (dropdown == null || dropdown.options.Count == 0) return string.Empty;
        return dropdown.options[dropdown.value].text;
    }

    private void AddDrinkItem(string name, TMP_Dropdown sizeDropdown, TMP_Dropdown quantityDropdown, float unitPrice)
    {
        int quantity = GetDropdownValue(quantityDropdown);
        if (quantity > 0)
        {
            string selectedSize = GetDropdownText(sizeDropdown); 
            CartItem newItem = new CartItem
            {
                Name = name,
                Price = unitPrice,
                Quantity = quantity,
                Details = string.IsNullOrEmpty(selectedSize) ? "" : $"{selectedSize} Size"
            };
            shoppingCart.Add(newItem);
        }
    }

    private void AddSideItem(string name, TMP_Dropdown quantityDropdown, float unitPrice)
    {
        int quantity = GetDropdownValue(quantityDropdown);
        if (quantity > 0)
        {
             CartItem newItem = new CartItem
            {
                Name = name,
                Price = unitPrice,
                Quantity = quantity,
                Details = ""
            };
            shoppingCart.Add(newItem);
        }
    }



    private float GetPizzaBasePrice(string size) 
    {
        if (size == "Small") return 5.00f;
        if (size == "Medium") return 7.00f;
        if (size == "Large") return 9.00f;
        if (size == "Extra-Large") return 11.00f;
        return 0f;
    }
    
    private float GetToppingPrice(string size)
    {
        if (size == "Small") return 0.75f;
        if (size == "Medium") return 1.00f;
        if (size == "Large") return 1.25f;
        if (size == "Extra-Large") return 1.50f;
        return 0f;
    }
}