## **User Management**

- The system shall support two user roles: Passenger and Driver.
- Users shall authenticate using a secure mechanism with email and password.
- User registration shall capture additional relevant information.
- Users shall be able to modify their profile data.

## **Booking**

- Passengers shall specify pickup location and desired vehicle type.
- The system shall allocate an available taxi matching the request, considering driver availability.
- Real-time ride status shall be accessible to passengers.
- The system shall calculate fares based on pre-defined rules.
- Passengers shall be able to cancel rides before boarding.

## **Driver Registration**

- Drivers shall register by providing personal information, vehicle details, and required documents.
- A driver verification process shall be implemented.
- Drivers shall manage their availability status (online/offline).

## **Passenger Rating**

- Passengers shall be able to rate completed rides and drivers.

## **Admin Controls**

- The system shall provide an administrative interface to view key metrics:
    - Number of rides
    - Active users
- The administrator shall be able to view a list of all registered taxis and passengers.

## **Additional Notes**

- The use of sockets for real-time communication between app and server is recommended for consideration during implementation.