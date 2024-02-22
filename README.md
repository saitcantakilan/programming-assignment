# Obilet

The project is a web application used to search for bus journeys by criteria and to list the journeys.

Using the GetSession method of the Obilet.com business API, a session is created and maintained for each different end user who visits the application. Each user uses their session information in API requests made by the application on behalf of that user.
All available bus locations are retrieved from the obilet.com business API GetBusLocations. They are then listed as from and to.

The from, to and date selected by the user is passed to the obilet.com business API GetJourneys method. Then, according to the API response, the journeys are sorted by departure times and displayed to the user.

The user's session information and selections are stored in the cookie.

