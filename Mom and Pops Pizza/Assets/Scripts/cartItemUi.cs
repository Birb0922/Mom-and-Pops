using UnityEngine;
using TMPro;

public class CartItemUI : MonoBehaviour
{
    // Assign these TextMeshPro components in the Inspector of your Prefab
    public TMP_Text itemNameText;
    public TMP_Text quantityText;
    public TMP_Text priceText;

    /// <summary>
    /// Sets the displayed data for this cart item row.
    /// </summary>
    public void SetItemData(string name, int quantity, float unitPrice)
    {
        // Calculate the total price for this line item
        float lineTotal = quantity * unitPrice;
        
        // Update the Text components
        itemNameText.text = name;
        quantityText.text = quantity.ToString();
        priceText.text = $"${lineTotal:F2}"; // Format price to two decimal places
    }
}