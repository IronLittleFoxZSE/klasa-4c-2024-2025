﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMauiApp
{
    public class CalculatorViewModel : BindableObject
    {
        private string calculatingResult;

        public string CalculatingResult
        {
            get { return calculatingResult; }
            set
            {
                calculatingResult = value;
                OnPropertyChanged();
            }
        }

        private Command numberCommand;
        public Command NumberCommand
        {
            get
            {
                if (numberCommand == null)
                    numberCommand = new Command<string>((string number) =>
                    {
                        if (ifOperationExecute == false)
                            CalculatingResult = CalculatingResult + number;
                        else
                        {
                            CalculatingResult = number;
                            ifOperationExecute = false;
                        }
                    });
                return numberCommand;
            }
            set { numberCommand = value; }
        }

        private Command operationCommand;
        public Command OperationCommand
        {
            get
            {
                if (operationCommand == null)
                    operationCommand = new Command<string>((string operatorSign) =>
                    {
                        if (ifOperationExecute)
                            return;

                        int firstNumber = prevNumber;
                        int secondNumber = int.Parse(calculatingResult);
                        CalculatingResult = GetOperatorResult(prevOperatorSign, firstNumber, secondNumber).ToString();
                        prevOperatorSign = operatorSign;
                        prevNumber = int.Parse(calculatingResult);
                        ifOperationExecute = true;
                    });
                return operationCommand;
            }
            set { operationCommand = value; }
        }

        private string prevOperatorSign = "+";
        private int prevNumber = 0;
        private bool ifOperationExecute = false;
        int GetOperatorResult(string operatorSign, int firstNumber, int secondNumber)
        {
            int result = operatorSign switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => firstNumber / secondNumber,
                _ => 0,
            };
            return result;
        }

        public CalculatorViewModel()
        {

        }

    }
}
