using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APITests
{
    public class UserSteps
    {
        private ApiHelper _apiHelper;
        private CreateUser _createUser;
        public void GivenIHaveSetEndPoint(string apiUsers)
        {
            _apiHelper = new ApiHelper();
            _apiHelper.SetApiEndpoint(apiUsers);
        }


        public void WhenICreateAPostResquest(string jsonString)
        {
            _apiHelper.MakeAPostRequest(jsonString);
        }

        public void ThenIVerifyUserHasBeenCreated(string name)
        {
            var response = _apiHelper.GetResponse();
            _createUser = new CreateUser();
            _createUser = _apiHelper.DeserializeJsonObject<CreateUser>(response.Content);
            var actualName = _createUser.name;
           Assert.IsTrue(actualName == name);

        }

        public void ThenIVerifyUser(string name)
        {
            var response = _apiHelper.GetResponse();
            var user = new User();
            user = _apiHelper.DeserializeJsonObject<User>(response.Content);
            var actualName = user.data.First_name;
            Assert.IsTrue(actualName == name);

        }

        public void WhenICreateAGetRequest()
        {
            _apiHelper.MakeAGetRequest();
        }
    }
}
