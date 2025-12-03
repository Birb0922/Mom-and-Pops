using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderCompleteUI : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject lineItemPrefab;

    public TextMeshProUGUI subtotalText;
    public TextMeshProUGUI taxText;
    public TextMeshProUGUI totalText;

    private double taxRate = 0.06;

    private OrderConfigurator order => OrderConfigurator.currentOrder;

    void Start()
    {
        DisplayReceipt();
    }

    void DisplayReceipt()
    {
        if (order == null) return;

        double subtotal = 0;

        // Pizzas
        foreach (var p in order.pizzas)
        {
            double pizzaPrice = PizzaPricing.SizePrice(p.Size);

            foreach (var topping in p.Toppings)
            {
                if (p.Size == "Small") pizzaPrice += 0.75;
                else if (p.Size == "Medium") pizzaPrice += 1.00;
                else if (p.Size == "Large") pizzaPrice += 1.25;
                else if (p.Size == "Extra-Large") pizzaPrice += 1.50;
            }

            pizzaPrice *= p.Quantity;

            string toppingsList = p.Toppings.Count > 0 ? string.Join(", ", p.Toppings) : "None";
            AddLine($"{p.Size} {p.Crust} Pizza ({toppingsList}) x{p.Quantity}", pizzaPrice);
            subtotal += pizzaPrice;
        }


        // Sodas
        foreach (var s in order.sodas)
        {
            double sodaPrice = SodaPricing.TotalPrice(new List<soda> { s });
            AddLine($"{s.Size} {s.Type} x{s.Quantity}", sodaPrice);
            subtotal += sodaPrice;
        }

        // Sides
        foreach (var side in order.sides)
        {
            double sidePrice = SidePricing.TotalPrice(new List<side> { side });
            AddLine($"{side.Type} x{side.Quantity}", sidePrice);
            subtotal += sidePrice;
        }

        double tax = subtotal * taxRate;
        double total = subtotal + tax;

        subtotalText.text = "Subtotal: $" + subtotal.ToString("F2");
        taxText.text = "Tax: $" + tax.ToString("F2");
        totalText.text = "Total: $" + total.ToString("F2");
    }

    void AddLine(string name, double price)
    {
        if (lineItemPrefab == null || contentPanel == null) return;

        GameObject row = Instantiate(lineItemPrefab, contentPanel);
        var itemName = row.transform.Find("ItemName")?.GetComponent<TextMeshProUGUI>();
        var itemPrice = row.transform.Find("ItemPrice")?.GetComponent<TextMeshProUGUI>();

        if (itemName != null) itemName.text = name;
        if (itemPrice != null) itemPrice.text = "$" + price.ToString("F2");
    }
}
