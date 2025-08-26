# Postman API Bug Reports

## Bug Report 1

**Title:** Viewing Energy Types Without Authentication Returns 200 OK Instead of 401 Unauthorized

**Environment:**  

- ENSEK_API_Test_Collection_v6 (Postman/Newman)  
- Test run: 2025-06-09  
- Endpoint: GET /ENSEK/energy

**Steps to Reproduce:**

1. Send a GET request to `/ENSEK/energy` without authentication.

**Expected Result:**  
The API should return a 401 Unauthorized response.

**Actual Result:**  
The API returns a 200 OK response.

**Evidence:**  

```text
AssertionError  Status code is 401
expected response to have status code 401 but got 200
inside "View Energy Types - No Auth"
```

**Impact:**  
Unauthenticated users can access energy type data, which is a security risk.

---

## Bug Report 2

**Title:** Viewing All Orders Without Authentication Returns 200 OK Instead of 401 Unauthorized

**Environment:**  

- ENSEK_API_Test_Collection_v6 (Postman/Newman)  
- Test run: 2025-06-09  
- Endpoint: GET /ENSEK/orders

**Steps to Reproduce:**

1. Send a GET request to `/ENSEK/orders` without authentication.

**Expected Result:**  
The API should return a 401 Unauthorized response.

**Actual Result:**  
The API returns a 200 OK response.

**Evidence:**  

```text
AssertionError  Status code is 401
expected response to have status code 401 but got 200
inside "View All Orders - No Auth"
```

**Impact:**  
Unauthenticated users can access order data, which is a security risk.

---

## Bug Report 3

**Title:** Deleting Order By OrderId Returns 500 Internal Server Error Instead of 200 OK

**Environment:**  

- ENSEK_API_Test_Collection_v6 (Postman/Newman)  
- Test run: 2025-06-09  
- Endpoint: DELETE /ENSEK/orders/{orderId}

**Steps to Reproduce:**

1. Send a DELETE request to `/ENSEK/orders/{orderId}` with a valid order ID and authentication.

**Expected Result:**  
The API should return a 200 OK response indicating successful deletion.

**Actual Result:**  
The API returns a 500 Internal Server Error.

**Evidence:**  

```text
AssertionError  Status code is 200
expected response to have status code 200 but got 500
inside "Delete Order By OrderId"
```

**Impact:**  
Orders cannot be deleted as expected; indicates a server-side error.

---

## Bug Report 4

**Title:** Deleting Order By OrderId Without Authentication Returns 500 Internal Server Error Instead of 200 OK or 401 Unauthorized

**Environment:**  

- ENSEK_API_Test_Collection_v6 (Postman/Newman)  
- Test run: 2025-06-09  
- Endpoint: DELETE /ENSEK/orders/{orderId}

**Steps to Reproduce:**

1. Send a DELETE request to `/ENSEK/orders/{orderId}` without authentication.

**Expected Result:**  
The API should return a 401 Unauthorized response (or at least not a server error).

**Actual Result:**  
The API returns a 500 Internal Server Error.

**Evidence:**  

```text
AssertionError  Status code is 200
expected response to have status code 200 but got 500
inside "Delete Order By OrderId - No Auth"
```

**Impact:**  
Server error is returned for unauthenticated delete requests, which may expose internal details and is not secure.

---
