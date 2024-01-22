Feature: BankSystem

Scenario Outline: Create new Account with valid data
  Given Account Initial Balance is <InitialBalance>
  And Account name is "<AccountName>"
  And Address is "<Address>"
  When POST endpoint triggered to create new account with above details
  Then Verify the response code is 200
  And Verify no error is returned
  And VVerify the success message for created case "<SuccessMessage>"
  And Verify the account details are correctly returned in the JSON response

Examples:
  | InitialBalance | AccountName      | Address               | SuccessMessage	                |
  | 1000           | "Rajesh Mittal"  | "Ahmedabad, Gujarat"  | "Account created successfully"  |

Scenario Outline: Delete Account with valid account ID
  Given Account ID is "<AccountID>"
  When DELETE endpoint triggered to delete account with above ID
  Then Verify the response code is 200
  And Verify no error is returned
  And Verify the success message for delete case "Account <AccountID> deleted successfully"

Examples:
  | AccountID |
  | "X123"    |

Scenario Outline: Deposit to Account with valid data
  Given Account Number is "<AccountNumber>"
  And Amount to deposit is <DepositAmount>
  When PUT endpoint triggered to deposit to account with above details
  Then Verify the response code is 200
  And Verify no error is returned
  And Verify success message "<DepositMessage>"
  And Verify the new balance is <NewBalance>

Examples:
  | AccountNumber | DepositAmount   | DepositMessage                                 | NewBalance |
  | "X123"         | 1000           | "1000$ deposited to Account X123 successfully" | 2000        |

Scenario Outline: Withdraw from Account with valid data
  Given Account Number is "<AccountNumber>"
  And Amount to withdraw is <WithdrawAmount>
  When PUT endpoint triggered to withdraw from account with above details
  Then Verify the response code is 200
  And Verify no error is returned
  And Verify the success message for withdrawal "<WithdrawMessage>"
  And Verify the new balance is <NewBalance>

Examples:
  | AccountNumber | WithdrawAmount  | WithdrawMessage								  | NewBalance  |
  | "X123"         | 500            | "500$ withdrawn from Account X123 successfully" | 1500        |
