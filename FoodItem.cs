using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3Assignment
{
    internal class FoodItem
    {
        // Properties to store food item details
        public string FoodName { get; private set; }
        public string FoodCategory { get; private set; }
        public string FoodQuantity { get; private set; }
        public string FoodExpiration { get; private set; }

        // Static list to store lists of food item details
        public static List<List<string>> FoodItemsList { get; private set; } = new List<List<string>>();

        // Constructor to initialize the food item details
        public FoodItem(string foodName, string foodCategory, string foodQuantity, string foodExpiration)
        {
            FoodName = foodName;
            FoodCategory = foodCategory;
            FoodQuantity = foodQuantity;
            FoodExpiration = foodExpiration;

            // Create a list of food item details and add it to the static list
            List<string> foodItemDetails = new List<string> { FoodName, FoodCategory, FoodQuantity, FoodExpiration };
            FoodItemsList.Add(foodItemDetails);
        }
    }
}
