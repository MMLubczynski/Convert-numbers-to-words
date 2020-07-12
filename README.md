# Convert-numbers-to-words
Visual Studio 2019
Lanmguage: C#

This console application converts numbers into words.

This is a simple exercise that i wanted to perform to put my knowledge to the test.

I designe a quick algorithm for my approach with this mindset:

1 - From 0 to 19, they have diffirent name patterns => Dictionary or Enum? EnumLowNumbers 
2 - After 19, every value as a more constant numerical naming e.g.: 20 = Twenty, 30 = Thirty, etc. => Dictionary or Enum? EnumMidNumbers + separator + EnumLowNumbers ( 31 = thirty-one)   
3 - For the values located in the 100 to 900, the word hundred is constant.

I could use a method that takes a subset of three values from the current array and handle the convertion by block of 3.

This initial plan when i began this application.

On the side note: I used ReadOnlySpan since it uses memory on the stack and also i could use very big numerical values without overflowing.
