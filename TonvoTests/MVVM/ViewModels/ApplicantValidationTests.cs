using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tonvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Tonvo.Models;
using Tonvo.Core;
using Tonvo.Services;

namespace Tonvo.ViewModels.TonvoTests
{
    [TestClass()]
    public class ApplicantValidationTests
    {
        [TestMethod()]
        public void AddNewUser_with_ValidData_Test()
        {
            RootViewModel rootViewModel = new();
            int expected = DataStorage.ReadApplicantsJson().Count() + 1;
            Applicant applicant = new()
            {
                ProfessionName= "Test",
                ApplicantSalary = "0",
                WorkExperience= "0",
                Name= "Test",
                SecondName= "Test",
                Birthday= "02.02.2002",
                Email= "Test@test.test2",
                Password= "Test123!@#"
            };
            EventManager.OnValidated();
            if (!applicant.HasErrors)
            {
                DataStorage.Add(applicant);
            }

            int actual = DataStorage.ReadApplicantsJson().Count(); 
            Assert.AreEqual(expected, actual);
        }
        

        [TestMethod()]
        public void AddApplicantCommand_ValidData_Test()
        {
            DataStorage.Init();
            bool expected = false;

            Applicant applicant = new()
            {
                ProfessionName= "Test",
                ApplicantSalary = "0",
                WorkExperience= "0",
                Name= "Test",
                SecondName= "Test",
                Birthday= "02.02.2002",
                Email= "Test@test.test2",
                Password= "Test123!@#"
            };

            EventManager.OnValidated();

            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_UnvalidProfessionName_Test()
        {
            DataStorage.Init();
            bool expected = true;

            Applicant applicant = new()
            {
                ProfessionName = "Test12345",
                ApplicantSalary = "0",
                WorkExperience = "0",
                Name = "Test",
                SecondName = "Test",
                Birthday = "02.02.2002",
                Email = "Test@test.test",
                Password = "Test123!@#"
            };

            EventManager.OnValidated();

            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_UnvalidApplicant_Test()
        {
            DataStorage.Init();
            bool expected = true;

            Applicant applicant = new()
            {
                ProfessionName = "Test",
                ApplicantSalary = "sfffw",
                WorkExperience = "0",
                Name = "Test",
                SecondName = "Test",
                Birthday = "02.02.2002",
                Email = "Test@test.test",
                Password = "Test123!@#"
            };

            EventManager.OnValidated();

            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
    }
}