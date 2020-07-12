# Convert-numbers-to-words
Visual Studio 2019
Lanmguage: C#

This console application converts numbers into words.

This is a simple exercise that i wanted to perform to put my knowledge to the test.

I design a quick algorithm/logic in which i build my application around it. Here is my design:

1 - From 0 to 19, they have different name patterns => Dictionary or Enum? EnumLowNumbers

2 - After 19, every value as a more constant numerical naming e.g.: 20 = Twenty, 30 = Thirty, etc. => Dictionary or Enum? EnumMidNumbers + separator + EnumLowNumbers (31 = thirty-one) 

3 - For the values located in the 100 to 900, the word hundred is constant.

4 - I could use a method that takes a subset of three array values from the current array and handle the conversion by block of 3 in which enabled me to use bigger numerical values without the BigInteger class.

On the side note: I used ReadOnlySpan since it uses memory on the stack and also i could use very big numerical values without overflowing.

After some review in discord: I can simplify this code by using the string value and keep track of the indexer to performer a the same result. Logic is confusing. Must refirne it.
