using System.Collections.Generic;

public class OrderConfigurator
{
    public static OrderConfigurator currentOrder = new OrderConfigurator();

    public List<pizza> pizzas = new List<pizza>();
    public List<soda> sodas = new List<soda>();
    public List<side> sides = new List<side>();

    public void addPizzaToOrder(pizza added_pizzas)
    {
        pizzas.Add(added_pizzas);
    }

    public void addSodaToOrder(soda added_sodas)
    {
        sodas.Add(added_sodas);
    }

    public void addSideToOrder(side added_side)
    {
        sides.Add(added_side);
    }

    public void removePizzaFromOrder(pizza removed_pizzas)
    {
        pizzas.Remove(removed_pizzas);
    }

    public void removeSodaFromOrder(soda removed_sodas)
    {
        sodas.Remove(removed_sodas);
    }

    public void removeSideFromOrder(side removed_side)
    {
        sides.Remove(removed_side);
    }

    public double calculateTotalOrderPrice()
    {
        double total = 0;

        foreach (var pizza in pizzas)
        {
            total += PizzaPricing.TotalPizzasPrice(pizza);
        }

        foreach (var s in sodas)
        {
            total += SodaPricing.TotalPrice(new List<soda> { s });
        }

        foreach (var side in sides)
        {
            total += SidePricing.TotalPrice(new List<side> { side });
        }

        return total;
    }
}
