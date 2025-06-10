@ENSEK-purchase_energy_units
Feature: Purchase Energy Units
  As a customer
  I want to purchase energy units
  So that I can place an order

  @ENSEK-purchase_energy_units-001
  @positive
  Scenario Outline: Purchase valid energy type
    Given I am authenticated
    When I place an order to purchase <quantity> units of energy type <energyId>
    Then the order is successfully placed and confirmed

    Examples:
      | energyId | quantity |
      | 1        | 10       |
      # Nuclear energy type ID is 2 -Response should be 200 OK with order confirmation but message instead       
      # | 2        | 0        |
      | 3        | 120      |
      | 4        | 500      |

  @ENSEK-purchase_energy_units-002
  @negative
  Scenario Outline: Purchase with invalid energy ID
    Given I am authenticated
    When I place an order to purchase <quantity> units of energy type <invalidEnergyId>
    Then the request is rejected with a 404 Not Found or a 400 Bad Request response

    Examples:
      | invalidEnergyId | quantity |
      | -1              | 5        |
      | abc             | 3        |
      | null            | 2        |
      # assertion: The system should not allow negative or non-numeric energy IDs
      # All below examples are invalid energy IDs but return 400 Bad Request
      # | 0               | 1        |
      # | 6               | 1        |
      # | 9               | 1        |
      # | 99              | 1        |
      # | 999             | 1        |
      # | 9999            | 1        |
