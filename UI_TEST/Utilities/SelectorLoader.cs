
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class SelectorEntry
{
    public string EnergyType { get; set; }
    public SelectorDetails Selectors { get; set; }
}

public class SelectorDetails
{
    public CssSelectors Css { get; set; }
    public XPathSelectors XPath { get; set; }
}

public class CssSelectors
{
    public string Input { get; set; }
    public string BuyButton { get; set; }
    public string UnitsAvailable { get; set; }
    public string SaleConfirm { get; set; }
    public string SaleConfirmResult { get; set; }
    public string BuyMoreButton { get; set; }
}

public class XPathSelectors
{
    public string Input { get; set; }
    public string BuyButton { get; set; }
    public string UnitsAvailable { get; set; }
    public string SaleConfirm { get; set; }
    public string SaleConfirmResult { get; set; }
    public string BuyMoreButton { get; set; }
}

public class SelectorLoader
{
    public List<SelectorEntry> Entries { get; private set; }

    public void LoadFromFile(string filePath)
    {
        var json = File.ReadAllText(filePath);
        Entries = JsonConvert.DeserializeObject<List<SelectorEntry>>(json);
    }

    public SelectorEntry GetByEnergyType(string energyType)
    {
        return Entries?.FirstOrDefault(e => e.EnergyType.Equals(energyType, StringComparison.OrdinalIgnoreCase));
    }

    public void PrintSelectors(SelectorEntry entry)
    {
        if (entry == null) return;

        Console.WriteLine($"Energy Type: {entry.EnergyType}");
        Console.WriteLine($"  CSS - Input: {entry.Selectors.Css.Input}");
        Console.WriteLine($"  CSS - Buy Button: {entry.Selectors.Css.BuyButton}");
        Console.WriteLine($"  CSS - Units Available: {entry.Selectors.Css.UnitsAvailable}");
        Console.WriteLine($"  XPath - Input: {entry.Selectors.XPath.Input}");
        Console.WriteLine($"  XPath - Buy Button: {entry.Selectors.XPath.BuyButton}");
        Console.WriteLine($"  XPath - Units Available: {entry.Selectors.XPath.UnitsAvailable}");
    }
}
