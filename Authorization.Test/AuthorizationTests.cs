﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserManagement;

namespace Authorization.Test
{
    [TestClass]
    public class AuthorizationTests
    {
        [TestMethod]
        public void Authorization_CheckUserRoleGeneral_Pass()
        {
            // Arrange
            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            User user = new User(username, password, dob, city, stateProvince, country, role);

            var expected = "GENERAL";
            var actual = "";

            // Create a fake Authorizable object using Moq
            var authorization = new Mock<IAuthorizable>();

            // Set up the auth in order to return exactly
            // what we expect
            authorization
                .Setup(m => m.CheckUserRole(user))
                .Returns("GENERAL");

            var service = new Authorization(authorization.Object);

            // Act
            // Get actual user role
            actual = service.CheckUserRole(user);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authorization_CheckUserRoleAdmin_Pass()
        {
            // Arrange
            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            User user = new User(username, password, dob, city, stateProvince, country, role);

            var expected = "THEATRE_ADMIN";
            var actual = "";

            // Create a fake Authorizable object using Moq
            var authorization = new Mock<IAuthorizable>();

            // Set up the auth in order to return exactly
            // what we expect
            authorization
                .Setup(m => m.CheckUserRole(user))
                .Returns("GENERAL");

            var service = new Authorization(authorization.Object);

            // Act
            // Get actual user role
            actual = service.CheckUserRole(user);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}