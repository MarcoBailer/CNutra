using System.ComponentModel;

public enum FoodCategory
{
    [Description("Fruits and Fruits Juices")]
    Fruits,

    [Description("Vegetables and Vegetables Product")]
    Vegetables,

    [Description("Dairy and Egg Products")]
    DairyEggs,

    [Description("Beef Products")]
    Beef,

    [Description("Beverages")]
    Beverages,

    [Description("BreakFast Cereals")]
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
