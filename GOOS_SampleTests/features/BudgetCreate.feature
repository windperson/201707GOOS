@web
@CleanBudgets
Feature: BudgetCreate

Scenario: Add a budget successfully
	Given go to adding budget page
	When I add a budget 2000 for "2017-10"
	Then It should dispaly "added successfully"
