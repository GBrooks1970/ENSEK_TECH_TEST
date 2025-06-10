# POSTMAN Collections

This folder contains Postman collections and environment files for testing ENSEK's API endpoints.

## Contents

- **ENSEK_API_Test_Collection_v6.postman_collection.json**  
  Main Postman collection covering authentication, energy types, orders, and other API endpoints.

- **ENSEK_API_Environment_v6.postman_environment.json**  
  Environment file with variables for API base URL, credentials, and other configuration.

## Usage

You can run the collection using [Newman](https://www.npmjs.com/package/newman):

```
newman run ENSEK_API_Test_Collection_v6.postman_collection.json -e ENSEK_API_Environment_v6.postman_environment.json
```

Or use the provided batch file from the repository root for timestamped results:

```
..\RUN_POSTMAN_COLLECTION.BAT
```

## Notes

- Update the environment file with your API credentials and endpoints as needed.
- Results will be saved to a timestamped file when using the batch script.
- For more details on the API, refer to the Swagger documentation or the main project README.

---