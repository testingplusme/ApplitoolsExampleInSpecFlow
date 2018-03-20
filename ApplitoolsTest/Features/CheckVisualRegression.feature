Feature: CheckVisualRegression

Scenario Outline: As user I enter to blog
	Given I enter to <EvniromentType> blog
Examples: 
| EvniromentType |
| staging        |
| production     |