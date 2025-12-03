using System.Collections.Generic;

public static class SidePricing
{
    public static double PriceForSide(side s)
    {
        switch (s.Type)
        {
            case "Breadsticks":
                return 4.00 * s.Quantity;
            case "Breadstick Bites":
                return 2.00 * s.Quantity;
            case "Big Chocolate Chip Cookie":
                return 4.00 * s.Quantity;
            default:
                return 0;
        }
    }

    public static double TotalPrice(List<side> sides)
    {
        double total = 0;

        for (int i = 0; i < sides.Count; i++)
        {
            total += PriceForSide(sides[i]);
        }

        return total;
    }
}
