using NUnit.Framework;
using TechTalk.SpecFlow;
using Ensek.UITests.Screenplay.Actors;
using Ensek.UITests.Screenplay.Tasks;
using Ensek.UITests.Screenplay.Questions;
using Ensek.UITests.Utilities;
using System.Linq;
using Ensek.UITests.Screenplay;

[Binding]
public class BuyEnergySteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly User _user;
    private readonly TestData _testData;

    public BuyEnergySteps(ScenarioContext scenarioContext)
    {
        _user = new User();
        var loader = new TestDataLoader();
        _testData = loader.Load("Env/TestData.json");
        _scenarioContext = scenarioContext;
        _scenarioContext.Set<User>(_user);
        _scenarioContext.Set<TestData>(_testData);
        _scenarioContext.Set<SelectorLoader>(new SelectorLoader());
    }

    [Given(@"the user opens the Buy Energy page")]
    public void GivenTheUserOpensTheBuyEnergyPage()
    {
        _user.AttemptsTo(new OpenBuyEnergyPage());
    }

    [When(@"the user buys ""(.*)"" units of ""(.*)""")]
    public void WhenTheUserBuysUnitsOf(string quantity, string energyType)
    {
        _user.AttemptsTo(new BuyEnergy(energyType, quantity));
    }

    [When(@"the user notes the units available and buys ""(.*)"" units of ""(.*)""")]
    public void WhenTheUserNotesTheUnitsAvailableAndUserBuysUnitsOf(string quantity, string energyType)
    {
        _user.Remember("UnitsAvailable", _user.AsksFor(new BuyEnergyTheUnitsAvailable(energyType)));
        _user.Remember("EnergyType", energyType);
        _user.Remember("BuyQuantity", quantity);
        _scenarioContext.Set<string>("EnergyType", energyType);
        _scenarioContext.Set<string>("BuyQuantity", quantity); 
        _user.AttemptsTo(new BuyEnergy(energyType, quantity));
    }

    [When(@"the user buys a valid quantity of ""(.*)""")]
    public void WhenTheUserBuysAValidQuantityOf(string energyType)
    {
        var test = _testData.EnergyTests.FirstOrDefault(e => e.EnergyType == energyType);
        _user.AttemptsTo(new BuyEnergy(energyType, test?.ValidQuantity.ToString() ?? "1"));
    }

    [When(@"the user buys an invalid quantity of ""(.*)""")]
    public void WhenTheUserBuysAnInvalidQuantityOf(string energyType)
    {
        var test = _testData.EnergyTests.FirstOrDefault(e => e.EnergyType == energyType);
        _user.AttemptsTo(new BuyEnergy(energyType, test?.InvalidQuantity.ToString() ?? "-1"));
    }

    [Then(@"the user should see the units available for ""(.*)"" are reduced")]
    public void ThenTheUserShouldSeeTheUnitsAvailableForAreReduced(string energyType)
    {
        Assert.IsTrue(_user.AsksFor(new UnitsUpdated_BuyEnergy(energyType)));
    }    

    [Then(@"the user should see the Sale Confirmed units available for ""(.*)"" are updated")]
    public void ThenTheUserShouldSeeTheUnitsAvailableForAreUpdated(string energyType)
    {
        var (unitsAfterPurchase, enerygTypeAfterPurchase) = _user.AsksFor(new SaleConfirmationUnitsAndType(energyType));
        int unitsBeforePurchase = _user.Recall<int>("UnitsAvailable");
        int unitsPurchased = int.Parse(_user.Recall<string>("BuyQuantity"));

        int expectedUnits = unitsBeforePurchase - unitsPurchased;
        Assert.IsTrue(unitsAfterPurchase == expectedUnits, 
            $"Expected {expectedUnits} units after purchase, but found {unitsAfterPurchase} units.");
        Assert.IsTrue(enerygTypeAfterPurchase.Equals(energyType, System.StringComparison.OrdinalIgnoreCase), 
            $"Expected energy type {energyType}, but found {enerygTypeAfterPurchase}.");
    }

    [Then(@"the user should see an error message")]
    public void ThenTheUserShouldSeeAnErrorMessage()
    {
        Assert.IsTrue(_user.AsksFor(new ErrorMessageDisplayed()));
    }

    [Then(@"the user should see a sale confirmation message for ""(.*)"" with ""(.*)"" units")]
    public void ThenTheUserShouldSeeAConfirmationMessage(string energyType, string quantity)
    {
        Assert.IsTrue(_user.AsksFor(new PurchaseConfirmationMessageDisplayed(energyType, quantity)), "Confirmation message was not displayed.");
    }
}
