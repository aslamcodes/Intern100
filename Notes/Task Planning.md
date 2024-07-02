# June 25
## Before Lunch
- [x] Booking page, fetch call
- [x] Driver's My Ride Page with Accept ride and reject rides
	- [x] Need to have cabs
		- [x] Need to update cab's location
		- [x] Need to be verified by Admin
		- [ ] *Admin Verification needs css*
- [x] Passenger My Rides page with current rides that are 
	- [x] `InProgress` with
	- [x] `Cancel Ride`
	- [x] Need to book a ride first
- [x] Fetch data for Rides
## Before Afternoon
- [x] Some kind of functionality for passenger to `initiate` and `finish` ride
- [ ] Profile Page (Update Profile)
- [x] Admin Page to Approve
	- [x] drivers and
	- [ ] cabs
## Before Sleep
- [x] Way to display validation errors & failures from backend calls 
- [ ] Fix issues

## What went wrong
- $fixed w - 

```bash
npx parcel serve index.html app/*.html app/driver/*.html app/user/*.html app/admin/*.html
```

	- Parcel not hot reloading some of the pages, I build individual page of focus, hit on productivity
	- Navigation with js doesnt worked as expected
### Conclusion
- I have covered about 80% ~ 75tasks I listed yesterday, that was great, the problems the project grows in tasks
# June 26 - (Not) The End
## Migrated Tasks
- [x] *Admin Verification needs css*
- [x] Way to display validation errors & failures from backend calls 
- [ ] Fix github issues
- [x] Profile Page
	- [x] (Update Profile)
- [x] *Admin Verification needs css*
## Before Lunch
- [x] Fix [[UI flows]]
- [x] Show content related to current user and fix nav flows
- [x] Show content related to current user
	- [x] Way Show error messages on inappropriate pages
- [x] Profile Page
- [x] Fix those undefined-s

## Before Evening
- [x] Navbar flows
- [x] Navbar responsive
- [x] Edit Profile
- [x] Setup a Image system
## Before Sleep
- [x] Fix Main flow's UI
- [x] Cab Rating
- [x] Upload user avatars, cab Images
	- [ ] Not everywhere
- [x] Make every navbar sidebar-able
- [x] Setup Icons
- [ ] Test the frontend



# June 27
## Critical 
- [x] Only One cab active per driver
	- [x] Driver Cab page
	- [x] Fetch only `Active` cabs
	- [x] Set cabs in ride to be `InRide`
- [x] Book any cab not working properly (FEBE)
- [x] No way to verify a cab (FEBE)
- [x] Passenger cannot book, if he's invloved in a ride (should have a onRide)

## Before Evening
- [x] Everything in the Crictical

# 30th June
- [ ] Sidebar not working fine `!!`
## Driver
- [x] My Cabs Page and Ride Request page `!!`
	- [x] Data richness 
	- [x] Sort, Filter, Search
- [ ] Driver Profile Page needs improvement `!!`
- [ ] Cab Image upload and retrieval `!!`
## Admin
- [x] Cab Verification Page and Endpoint `!!!`
	- [ ] Data richness (profile)
	- [x] Search, sort, filtering
- [x] navigation flow fix for admin `!!!` 
- [x] Manage driver page `!!` 
	- [ ] Data richness `!`
	- [x] Search, sort, filtering `!!`
## Profile Page
- [ ] Data Richeness `!`
- [x] Add Cab Page 

# Common
- [ ] Proper error handling `!!`
- [ ] Search, sort, filter functions `!!!`
- [ ] Sidebar not working fine `!!`
- [x] Ride Price not working as expected (Remove distance factor) `!!!`