using UnityEngine;
using System.Collections.Generic;

public class pizza
{
    private string Crust;
    private string Size;
    private List<string> Toppings;
    private int Quantity;

    public pizza(string crust, string size, List<string> toppings, int quantity)
    {
        Crust = crust;
        Size = size;
        Toppings = toppings;
        Quantity = quantity;
    }

    public void selectCrust(int index)
    {
        if (index == 1)
        {
            this.Crust = "Thin";
        }
        else if (index == 2)
        {
            this.Crust = "Regular";
        }
        else if (index == 3)
        {
            this.Crust = "Pan";
        }
    }

    public void selectSize(int index)
    {
        if (index == 1)
        {
            this.Size = "Small";
        }
        else if (index == 2)
        {
            this.Size = "Medium";
        }
        else if (index == 3)
        {
            this.Size = "Large";
        }
        else if (index == 4)
        {
            this.Size = "Extra-Large";
        }
    }

    public void addToppings(int index)
    {
        if (index == 1)
        {
            if (!this.Toppings.Contains("Cheese"))
                {
                Toppings.Add("Cheese");
            }
            else if (this.Toppings.Contains("Cheese"))
            {
                Toppings.Remove("Cheese");
            }
        }
        else if (index == 2)
        {
            if (!this.Toppings.Contains("Pepperoni"))
            {
                Toppings.Add("Pepperoni");
            }
            else if (this.Toppings.Contains("Pepperoni"))
            {
                Toppings.Remove("Pepperoni");
            }
        }
        else if (index == 3)
        {
            if (!this.Toppings.Contains("Sausage"))
            {
                Toppings.Add("Sausage");
            }
            else if (this.Toppings.Contains("Sausage"))
            {
                Toppings.Remove("Sausage");
            }
        }
        else if (index == 4)
        {
            if (!this.Toppings.Contains("Ham"))
            {
                Toppings.Add("Ham");
            }
            else if (this.Toppings.Contains("Ham"))
            {
                Toppings.Remove("Ham");
            }
        }
        else if (index == 5)
        {
            if (!this.Toppings.Contains("Green Pepper"))
            {
                Toppings.Add("Green Pepper");
            }
            else if (this.Toppings.Contains("Green Pepper"))
            {
                Toppings.Remove("Green Pepper");
            }
        }
        else if (index == 6)
        {
            if (!this.Toppings.Contains("Onion"))
            {
                Toppings.Add("Onion");
            }
            else if (this.Toppings.Contains("Onion"))
            {
                Toppings.Remove("Onion");
            }
        }
        else if (index == 7)
        {
            if (!this.Toppings.Contains("Tomato"))
            {
                Toppings.Add("Tomato");
            }
            else if (this.Toppings.Contains("Tomato"))
            {
                Toppings.Remove("Tomato");
            }
        }
        else if (index == 8)
        {
            if (!this.Toppings.Contains("Mushroom"))
            {
                Toppings.Add("Mushroom");
            }
            else if (this.Toppings.Contains("Mushroom"))
            {
                Toppings.Remove("Mushroom");
            }
        }
        else if (index == 9)
        {
            if (!this.Toppings.Contains("Pineapple"))
            {
                Toppings.Add("Pineapple");
            }
            else if (this.Toppings.Contains("Pineapple"))
            {
                Toppings.Remove("Pineapple");
            }
        }
    }
    public void setQuantity(int quantity)
    {
        this.Quantity = quantity;
    }
}
