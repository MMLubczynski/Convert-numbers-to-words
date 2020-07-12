using System;

namespace NumbersToWords
{
    public enum NamesOfZeroToNineteenNumbers
    {
        Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Eleven, Twelve, Thirteen, Fourteen, fifteen, Sixteen, Seventeen, Eighteen, Nineteen
    };

    public enum NamesOfTwentyToNinetyNineNumbers
    {
        Twenty = 2, Thirty = 3, Fourty = 4, Fifty = 5,
        Sixty = 6, Seventy = 7, Eighty = 8, Ninety = 9
    }

    public enum NamesOfLargeNumbers
    {
        Ones, Thousand, Million, Billion, Trillion, Quadtrillion, Quintillion,
        Sextillion, Septillion, Octillion, Nonillion, Decillion
    }

    public class Transform
    {
        public string ToWords(string value)
        {
            int length = value.Length;
            int remains = length % 3;
            int numberOfSubsets = (length - 1) / 3;
            string result = String.Empty;

            ReadOnlySpan<char> span = value.AsSpan();
            while (length > 0)
            {
                if (remains != 0)
                {
                    //Process the span in a subset of one, two or three. Occurs only once at the beginning.
                    result += _ProcessSubsetOfThree(span[^length..remains], ref numberOfSubsets);
                    length -= remains;
                    remains = 0;
                }
                else
                {
                    //Process the span in a subset of three
                    result += _ProcessSubsetOfThree(span[^length..^(length - 3)], ref numberOfSubsets);
                    length -= 3;
                }
            }

            return result;
        }

        private string _ProcessSubsetOfThree(ReadOnlySpan<char> subset, ref int numberOfSubsets)
        {
            string result = String.Empty;
            string separator = String.Empty;
            string whiteSpace = " ";
            int counter = 3;
            int value = 0;
            int length = subset.Length - 1;
            int offSet = 2 - length;
            bool isNumberTen = false;
            bool isSingleZero = numberOfSubsets == 0 && offSet == 2 && subset[0].ToString() == "0" ? true : false;

            if (!isSingleZero)
            {
                for (int i = 0; i <= length; i++)
                {
                    value = Int32.Parse(subset[i].ToString());
                    switch (i + offSet)
                    {
                        case 0:
                            if (value != 0)
                                result += ((NamesOfZeroToNineteenNumbers)value).ToString() + whiteSpace + "Hundred" + whiteSpace;
                            else
                                counter--;
                            break;
                        case 1:
                            if (value == 1)
                                isNumberTen = true;
                            else
                                if (value != 0)
                                { 
                                    result += ((NamesOfTwentyToNinetyNineNumbers)value).ToString();
                                    separator = "-";
                                }
                            else
                                counter--;
                            break;
                        case 2:
                            if (isNumberTen)
                                result += ((NamesOfZeroToNineteenNumbers)(value + 10)).ToString() + whiteSpace;
                            else
                                if (value != 0)
                                    result += separator + ((NamesOfZeroToNineteenNumbers)value).ToString() + whiteSpace;
                            else
                                counter--;
                            break;
                        default:
                            break;
                    }
                }
                if (numberOfSubsets != 0)
                {
                    if (counter != 0)
                        result += ((NamesOfLargeNumbers)numberOfSubsets).ToString() + whiteSpace;
                    numberOfSubsets--;
                }
            }
            else
                result += ((NamesOfZeroToNineteenNumbers)value).ToString();

            return result;
        }
    }
}