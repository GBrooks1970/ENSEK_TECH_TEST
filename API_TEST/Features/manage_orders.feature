@ENSEK-manage_orders
Feature: Manage Orders
  As an authenticated user
  I want to retrieve and manage my orders
  So that I can track and delete them

  @ENSEK-manage_orders-001
  @positive
  Scenario: View all orders
    Given I am authenticated
    When I request to view my orders
    Then the system returns my order history

  @ENSEK-manage_orders-002
  Scenario: View orders without authentication
    Given I am not authenticated
    When I request to view my orders
    Then I am denied access with a 401 Unauthorized response

  @ENSEK-manage_orders-003
  @ignore
  @positive
  Scenario: Delete an order by ID
    Given I am authenticated
    And I have a valid order ID
    When I request to delete the order
    Then the system confirms the deletion

  @ENSEK-manage_orders-004
  @ignore
  @positive
  Scenario: Update a specific order
    Given I provide valid order data in the body
    When I send a PUT request to /ENSEK/orders/abc123
    Then I should receive a 200 response confirming the update
