using API_Automation.Models;
using API_Automation.Utils;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace API_Automation
{
    [Binding]
    public class BankSteps
    {
        private RestResponse<ApiResponse<AccountDetails>> response;

        [Given(@"Account Initial Balance is (\d+)")]
        public void GivenAccountInitialBalanceIs(int initialBalance)
        {
            ScenarioContext.Current.Set(new CreateAccountRequest { InitialBalance = initialBalance });
        }

        [Given(@"Account name is ""(.*)""")]
        public void GivenAccountNameIs(string accountName)
        {
            ScenarioContext.Current.Get<CreateAccountRequest>().AccountName = accountName;
        }

        [Given(@"Address is ""(.*)""")]
        public void GivenAddressIs(string address)
        {
            ScenarioContext.Current.Get<CreateAccountRequest>().Address = address;
        }

        [When(@"POST endpoint triggered to create new account with above details")]
        public void WhenPOSTEndpointTriggeredToCreateNewAccountWithAboveDetails()
        {
            var requestBody = ScenarioContext.Current.Get<CreateAccountRequest>();
            response = Helper.ExecuteRequest<ApiResponse<AccountDetails>>("account/create", Method.Post, requestBody);
        }

        [Then(@"Verify the response code is (\d+)")]
        public void ThenVerifyTheResponseCodeIs(int expectedStatusCode)
        {
            Helper.VerifyStatusCode(response, expectedStatusCode);
        }

        [Then(@"Verify no error is returned")]
        public void ThenVerifyNoErrorIsReturned()
        {
            Helper.VerifyNoErrors(response);
        }

        [Then(@"Verify the success message ""(.*)""")]
        public void ThenVerifyTheSuccessMessage(string successMessage)
        {
            Assert.AreEqual(successMessage, response.Data.Message);
        }

        [Then(@"Verify the account details are correctly returned in the JSON response")]
        public void ThenVerifyTheAccountDetailsAreCorrectlyReturnedInTheJSONResponse()
        {
            var expectedDetails = ScenarioContext.Current.Get<CreateAccountRequest>();
            var actualDetails = response.Data.Data;

            Assert.AreEqual(expectedDetails.AccountName, actualDetails.AccountName);
            Assert.AreEqual(expectedDetails.InitialBalance, actualDetails.NewBalance);
        }

        // New Step Definitions for Delete Account Scenario

        [Given(@"Account ID is ""(.*)""")]
        public void GivenAccountIDIs(string accountID)
        {
            // Set account ID in the scenario context for the Delete Account scenario
            ScenarioContext.Current.Set(accountID);
        }

        [When(@"DELETE endpoint triggered to delete account with above ID")]
        public void WhenDELETEEndpointTriggeredToDeleteAccountWithAboveID()
        {
            var accountID = ScenarioContext.Current.Get<string>();
            var response = Helper.ExecuteRequest<ApiResponse<object>>($"account/delete/{accountID}", Method.Delete);
        }


        [Then(@"Verify the success message ""(.*)""")]
        public void ThenVerifyTheSuccessMessageForDeleteAccount(string successMessage)
        {
            Assert.AreEqual(successMessage, response.Data.Message);
        }

        // New Step Definitions for Deposit and Withdraw Scenarios

        [Given(@"Account Number is ""(.*)""")]
        public void GivenAccountNumberIs(string accountNumber)
        {
            ScenarioContext.Current.Set(accountNumber);
        }

        [Given(@"Amount to deposit is (\d+)")]
        public void GivenAmountToDepositIs(int depositAmount)
        {
            ScenarioContext.Current.Set(depositAmount);
        }

        [Given(@"Amount to withdraw is (\d+)")]
        public void GivenAmountToWithdrawIs(int withdrawAmount)
        {
            ScenarioContext.Current.Set(withdrawAmount);
        }

        [When(@"PUT endpoint triggered to deposit to account with above details")]
        public void WhenPUTEndpointTriggeredToDepositToAccountWithAboveDetails()
        {
            var requestBody = new DepositRequest
            {
                AccountNumber = ScenarioContext.Current.Get<string>(),
                Amount = ScenarioContext.Current.Get<int>()
            };
            response = Helper.ExecuteRequest<ApiResponse<AccountDetails>>("account/deposit", Method.Put, requestBody);
        }

        [When(@"PUT endpoint triggered to withdraw from account with above details")]
        public void WhenPUTEndpointTriggeredToWithdrawFromAccountWithAboveDetails()
        {
            var requestBody = new WithdrawRequest
            {
                AccountNumber = ScenarioContext.Current.Get<string>(),
                Amount = ScenarioContext.Current.Get<int>()
            };
            response = Helper.ExecuteRequest<ApiResponse<AccountDetails>>("account/withdraw", Method.Put, requestBody);
        }

        [Then(@"Verify the new balance is (\d+)")]
        public void ThenVerifyTheNewBalance(int expectedNewBalance)
        {
            var actualNewBalance = response.Data.Data.NewBalance;
            Assert.AreEqual(expectedNewBalance, actualNewBalance);
        }

        [Then(@"Verify the success message ""(.*)""")]
        public void ThenVerifyTheSuccessMessageForDepositOrWithdraw(string successMessage)
        {
            Assert.AreEqual(successMessage, response.Data.Message);
        }
    }
}
