using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System;

namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public class StudentsStepDefinitions
    {
        private ChromeDriver driver;
        private WebDriverWait wait;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"I navigate to the students page")]
        public void GivenINavigateToTheStudentsPage()
        {
            driver.Navigate().GoToUrl("https://localhost:7092/students");
        }

        [Then(@"the page should load successfully")]
        public void ThenThePageShouldLoadSuccessfully()
        {
            Assert.IsTrue(driver.Title.Contains("Students"), "Students page did not load properly.");
        }

        [Then(@"I should see column headings:")]
        [Then(@"I should see column headings:")]
        public void ThenIShouldSeeColumnHeadings(Table table)
        {
            var expectedHeadings = table.Rows.Select(r => r[0]).ToList();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IList<string> actualHeadings = wait.Until(d =>
            {
                try
                {
                    return d.FindElements(By.CssSelector("table thead th"))
                            .Select(e => e.Text.Trim())
                            .ToList();
                }
                catch (StaleElementReferenceException)
                {
                    return null; // Let the wait retry
                }
            });

            foreach (var heading in expectedHeadings)
            {
                Assert.IsTrue(actualHeadings.Contains(heading), $"Missing heading: {heading}");
            }
        }

        [Then(@"the table should contain ""(.*)"" with email ""(.*)""")]
        public void ThenTheTableShouldContainWithEmail(string expectedName, string expectedEmail)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool found = wait.Until(d =>
            {
                try
                {
                    var rows = d.FindElements(By.CssSelector("table tbody tr"));
                    foreach (var row in rows)
                    {
                        var text = row.Text.Trim().ToLowerInvariant();
                        if (text.Contains(expectedName.ToLowerInvariant()) &&
                            text.Contains(expectedEmail.ToLowerInvariant()))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false; // Retry the wait
                }
            });

            Assert.IsTrue(found, $"Expected to find student {expectedName} with email {expectedEmail}");
        }
    }
}
