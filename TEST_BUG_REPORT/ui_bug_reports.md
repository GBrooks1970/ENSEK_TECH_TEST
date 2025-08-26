# UI Bug Reports

## Bug Report 1

**Title:** Null Value Causes Exception When Verifying Updated Units After Purchase

**Environment:**  

- Ensek.UITests, .NET 6.0  
- Test run: 2025-06-09  
- Feature: BuyEnergy.feature

**Steps to Reproduce:**

1. Open the Buy Energy page.
2. Buy "2" units of "Gas".
3. Check for the updated units available for "Gas".

**Expected Result:**  
The test should verify the updated units without error.

**Actual Result:**  
Test fails with `System.ArgumentNullException : Value cannot be null. (Parameter 's')` at `BuyEnergySteps.cs:line 76`.

**Evidence:**  

```text
-> error: Value cannot be null. (Parameter 's') (0.0s)
Stack Trace:
   at System.Int32.Parse(String s)
   at BuyEnergySteps.ThenTheUserShouldSeeTheUnitsAvailableForAreUpdated(String energyType) in ...BuyEnergySteps.cs:line 76
```

**Impact:**  
Test cannot verify units update, masking potential UI or logic issues.

---

## Bug Report 2

**Title:** Confirmation Message Not Displayed for Negative Quantity Purchase

**Environment:**  

- Ensek.UITests, .NET 6.0  
- Test run: 2025-06-09  
- Feature: BuyEnergy.feature

**Steps to Reproduce:**

1. Open the Buy Energy page.
2. Attempt to buy "-3" units of "Electricity".

**Expected Result:**  
An error message should be displayed, and no confirmation message should appear.

**Actual Result:**  
Test fails: Confirmation message was not displayed (Expected: True, But was: False).

**Evidence:**  

-> error:   Confirmation message was not displayed.
  Expected: True
  But was:  False

```text
-> error:   Confirmation message was not displayed.
  Expected: True
  But was:  False
```

**Impact:**  
Negative quantity purchase is not handled gracefully; user feedback is unclear.

---

## Bug Report 3

**Title:** Confirmation Message Not Displayed for Negative Quantity Purchase ("-12" Gas, "-1" Electricity)

**Environment:**  

- Ensek.UITests, .NET 6.0  
- Test run: 2025-06-09  
- Feature: BuyEnergy.feature

**Steps to Reproduce:**

1. Open the Buy Energy page.
2. Attempt to buy "-12" units of "Gas" or "-1" units of "Electricity".

**Expected Result:**  
An error message should be displayed, and no confirmation message should appear.

**Actual Result:**  
Test fails: Confirmation message was not displayed (Expected: True, But was: False).

**Evidence:**  

```text
-> error:   Confirmation message was not displayed.
  Expected: True
  But was:  False
```

**Impact:**  
Negative quantity purchase is not handled gracefully; user feedback is unclear.

---

## Bug Report 4

**Title:** Error Message Not Displayed for Invalid Quantity Input ("abc" Electricity, "x1" Gas)

**Environment:**  

- Ensek.UITests, .NET 6.0  
- Test run: 2025-06-09  
- Feature: BuyEnergy.feature

**Steps to Reproduce:**

1. Open the Buy Energy page.
2. Attempt to buy "abc" units of "Electricity" or "x1" units of "Gas".

**Expected Result:**  
An error message should be displayed for invalid input.

**Actual Result:**  
Test fails: Error message was not displayed (Expected: True, But was: False).

**Evidence:**  

```text
-> error:   Expected: True
  But was:  False
```

**Impact:**  
Invalid input is not handled gracefully; user is not informed of the error.

---
