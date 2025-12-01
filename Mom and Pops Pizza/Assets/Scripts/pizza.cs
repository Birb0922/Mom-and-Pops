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
}
