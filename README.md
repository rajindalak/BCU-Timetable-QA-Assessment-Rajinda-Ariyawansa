#  BCU Timetable QA Assessment  
**Author:** Rajinda Ariyawansa 
**email:** rajinda_lak@yahoo.com 

---

##  Overview

This repository contains QA assessment work completed for the **BCU Timetable Integration project**, including:

-  Manual test case design and execution
-  API testing with Postman
-  UI automation using Reqnroll (SpecFlow)

---

##  Manual Testing Summary

### User Stories Covered

- **Test Cases Created For:**  
  `#3799`, `#3800`, `#3801`, `#3802`, `#3803`, `#3804`

- **Partially Tested:**  
  `#3802`, `#3803`, `#3804`  
  Issues found during testing are documented in the **Issues** column of the Excel file.

-  **Defects:**  
  Not created due to time limitations.

 **Test Case File:**  
`/TestCases/Tester_Assessment_Test_Cases_3799_to_3804.xlsx`

---

##  API Testing

### Endpoint Tested
GET /course/page/{pageNumber}?sortOptions={sortOptions}

### Tools Used:
- Postman Collection
- Custom test data file (`testData.json`)

### API Request Notes:
- This test validates the **pagination** and **sorting** functionality of course listings.
- A Postman test script dynamically asserts conditions based on the endpoint and query values.
- Assertions include:
  -  Status code is `200`, `400`, or `404` depending on input.
  -  Response time is under 1000ms.
  -  For valid page `1` and `sortOptions=1`:
    - `totalItems = 50`
    - First two courses:
      - `"Generic Frozen Chips"` with `id=24`, `code=4531354111525`
      - `"Generic Frozen Shirt"` with `id=4`, `code=5710339422491`
  -  Invalid page (`-1`) returns `400` or `404`.
  -  Invalid sort option (`sortOptions=name`) returns `400` with `errors` key in the body.
  -  Page with no data (`page=999`) returns an empty `items[]` array.

 **Files:**
- `APITests/Contoso Timetable Integration.postman_collection.json`
- `APITests/testData.json`

---

### Scenario Implemented:
Feature: Students Page

Scenario: Load students page and validate content  
Given I navigate to the students page  
Then the page should load successfully  
And I should see column headings:  
  | Enrollment Date |  
  | Name            |  
  | Email           |  
  | Address         |  
And the table should contain "Viola Waters" with email "Murray89@hotmail.com"

 **Purpose:**  
This scenario verifies that the Students page loads correctly, checks the presence of expected column headings, and confirms the table includes specific student records.

 **Location:**  
Feature file: `ReqnrollTestProject/Features/Students.feature`  
Step definitions: `ReqnrollTestProject/StepDefinitions/StudentsStepDefinitions.cs`
---


## 📝 Notes

- This assessment was completed within a tight timeframe.
- Manual tests, API tests, and one automation scenario were included to showcase test variety.
- Defect logging and deeper UI automation were deprioritized due to time constraints.

---

**Thank you for reviewing my submission!**
