using System.ComponentModel;

public enum FoodCategory
{
    [Description("Fruits%20and%20Fruits%20Juices")]
    Fruits,

    [Description("Vegetables%20and%20Vegetables%20Product")]
    Vegetables,

    [Description("Dairy%20and%20Egg%20Products")]
    DairyEggs,

    [Description("Beef%20Products")]
    Beef,

    [Description("Beverages")]
    Beverages,

    [Description("BreakFast%20Cereals")]
    BreakFastCereals,

    [Description("Fats%20and%20Oils")]
    FatsOils,

    [Description("Finfish%20and%20Shellfish%20Products")]
    FinfishShellfish,

    [Description("Legumes%20and%20Legume%20Products")]
    Legumes,

    [Description("Nut%20and%20Seed%20Products")]
    NutSeed,

    [Description("Pork%20Products")]
    Pork,

    [Description("Poultry%20Products")]
    Poultry,
}
