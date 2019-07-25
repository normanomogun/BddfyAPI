using System;
using System.CodeDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestStack.BDDfy;

namespace APITests
{
    [Story(AsA = "As A user ", 
        IWant = "I want to be able to get users on the website", 
        SoThat = "So that I can verify users")]

    [TestFixture]
    public class UserTests
    {
        private UserSteps _userSteps;

        public UserTests()
        {
            _userSteps = new UserSteps();
        }

        

        [Test]
        public void CreateValidUser()
        {
            string jsonString = "{\"name\":\"morpheus\",\"job\":\"leader\"}";
            this.Given(x => _userSteps.GivenIHaveSetEndPoint("/api/users"))
                .When(x => _userSteps.WhenICreateAPostResquest(jsonString))
                .Then(x => _userSteps.ThenIVerifyUserHasBeenCreated("morpheus")).BDDfy();
        }

        [Test]
        public void VerifyAUser()
        {
            this.Given(x => _userSteps.GivenIHaveSetEndPoint("/api/users/2"))
                .When(x => _userSteps.WhenICreateAGetRequest())
                .Then(x => _userSteps.ThenIVerifyUser("Janet")).BDDfy();
        }
    }
}
