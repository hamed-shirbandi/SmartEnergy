Feature: Get Consumptions

In order to monitor the consumption
As an Operator
John wants to get the consumptions as time series data

@API-Level
Scenario: Geting consumptions list as requested number
	Given John is an Operator
	When John request for consumptions list by skiping <skip> and taking <take>
	Then John can see the consumptions list successfully

  Examples:
    | skip | take |
    |   0  |   4  |

