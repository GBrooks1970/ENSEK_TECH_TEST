@ENSEK-ui-buy-energy
Feature: Buy Energy
  As a customer
  I want to purchase energy units
  So that I can place an order

  @ENSEK-ui-buy-energy-001
  @positive
  Scenario Outline: Purchase valid quantity of <energyType>
    Given the user opens the Buy Energy page
    When the user notes the units available and buys "<quantity>" units of "<energyType>"
    Then the user should see a sale confirmation message for "<energyType>" with "<quantity>" units
    And the user should see the Sale Confirmed units available for "<energyType>" are updated

    Examples:
      | quantity | energyType  |
      | 2        | Gas         |
      | 5        | Electricity |
      | 15       | Oil         |
      | 12       | Gas         |
      | -12      | Gas         |
      | -1       | Electricity |
      | 0        | Oil         |

  @ENSEK-ui-buy-energy-002
  @negative
  Scenario Outline: Purchase with invalid quantity
    Given the user opens the Buy Energy page
    When the user notes the units available and buys "<quantity>" units of "<energyType>"
    Then the user should see an error message

    Examples:
      | quantity | energyType  |
      | x        | Gas         |
      | abc      | Electricity |
      | xyz      | Oil         |
      | x1       | Gas         |

  @ENSEK-ui-buy-energy-003
  @mixed
  Scenario Outline: Purchase energy with various quantities and types
    Given the user opens the Buy Energy page
    When the user buys "<quantity>" units of "<energyType>"
    Then the user should see a sale confirmation message for "<energyType>" with "<quantity>" units
    Then <expectedResult>

    Examples:
      | quantity | energyType  | expectedResult                                                               |
      | 2        | Gas         | the user should see the Sale Confirmed units available for "Gas" are updated |
      | -3       | Electricity | the user should see an error message                                         |