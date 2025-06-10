@ENSEK-reset_system_state
Feature: Reset System State
  As a QA tester
  I want to reset the test environment
  So that I can start from a clean state

  @ENSEK-reset_system_state-001
  @positive
  Scenario: Reset environment with valid token
    Given I am authenticated
    When I request to reset the system
    Then the system is reset successfully

  @ENSEK-reset_system_state-002
  @negative
  Scenario: Reset environment without token
    Given I am not authenticated
    When I request to reset the system
    Then I am denied access with a 401 Unauthorized response