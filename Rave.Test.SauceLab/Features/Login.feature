
Feature: Login Page
  
  Scenario:Check Successful Login For Valid User 
    When  I enter username "9819606607" and passowrd "1234"
    And   I click on login button
    Then  the correct username "Rahul Sonawane (Rave_QA)" should be displayed 