using System;
using TechTalk.SpecFlow;

namespace API_Automation.StepDefinitions
{
    [Binding]
    public class BasicBankSystemStepDefinitions
    {
        [Given(@"Account ID is ""([^""]*)""X(.*)""([^""]*)""")]
        public void GivenAccountIDIsX(string p0, int p1, string p2)
        {
            throw new PendingStepException();
        }

        [When(@"DELETE endpoint triggered to delete account with above ID")]
        public void WhenDELETEEndpointTriggeredToDeleteAccountWithAboveID()
        {
            throw new PendingStepException();
        }

        [Given(@"Account Number is ""([^""]*)""X(.*)""([^""]*)""")]
        public void GivenAccountNumberIsX(string p0, int p1, string p2)
        {
            throw new PendingStepException();
        }

        [Given(@"Amount to deposit is (.*)")]
        public void GivenAmountToDepositIs(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"PUT endpoint triggered to deposit to account with above details")]
        public void WhenPUTEndpointTriggeredToDepositToAccountWithAboveDetails()
        {
            throw new PendingStepException();
        }

        [Then(@"Verify the new balance is (.*)")]
        public void ThenVerifyTheNewBalanceIs(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"Amount to withdraw is (.*)")]
        public void GivenAmountToWithdrawIs(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"PUT endpoint triggered to withdraw from account with above details")]
        public void WhenPUTEndpointTriggeredToWithdrawFromAccountWithAboveDetails()
        {
            throw new PendingStepException();
        }
    }
}
