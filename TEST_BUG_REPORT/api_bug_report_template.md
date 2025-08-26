# API Bug Report Template

## Bug Summary

- **Title:** [Concise bug title]
- **Date Reported:** [YYYY-MM-DD]
- **Reported By:** [Your Name or Test Suite Name]
- **Environment:** [e.g., Staging / UAT / Production]
- **Test Type:** [Manual / Automated]

---

## Description

- Brief overview of the bug and what is failing.

**Example:**

> The `POST /users` endpoint allows creation without a required email field.

---

## Steps to Reproduce (Manual or from Test Logs)

1. [Call endpoint with missing/invalid payload]
2. [Observe HTTP response and status code]
3. [Compare with expected behavior from API contract]

---

## Expected Result

- Describe what should have happened according to the API specification or user story.

**Example:**

> Response should return HTTP 400 with validation error indicating missing `email` field.

---

## Actual Result

- Describe the actual outcome.

**Example:**

> Response returned HTTP 200 and created the user with a null email field.

---

## Logs & Evidence

- **HTTP Request**: (Include curl/Postman/raw payload)
- **HTTP Response**: (Body + status code)
- **Test Logs (if automated)**:

```text
  [TestSuite] FAIL: test_create_user_without_email
  Expected: 400 Bad Request
  Received: 200 OK
  ```

---

## Severity & Impact

- **Severity:** [Low / Medium / High / Critical]
- **Impact Area:** [e.g., Data Integrity / Security / Business Logic]
- **Reproducibility:** [Always / Intermittent / Rare]

---

## Associated Tests

- **Test Case Name/ID:** [Link or reference to automated test or BDD scenario]
- **Test Type:** [Functional / Contract / Security / Performance]

---

## Suggested Fix / Notes

- [Optional recommendations for fixing the bug or additional observations]

---

## Status

- [Open / Investigating / Resolved / Deferred]

---

## Assignment

- **Owner:** [Developer or Team]
- **Target Release/Fix Version:** [Optional]
