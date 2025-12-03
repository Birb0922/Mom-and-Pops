using System.Collections.Generic;

public class SidePricing
{

    public static double QuantityPrice(int quantity)
    {
        return quantity * 1.75;
    }

    public static double TotalPrice(List<side> sides)
    {
        double total = 0;

        for (int i = 0; i < sides.Count; i++)
        {
            total += QuantityPrice(sides[i].Quantity);
        }

        return total;
    }


}
