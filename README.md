# String Calculator
http://osherove.com/tdd-kata-1/

The following is a TDD Kata- an exercise in coding, refactoring and test-first, that you should apply daily for at least 15 minutes (I do 30).

Before you start:
 
* Try not to read ahead.
* Do one task at a time. The trick is to learn to work incrementally.
* Make sure you only test for correct inputs. there is no need to test for invalid inputs

Create a simple String calculator with a method `int Add(string numbers)`

The method can take 0, 1 or 2 numbers, and will return their sum. 
For an empty string, `""`, it must return 0.
For `"1"`, it must return 1.
For `"1,2"`, it must return 3.

* Start with the simplest test case of an empty string and move to one and two numbers.
* Solve things as simply as possible so that you force yourself to write tests you did not think about an extensive design up front.
* Refactor after each passing test.

Add these features. 

1. Allow the Add method to handle an unknown amount of numbers
1. Allow the Add method to handle new lines between numbers (instead of commas).
	* the following input is ok: `"1\n2,3"` and must be equal to 6
	* the following input is **NOT** ok:  `"1,\n"`
1. Add support for different delimiters
	* The beginning of the input will contain a separate line containing the delimiter
	`"//[delimiter]\n[numbers…]"` 
	* For example: `"//;\n1;2` should return 3, and the default delimiter is `';'`
1. This delimiter specification line is optional. All existing scenarios must still be supported
1. Calling Add with a negative number should throw an exception "negatives not allowed" - and the negative that was passed.
1. If there are multiple negatives, show all of them in the exception message

**Stop here if you are a beginner. Continue if you can finish the steps so far in less than 30 minutes.**

1. Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2
1. Delimiters can be of any length with the following format:  `//[delimiter]\n` 
	* for example: `"//[***]\n1***2***3"` should return 6
1. Allow multiple delimiters using this format: `"//[delim1][delim2]\n"` 
	* `"//[*][%]\n1*2%3` should return 6.
1. Handle multiple delimiters with length longer than one character