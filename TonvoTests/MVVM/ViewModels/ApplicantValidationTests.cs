using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tonvo.MVVM.Models;
using Tonvo.Core;
using Tonvo.Services;
using System.Windows.Documents;

namespace Tonvo.MVVM.ViewModels.TonvoTests
{
    [TestClass()]
    public class ApplicantValidationTests
    {
        // Корректные данные
        readonly Applicant applicant = new()
        {
            ProfessionName = "Test",
            ApplicantSalary = "0",
            WorkExperience = "0",
            Name = "Test",
            SecondName = "Test",
            Birthday = "02.02.2002",
            Email = "Test@test.test6",
            Password = "Test123!@#"
        };

        #region ValidData
        [TestMethod()]
        public void AddApplicantCommand_ValidData_Test()
        {
            bool expected = false;

            EventManager.OnValidated();

            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion ValidData

        #region ProfessionName
        [TestMethod()]
        public void AddApplicantCommand_Empty_ProfessionName_Test()
        {
            applicant.ProfessionName = "";
            
            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_Unvalid_ProfessionName_Test()
        {
            applicant.ProfessionName = "12345";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion ProfessionName

        #region ApplicantSalary
        [TestMethod()]
        public void AddApplicantCommand_Unvalid_ApplicantSalary_Test()
        {
            applicant.ApplicantSalary = "unvalid";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_Empty_ApplicantSalary_Test()
        {
            applicant.ApplicantSalary = "";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion ApplicantSalary

        #region WorkExperience
        [TestMethod()]
        public void AddApplicantCommand_Empty_WorkExperience_Test()
        {
            applicant.WorkExperience = "";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_Unvalid_WorkExperience_Test()
        {
            applicant.WorkExperience = "Unvalid";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion WorkExperience

        #region Name
        [TestMethod()]
        public void AddApplicantCommand_Empty_Name_Test()
        {
            applicant.Name = "";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_Unvalid_Name_Test()
        {
            applicant.Name = "12345";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion Name

        #region SecondName
        [TestMethod()]
        public void AddApplicantCommand_Empty_SecondName_Test()
        {
            applicant.SecondName = "";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_Unvalid_SecondName_Test()
        {
            applicant.SecondName = "12345";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion SecondName

        #region Birthday
        [TestMethod()]
        public void AddApplicantCommand_Empty_Birthday_Test()
        {
            applicant.SecondName = "";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_Under_14_Birthday_Test()
        {
            applicant.Birthday = "01.01.2009";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_FutureDate_Birthday_Test()
        {
            applicant.Birthday = "01.01.2023";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion Birthday

        #region Email
        [TestMethod()]
        public void AddApplicantCommand_Empty_Email_Test()
        {
            applicant.Email = "";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_Unvalid_Email_Test()
        {
            applicant.Email = "Unvalid";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion Email

        #region Password
        [TestMethod()]
        public void AddApplicantCommand_Empty_Password_Test()
        {
            applicant.Password = "";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_NoCaps_Password_Test()
        {
            applicant.Password = "test123!@#";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        public void AddApplicantCommand_NoSymbol_Password_Test()
        {
            applicant.Password = "Test12345";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_NoNumber_Password_Test()
        {
            applicant.Password = "Test!@#";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_NoLowercaseLetters_Password_Test()
        {
            applicant.Password = "TEST123!@#";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddApplicantCommand_Under_8_Password_Test()
        {
            applicant.Password = "Test1!";

            EventManager.OnValidated();

            bool expected = true;
            bool result = applicant.HasErrors;

            Assert.AreEqual(expected, result);
        }
        #endregion Password
    }
}