using System;
using System.Text;

public class RomanConversion {

    public static String GetRomanNumber(int indianNumber) 
    {
        StringBuilder sb = new StringBuilder ();
        if (indianNumber >= 100) {
            sb = ConvertThreeDigit(indianNumber, sb);
        } else if (indianNumber >= 10) {
            sb = ConvertTwoDigit(indianNumber, sb);
        } else {
            sb = ConvertOneDigit(indianNumber, sb);
        }
        return sb.ToString();
    }

    private static StringBuilder ConvertThreeDigit (int indianNumber, StringBuilder sb) 
    {
        if (indianNumber >= 500) {
            if (indianNumber >= 900) {
                sb.Append("CM");
            } else if (indianNumber >= 800) {
                sb.Append("DCCC");
            } else if (indianNumber >= 700) {
                sb.Append("DCC");
            } else if (indianNumber >= 600) {
                sb.Append("DC");
            } else {
                sb.Append("D");
            }
        } else {
            if (indianNumber >= 400) {
                sb.Append("CD");
            } else if (indianNumber >= 300) {
                sb.Append("CCC");
            } else if (indianNumber >= 200) {
                sb.Append("CC");
            } else {
                sb.Append("C");
            }
        }
        int lastDigits = indianNumber % 100;
        if (lastDigits == 0) {
            return sb;
        } else if (lastDigits > 0 && lastDigits < 10) {
            return ConvertOneDigit (lastDigits, sb);
        } else {
            return ConvertTwoDigit (lastDigits, sb);
        }
    }
    private static StringBuilder ConvertTwoDigit (int indianNumber, StringBuilder sb) 
    {
        if (indianNumber >= 50) {
            if (indianNumber >= 90) {
                sb.Append("XC");
            } else if (indianNumber >= 80) {
                sb.Append("LXXX");
            } else if (indianNumber >= 70) {
                sb.Append("LXX");
            } else if (indianNumber >= 60) {
                sb.Append("LX");
            } else {
                sb.Append("L");
            }
        } else {
            if (indianNumber >= 40) {
                sb.Append("XL");
            } else if (indianNumber >= 30) {
                sb.Append("XXX");
            } else if (indianNumber >= 20) {
                sb.Append("XX");
            } else {
                sb.Append("X");
            }
        }
        int lastDigit = indianNumber % 10;
        if (lastDigit == 0) {
            return sb;
        } else {
            return ConvertOneDigit(lastDigit, sb);
        }
    }

    private static StringBuilder ConvertOneDigit (int indianNumber, StringBuilder sb) 
    {
        if (indianNumber >= 5) {
            if (indianNumber == 9) {
                sb.Append("IX");
            } else if (indianNumber == 8) {
                sb.Append("VIII");
            } else if (indianNumber == 7) {
                sb.Append("VII");
            } else if (indianNumber == 6) {
                sb.Append("VI");
            } else {
                sb.Append("V");
            }
        } else {
            if (indianNumber == 4) {
                sb.Append("IV");
            } else if (indianNumber == 3) {
                sb.Append("III");
            } else if (indianNumber == 2) {
                sb.Append("II");
            } else {
                sb.Append("I");
            }
        }
        return sb;
    }

}