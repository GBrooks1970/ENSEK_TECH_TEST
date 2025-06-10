@ENSEK-view_energy_types
Feature: Retrieve all energy types
  As an authenticated user
  I want to retrieve available energy types
  So that I can view what energy units are for sale

  @ENSEK-view_energy_types-001
  @positive
  Scenario: Retrieve energy types with valid token
    Given I am authenticated
    When I request the list of energy types
    Then the system returns all available energy types with IDs

  @ENSEK-view_energy_types-002
  @negative
  Scenario: Retrieve energy types without authentication
    Given I am not authenticated
    When I request the list of energy types
    Then I am denied access with a 401 Unauthorized response