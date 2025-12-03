using System.Collections.Generic;

public static class SodaPricing
{
	
	public static double QuantityPrice(int quantity)
	{
		return quantity * 1.75;
	}

	public static double TotalPrice(List<soda> sodas)
	{
		double total = 0;

		for (int i = 0;  i < sodas.Count; i++)
		{
			total += QuantityPrice(sodas[i].Quantity);
		}

		return total;
	}

}
