using System.ComponentModel;

public enum EFoodCategory
{ 
    [Description("Cereais e derivados")]
    Cereais,

    [Description("Verduras, hortaliças e derivados")]
    Verduras,

    [Description("Frutas e derivados")]
    Frutas,

    [Description("Gorduras e óleos")]
    OleosEGorduras,

    [Description("Pescados e frutos do mar")]
    Pescados,

    [Description("Carnes e derivados")]
    CarneEDerivados,

    [Description("Leite e derivados")]
    LeiteEDerivados,

    [Description("Bebidas (alcoólicas e não alcoólicas)")]
    Bebidas,

    [Description("Ovos e derivados")]
    OvosEDerivados,

    [Description("Produtos açucarados")]
    Açucarados,

    [Description("Miscelâneas")]
    Micelania,

    [Description("Outros alimentos industrializados")]
    OutrosIndustrializados,

    [Description("Alimentos preparados")]
    AlimentosPreparados,

    [Description("Leguminosas e derivados")]
    Leguminosas
}
