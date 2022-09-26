using FakeApiTest.POJO;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace FakeApiTest.StepDefinitions
{
    [Binding]
    public class FakerApiUserStepDefinitions
    {
        public static User userM;
        public static RestResponse response;
        private const string BASE_URL = "https://fakerestapi.azurewebsites.net/api/v1/Users";
        [Given(@"request passed with user id (.*)")]
        public void GivenRequestPassedWithUserId(int user)
        {
            // arrange
            RestClient client = new RestClient(BASE_URL);
            RestRequest request =
                new RestRequest(user.ToString(), Method.Get);

            // act
            response = client.Execute(request);
            userM = JsonConvert.DeserializeObject<User>(response.Content);

            
            
        }

        [Then(@"verify request status")]
        public void ThenVerifyRequestStatus()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Request failed");
        }


        [Then(@"verify user name to be (.*)")]
        public void ThenVerifyUserNameToBeUser(string userName)
        {
            Assert.AreEqual(userM.userName, userName);
        }

        [Then(@"verify user pwd to be (.*)")]
        public void ThenVerifyUserPwdToBePassword(string pwd)
        {
            Assert.AreEqual(userM.password, pwd);
        }


    }
}
