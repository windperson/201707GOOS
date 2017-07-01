Feature: BudgetCreate

Scenario: Add a budget successfully
	Given go to adding budget page
	And I add a budget 2000 for "2017-10"
	When I press add
	Then It should dispaly "added successfully"
