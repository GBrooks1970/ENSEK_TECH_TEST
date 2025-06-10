# API Bug Reports

## Bug Report 1

**Title:** Viewing Orders Without Authentication Returns 200 OK Instead of 401 Unauthorized

**Environment:**  
- API_BDD_Test_Project, .NET 6.0  
- Test run: 2025-06-09  
- Endpoint: GET /orders (view my orders)

**Steps to Reproduce:**
1. Ensure no authentication token is provided.
2. Send a request to view orders.

**Expected Result:**  
The API should return a 401 Unauthorized response.

**Actual Result:**  
The API returns a 200 OK response.

**Evidence:**  
```
Then I am denied access with a 401 Unauthorized response
-> error:   Expected: Unauthorized
  But was:  OK
```

**Impact:**  
Unauthenticated users can access order data, which is a security risk.

---

## Bug Report 2

**Title:** Retrieving Energy Types Without Authentication Returns 200 OK Instead of 401 Unauthorized

**Environment:**  
- API_BDD_Test_Project, .NET 6.0  
- Test run: 2025-06-09  
- Endpoint: GET /energyTypes (retrieve all energy types)

**Steps to Reproduce:**
1. Ensure no authentication token is provided.
2. Send a request to retrieve the list of energy types.

**Expected Result:**  
The API should return a 401 Unauthorized response.

**Actual Result:**  
The API returns a 200 OK response.

**Evidence:**  
```
Then I am denied access with a 401 Unauthorized response
-> error:   Expected: Unauthorized
  But was:  OK
```

**Impact:**  
Unauthenticated users can access energy type data, which may expose sensitive information.

---