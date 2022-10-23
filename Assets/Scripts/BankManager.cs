using System;
using System.Collections.Generic;
using FinanceFantasy.Player;
using FinanceFantasy.Tick;
using UnityEngine;

namespace FinanceFantasy.Bank {
    public class BankManager : MonoSingleton {
        [SerializeField] private float LoanAmount = 3000f;
        [Tooltip("Tiempo de pago para el prestamo por cuota. En Segundos!!")]
        [SerializeField] private int loanPaymentTimeInSeconds = 3600;
        [Tooltip("Tiempo de pago para la tarjeta de credito. En Segundos!!")]
        [SerializeField] private int creditPaymentTimeInSeconds = 3600;
        private CreditCard _playerCurrentCard;
        private Loan _playerCurrentLoan;
        private Insurance _playerInsuranceLoan;

        // Observable 
        // Used action because we don't need to return values, only notify some UI elements
        public static Action<BankOperation> SignUpWithBank;
        public CreditCard CurrentCreditCard { get { 
                return _playerCurrentCard;
            }
        }
        private BankController _bankController = new BankController();
        private PlayerMoney _playerMoney;

        protected override void Awake() {
            base.Awake();
            
            //_bankController = new BankController();
            _playerMoney = FindObjectOfType<PlayerMoney>();
        }

        private void Update() {
            if (_playerCurrentCard != null) {
                if (_playerCurrentCard.PaymentTime <= 0) {
                    //GameManager.instance.TakeMoney(x);
                    GameManager.instance.TakeMoney(_playerCurrentCard.MouthPayment);
                    _playerMoney.TakeMoney(_playerCurrentCard.MouthPayment);
                    _playerCurrentCard.ResetPayTime();
                }
            }

            if (_playerCurrentLoan != null) {
                if (_playerCurrentLoan.PaymentTime <= 0) {
                    GameManager.instance.TakeMoney(_playerCurrentLoan.MonthlyInstallments);
                    _playerMoney.TakeMoney(_playerCurrentLoan.MonthlyInstallments);
                    _playerCurrentLoan.ResetPayTime();
                    _playerCurrentLoan.PaidInstallments++;
                    if (_playerCurrentLoan.TotalInstallments == _playerCurrentLoan.PaidInstallments) {
                        _playerCurrentLoan = null;   
                    }
                }
            }
            
            // if (_playerInsuranceLoan != null) {
            //     // TODO: Cuando ocurre un catastrofe devolver total
            //     // if (ocurreAlgo) { dame plata }
            // }
        }

        public void TakeCredit() {
            print("You clicked take credit");
            // TODO: Validation stuff?
            if (_playerCurrentCard != null) {
                print("Player can only have 1 card.");
                return;
            }
            
            var card = _bankController.TakeCreditCard(creditPaymentTimeInSeconds);
            _playerCurrentCard = card;
            // _playerMoney.TakeMoney(100f);
            // Alert whoever we need to alert
            SignUpWithBank?.Invoke(_playerCurrentCard);
        }

        public void TakeLoan() {
            print("You clicked take loan");
            // TODO: Validation stuff?
            if (_playerCurrentLoan != null) {
                print("Player can only have 1 loan.");
                return;
            }
            
            var loan = _bankController.TakeLoan(LoanAmount, loanPaymentTimeInSeconds);
            // GameManager.instance.GiveMoney(loan.LoanAmount);
            GameManager.instance.GiveMoney(loan.LoanAmount);
            _playerMoney.GiveMoney(loan.LoanAmount);
            _playerCurrentLoan = loan;
            // Alert whoever we need to alert
            SignUpWithBank?.Invoke(_playerCurrentLoan);
        }

        public void TakeInsurance() {
            print("You clicked take insurance");
            // Alert whoever we need to alert
            // TODO: Validation stuff?
            if (_playerInsuranceLoan != null) {
                print("Player can only have 1 insurance.");
                return;
            }
            
            var insurance = _bankController.TakeInsurance();

            _playerInsuranceLoan = insurance;
            // _playerMoney.TakeMoney(100f);
            // Alert whoever we need to alert
            SignUpWithBank?.Invoke(_playerInsuranceLoan);
        }

        
        public bool addExpense(float _expense)
        {
            return true;
        }
    }
}