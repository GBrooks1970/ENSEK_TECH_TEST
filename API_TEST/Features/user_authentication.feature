@ENSEK-user_authentication
Feature: User Authentication
  As a registered user
  I want to authenticate using valid credentials
  So that I can access the ENSEK API endpoints

  @ENSEK-user_authentication-001
  @positive
  Scenario: Successful login with valid credentials
    Given I have valid credentials
    When I attempt to log in
    Then I am successfully authenticated with a bearer token

  @ENSEK-user_authentication-002
  @negative
  Scenario: Login with invalid credentials
    Given I have invalid credentials
    When I attempt to log in
    Then I am denied access with a 401 Unauthorized response