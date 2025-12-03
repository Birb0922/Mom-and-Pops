using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUILink : MonoBehaviour
{
    public OrderConfigurator orderConfigurator;

	public Dropdown crust;
	public Dropdown pizza_size;
	public InputField pizza_quantity;

	public Toggle pepperoni;
	public Toggle cheese;
	public Toggle sausage;
	public Toggle ham;
	public Toggle green_pepper;
	public Toggle onion;
	public Toggle tomato;
	public Toggle mushroom;
	public Toggle pineapple;

	public Dropdown pepsi_drink_size;
	public Dropdown pepsi_drink_quantity;

    public Dropdown diet_pepsi_drink_size;
    public Dropdown diet_pepsi_drink_quantity;

    public Dropdown orange_drink_size;
    public Dropdown orange_drink_quantity;

    public Dropdown diet_orange_drink_size;
    public Dropdown diet_orangedrink_quantity;

    public Dropdown rootbeer_drink_size;
    public Dropdown rootbeer_drink_quantity;

    public Dropdown diet_rootbeer_drink_size;
    public Dropdown diet_rootbeer_drink_quantity;

	public Dropdown starry_drink_size;
	public Dropdown starry_drink_quantity;

	public Dropdown lemonade_drink_size;
	public Dropdown lemonade_drink_quantity;

    public Dropdown breadstick_quantity;
	public Dropdown breadstick_bites_quantity;
	public Dropdown cookie_quantity;



	public void addOrder()
	{
		string pizza_crust = crust.options[crust.value].text;
		string pizza_object_size = pizza_size.options[pizza_size.value].text;
        int pizza_object_quantity = int.Parse(pizza_quantity.text);

        
		List<string> toppings = new List<string>();

		if (pepperoni.isOn) { toppings.Add("Pepperoni"); }
        if (cheese.isOn) { toppings.Add("Cheese"); }
        if (sausage.isOn) { toppings.Add("Sausage"); }
        if (ham.isOn) { toppings.Add("Ham"); }
        if (green_pepper.isOn) { toppings.Add("Green Pepper"); }
        if (onion.isOn) { toppings.Add("Onion"); }
        if (tomato.isOn) { toppings.Add("Tomato"); }
        if (mushroom.isOn) { toppings.Add("Mushroom"); }
        if (pineapple.isOn) { toppings.Add("Pineapple"); }

		pizza pizza_object = new pizza(pizza_crust, pizza_object_size, toppings, pizza_object_quantity);
		orderConfigurator.AddPizzaToOrder(pizza_object);

        AddSoda(pepsi_drink_size, pepsi_drink_quantity, "Pepsi");
        AddSoda(diet_pepsi_drink_size, diet_pepsi_drink_quantity, "Diet Pepsi");
        AddSoda(orange_drink_size, orange_drink_quantity, "Orange");
        AddSoda(diet_orange_drink_size, diet_orange_drink_quantity, "Diet Orange");
        AddSoda(rootbeer_drink_size, rootbeer_drink_quantity, "Root Beer");
        AddSoda(diet_rootbeer_drink_size, diet_rootbeer_drink_quantity, "Diet Root Beer");
        AddSoda(starry_drink_size, starry_drink_quantity, "Starry");
        AddSoda(lemonade_drink_size, lemonade_drink_quantity, "Lemonade");

        AddSide(breadstick_quantity, "Breadsticks");
        AddSide(breadstick_bites_quantity, "Breadstick Bites");
        AddSide(cookie_quantity, "Big Chocolate Chip Cookie");

    }


    private void AddSoda(Dropdown drink_size, Dropdown drink_quantity, string drink_type)
    {
        int quantity = int.Parse(drink_quantity.options[drink_quantity.value].text);
        if (quantity > 0)
        {
            string size = drink_size.options[drink_size.value].text;
            soda soda_object = new soda(drink_type, size, quantity);
            orderConfigurator.addSodaToOrder(soda_object);
        }
    }

    private void AddSide(Dropdown side_quantity, string side_type)
    {
        int quantity = int.Parse(side_quantity.options[side_quantity.value].text);
        if (quantity > 0)
        {
            side side_object = new side(side_type, quantity);
            orderConfigurator.addSideToOrder(side_object);
        }
    }



}
