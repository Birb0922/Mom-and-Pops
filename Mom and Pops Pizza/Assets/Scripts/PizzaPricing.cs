using System.Collections.Generic;
using System;

public static class PizzaPricing
{

    /// <summary>
    /// calculates the price based off the size of the pizza
    /// </summary>
    /// <param name="size"></param> the size of the pizza
    /// <returns></returns> returns the price of the inputted pizza size
    public static double SizePrice(string size)
    {
        if (size == "Small")
        {
            return 5.00;
        }
        
        else if (size == "Medium")
        {
            return 7.00;
        }

        else if (size == "Large")
        {
            return 9.00;
        }
        
        else if (size == "Extra-Large")
        {
            return 11.00;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// calculates the total price of toppings for a pizza based off the size and number of toppings
    /// </summary>
    /// <param name="toppings"></param> list representing the number of toppings on a pizza
    /// <param name="size"></param> the size of a pizza
    /// <returns></returns> returns the price of all the toppings
    public static double ToppingsPrice(List<string> toppings, string size)
    {
        double price = 0;

        if (toppings.Count > 2)
        {

            if (size == "Small")
            {
                for (int i = 2; i < toppings.Count; i++)
                {
                    price += 0.75;
                }
            }

            else if (size == "Medium")
            {
                for (int i = 2; i < toppings.Count; i++)
                {
                    price += 1.00;
                }
            }

            else if (size == "Large")
            {
                for (int i = 2; i < toppings.Count; i++)
                {
                    price += 1.25;
                }
            }

            else if (size == "Extra-Large")
            {
                for (int i = 2; i < toppings.Count; i++)
                {
                    price += 1.50;
                }
            }

            return price;

        }
        else
        {
            return 0;
        }
    }
    

    /// <summary>
    /// calculates the total price of all the pizzas ordered in a single order
    /// </summary>
    /// <param name="pizzas"></param> takes in a pizza object from the Pizza class
    /// <returns></returns> returns the total price of all the pizzas added to an order
    public static double TotalPizzasPrice(pizza pizzas)
    {
        double size_price = SizePrice(pizzas.Size);
        double toppings_price = ToppingsPrice(pizzas.Toppings, pizzas.Size);
        double single_pizza_price = size_price + toppings_price;

        return single_pizza_price * pizzas.Quantity;
    }

}
