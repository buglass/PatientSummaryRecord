# Patient Summary Record API

Welcome to the patient summary record API.

## Features

- Returns a 200 response with the patient summary record for a recognised
patient ID.

- Returns a 404 response for an unrecognised patient ID.

- Returns a 500 response when multiple patient records with matching IDs are
found.

## Tests

### Unit Tests

These can be run from within the tests project.

### API Tests

These make the assumptions; that there will always be a patient with an ID of
1, and that there will never be a patient with an ID of 0.

`newman run PatientSummary.postman_collection.json`

## Limitations

This PoC application has been built strictly to specification and has some
notable omissions which could be considered for any future development.

- There is no attempt to validate the DTO when retrieving it from the
repository.

- The .NET version is deprecated.
