Feature: Students Page

  Scenario: Load students page and validate content
    Given I navigate to the students page
    Then the page should load successfully
    And I should see column headings:
      | Enrollment Date |
      | Name            |
      | Email           |
      | Address         |
    And the table should contain "Viola Waters" with email "Murray89@hotmail.com"