using System.ComponentModel;

public enum EFoodCategory
{ 
    [Description("Fruits and Fruit Juices")]
    Fruits,

    [Description("Vegetables and Vegetable Products")]
    Vegetables,

    [Description("Dairy and Egg Products")]
    DairyEggs,

    [Description("Beef Products")]
    Beef,

    [Description("Beverages")]
    Beverages,

    [Description("Breakfast Cereals")]
    BreakFastCereals,

    [Description("Fats and Oils")]
    FatsOils,

    [Description("Finfish and Shellfish Products")]
    FinfishShellfish,

    [Description("Legumes and Legume Products")]
    Legumes,

    [Description("Nut and Seed Products")]
    NutSeed,

    [Description("Pork Products")]
    Pork,

    [Description("Poultry Products")]
    Poultry,
}
