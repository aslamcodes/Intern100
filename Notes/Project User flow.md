## User Books a Cab 

### Passenger
1. If User is new to platform
	1. Then, ==Registers==
	2. Else, ==Logins==
3. After authentication himself, he== looks for nearby cabs==
4. After selecting a cab, he ==books for a ride==
5. The requested ride is on status ==requested==
### Driver 
#### Accepts the request
1. Driver ==gets a notification== for ride request
2. Driver ==accepts the ride==
5. The requested ride is on status ==accepted==
#### Driver arrives & Passenger Boarded
1. Driver ==Sets the ride status to inProgress==
2. From there ==ride time is started==
#### Cab arrives at destination
1. Passenger  ==Sets the ride status to completed==
2. From there ==ride time is stopped==
3. ==Fare is calculated==

#### Declines the request
1. Driver ==gets a notification== for ride request
2. Driver ==declines the ride==
5. The requested ride is on status ==rejected==

### User Cancels a Ride (Passenger)

Before onboarding the cab, the user changes mind to cancel the ride

