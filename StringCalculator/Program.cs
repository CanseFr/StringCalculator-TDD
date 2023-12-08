// See https://aka.ms/new-console-template for more information

using StringCalculator;

Console.WriteLine("Hello, World!");
var test1 = "//;/4;5;6";
var test2 = "//;/-2;e;1001";
var test3 = "4,5,6";
var test4 = "-2,5;1001";
var test5 = "-2,e,1001";


var calculatorString = new CalculatorString();
calculatorString.GetInputStringToIntSum(test1);
calculatorString.GetInputStringToIntSum(test2);
calculatorString.GetInputStringToIntSum(test3);
calculatorString.GetInputStringToIntSum(test4);
calculatorString.GetInputStringToIntSum(test5);