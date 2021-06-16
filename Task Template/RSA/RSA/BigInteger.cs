using System;

namespace RSA
{
    class BigInteger:IComparable<BigInteger>,IEquatable<BigInteger>
    {

        //====================
        //Your Code is Here:
        //===================
        /// <summary>
        /// TODO: Write an efficient algorithm that multiplies 2 BigIntegers (A and B)
        /// </summary>
        /// <param name="A">first Operand, Non-Negative BigInteger</param>
        /// <param name="B">second Operand, Non-Negative BigInteger</param>
        /// <returns>BigInteger, The result of Multiplying A by B</returns>
        
        public static BigInteger Multiply(BigInteger A, BigInteger B)
        {
            
            if(A.Number.Length == 1 || B.Number.Length == 1)
                return A * B;
            
                //////////////// GET CUT INDEX////////////////////////////
                int cutInd = Math.Min(A.Number.Length, B.Number.Length);

            if (cutInd == 1)
                cutInd = 1;
            else if (cutInd % 2 == 0)
                cutInd = cutInd / 2;
            else
                cutInd = cutInd / 2 + 1;

            ///////////////////////Divide////////////////////////////
            string Atmp = A.Number.ToString();
            BigInteger a = new BigInteger(Atmp.Remove(Atmp.Length - cutInd));
            BigInteger b = new BigInteger(Atmp.Substring(Atmp.Length - cutInd));

            string Btmp = B.Number.ToString();
            BigInteger c = new BigInteger(Atmp.Remove(Atmp.Length - cutInd));
            BigInteger d = new BigInteger(Atmp.Substring(Atmp.Length - cutInd));

            BigInteger ac = Multiply(a, c);
            BigInteger bd = Multiply(b, d);
            BigInteger abcd = Multiply(Add(a,b), Add(c, d));

            ///////////////////////////Combine////////////////////////////


            BigInteger t1 = Subtract(Subtract(ac, abcd), bd);
            int pad = b.Number.Length + d.Number.Length;
            BigInteger t2 = PadWithZeros(t1, t1.Number.Length + (pad / 2));
            BigInteger t3 = PadWithZeros(ac, ac.Number.Length + pad);
            BigInteger final = Add(Add(t2, t3), bd);


            return final;
        }

        //====================
        //Your Code is Here:
        //===================
        /// <summary>
        /// TODO: Write an efficient algorithm that calculates div-mod
        /// The function should calculates the quotient (A / B) and the remainder (A mod B)
        /// </summary>
        /// <param name="A">the dividend, non-negative BigInteger</param>
        /// <param name="B">the divisor, Positive BigInteger</param>
        /// <returns> 
        /// A Tuple (pair of BigIntegers)
        /// The first Item is the quotient (A / B)
        /// The second Item is the remainder (A mod B)
        /// </returns>
        public static Tuple<BigInteger, BigInteger> DivMod(BigInteger A, BigInteger B)
        {
            throw new NotImplementedException();          
        }

        //====================
        //Your Code is Here:
        //===================
        /// <summary>
        /// TODO: Write an efficient algorithm that calculates Mod of Power
        /// The function should calculates the result of the equation (B ^ P) mod M
        /// </summary>
        /// <param name="B">the base, non-negative BigInteger</param>
        /// <param name="P">the exponent, non-negative BigInteger</param>
        /// <param name="M">the modulus value, positive BigInteger</param>
        /// <returns>BigInteger, The result of (B ^ P) mod M</returns>
        public static BigInteger ModOfPower(BigInteger B, BigInteger P, BigInteger M)
        {
            throw new NotImplementedException();
        }

        
        
        #region "Constructors"
        /// <summary>
        /// Default Constructor
        /// Creates A BigInteger that has the value of zero
        /// </summary>
        public BigInteger()
        {
            Sign = false;
            Number = new byte[1] { 0 };
        }
        /// <summary>
        /// Creates a BigInteger from a sumeric string
        /// </summary>
        /// <param name="number">Numeric string</param>
        public BigInteger(string number)
        {
            while (number[0] == '0' && number.Length != 1)
                number = number.Remove(0, 1);

            if (char.IsDigit(number[0]))
            {
                Number_setter(number);
                Sign = false;
            }
            else
            {
                if (number[0] == '-')
                {
                    Sign = true;
                    Number_setter(number.Substring(1));
                }
                else if (number[0] == '+')
                {
                    Sign = false;
                    Number_setter(number.Substring(1));
                }
                else
                {
                    Sign = false;
                    Number_setter(number);
                }
            }
        }
        /// <summary>
        /// Creates a BigInteger from a numeric String and a Sign
        /// </summary>
        /// <param name="number">Numeric string</param>
        /// <param name="sign">Boolean variable for the sign
        /// (sign = true for negatives, sign = false for positives)</param>
        public BigInteger(string number, bool sign)
        {
            while (number[0] == '0' && number.Length != 1)
                number = number.Remove(0, 1);
            Number_setter(number);
            Sign_setter(sign);
        }
        /// <summary>
        /// Creates a BigInteger form a byte array
        /// Each element in the array represents a digit in the number
        /// </summary>
        /// <param name="arr">byte array. Each digit represents a digit of the big number</param>
        public BigInteger(byte[] arr)
        {
            this.Number = arr;
        }
        /// <summary>
        /// Creates a BigInteger from a byte array and a sign
        /// Each element in the array represents a digit in the number
        /// </summary>
        /// <param name="number">byte array. Each digit represents a digit of the big number</param>
        /// <param name="sign">Boolean variable for the sign
        /// (sign = true for negatives, sign = false for positives)</param>
        public BigInteger(byte[] number, bool sign)
        {
            this.Number = number;
            this.Sign = sign;
        }
        /// <summary>
        /// Creates a BigInteger from a variable with long data type
        /// </summary>
        /// <param name="number">the number whose value will be in the big number</param>
        public BigInteger(long number)
        {
            if (number < 0)
                Sign = true;
            else
                Sign = false;

            String s;
            s = number.ToString();

            Number_setter(s);
        }
        #endregion

        public void Number_setter(string number)
        {
            if (number[0] == '-')
            {
                Sign_setter(true);
                Number = System.Text.Encoding.UTF8.GetBytes(number.Substring(1));
            }
            else
                Number = System.Text.Encoding.UTF8.GetBytes(number);
        }
        public void Sign_setter(bool sign)
        {
            Sign = sign;
        }
        public string Number_getter()
        {
            return System.Text.Encoding.UTF8.GetString(Number);
        }
        public bool Sign_getter()
        {
            return Sign;
        }
        public int GetDigitsCount()
        {
            Number = RemoveLeadingZeros(new BigInteger(Number)).Number;
            return Number.Length;
        }
        

        #region "Privates"

        private bool Sign;
        private byte[] Number;

        public byte[] Number1 { get => Number; set => Number = value; }
        #endregion

        /// <summary>
        /// Add two positive BigIntegers and returns the result
        /// </summary>
        /// <param name="A">Big Integer (should be positive)</param>
        /// <param name="B">Big Integer (should be positive)</param>
        /// <returns>Big Integer (the result of adding A and B)</returns>
        public static BigInteger Add(BigInteger A, BigInteger B)
        {
            A = RemoveLeadingZeros(A);
            B = RemoveLeadingZeros(B);
            if (B.Number.Length > A.Number.Length)
            {
                byte[] tmp = A.Number;
                A.Number = B.Number;
                B.Number = tmp;
            }

            byte[] sum = new byte[A.Number.Length];

            byte carry = 0;


            int cntr = A.Number.Length - 1;
            for (int i = B.Number.Length - 1; i >= 0; i--)
            {
                byte tmp = (byte)(A.Number[cntr] + B.Number[i] + carry);
                if (tmp > 9)
                {
                    tmp -= 10;
                    carry = 1;
                }
                else
                    carry = 0;

                sum[cntr] = tmp;
                cntr--;
            }

            while (carry == 1)
            {
                if (cntr == -1)
                {
                    byte[] extendedSum = new byte[sum.Length + 1];
                    extendedSum[0] = 1;
                    for (int i = 1; i <= sum.Length; i++)
                    {
                        extendedSum[i] = sum[i - 1];
                    }
                    return new BigInteger(extendedSum);
                }


                byte tmp = (byte)(sum[cntr] + 1);
                if (tmp > 9)
                {
                    tmp -= 10;
                    carry = 1;
                }
                else
                    carry = 0;

                sum[cntr] = tmp;
                cntr--;
            }


            return new BigInteger(sum);

        }

        /// <summary>
        /// Subtracts B from A, A and B are positive BigIntegers
        /// </summary>
        /// <param name="A">First Operand</param>
        /// <param name="B">Second Operand</param>
        /// <returns>Subtraction Result as a BigInteger (It may be negative)</returns>
        public static BigInteger Subtract(BigInteger A, BigInteger B)
        {

            bool swap = false;
            A = RemoveLeadingZeros(A);
            B = RemoveLeadingZeros(B);
            if (A.CompareTo(B) < 0)
            {
                BigInteger tmp = A;
                A = B;
                B = tmp;
                swap = true;
            }
            else if (A.CompareTo(B) == 0)
            {
                return new BigInteger();
            }

            if (A.Number.Length > B.Number.Length)
            {
                B = PadWithZeros(B, A.Number.Length - B.Number.Length);
            }
            else
            {
                A = PadWithZeros(A, B.Number.Length - A.Number.Length);
            }

            BigInteger res = new BigInteger(A.Number);


            for (int i = A.Number.Length - 1; i >= 0; i--)
            {
                if (A.Number[i] < B.Number[i])
                {
                    byte tmp = (byte)(A.Number[i] + 10);

                    byte tmp3 = (byte)(tmp - B.Number[i]);
                    res.Number[i] = tmp3;

                    byte tmp2 = (byte)(A.Number[i - 1] - 1);
                    A.Number[i - 1] = tmp2;
                }
                else
                {
                    res.Number[i] = (byte)(A.Number[i] - B.Number[i]);
                }
            }

            res = RemoveLeadingZeros(res);

            if (swap)
                res.Sign = true;


            return res;
        }
        #region "Operators"
        public static BigInteger operator -(BigInteger A, BigInteger B)
        {
            BigInteger result = Subtract(A, B);
            return result;
        }
        public static BigInteger operator +(BigInteger A, BigInteger B)
        {
            return Add(A, B);
        }
        public static BigInteger operator *(BigInteger A, BigInteger B)
        {
            return Multiply(A, B);
        }
        #endregion

        
        /// <summary>
        /// Calculates the parity of the big integer (is it odd or even?)
        /// </summary>
        /// <param name="bigInteger">the big integer</param>
        /// <returns>
        /// true if the integer is even.
        /// false if the integer is odd.
        /// </returns>
        public static bool Is_Even(BigInteger bigInteger)
        {
            return bigInteger.Number[bigInteger.Number.Length - 1] % 2 == 0;
        }

        /// <summary>
        /// Check if the big integer equals zero or not
        /// </summary>
        /// <param name="bigInteger">a big integer</param>
        /// <returns>
        /// true if the big integer is zero
        /// false otherwise
        /// </returns>
        public static bool Is_Zero(BigInteger bigInteger)
        {
            for(int i = 0; i < bigInteger.Number.Length; i++)
            {
                if(bigInteger.Number[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void Display_Biginteger()
        {
            if (Sign_getter())
                Console.Write('-');
            Console.WriteLine(Number_getter());
        }

        /// <summary>
        /// pad the big integer with zeros (to the right)
        /// for example: if A = 29398, numberOfZeros = 5
        /// the funciton should return : 2939800000
        /// </summary>
        /// <param name="A">big integer</param>
        /// <param name="numberOfZeros">the number of zeros to pad</param>
        /// <returns>the big integer after padding it with zeros</returns>
        public static BigInteger PadWithZeros(BigInteger A, int numberOfZeros)
        {
            byte[] arr = new byte[A.Number.Length + numberOfZeros];
            for (int i = 0; i < arr.Length; i++)
            {
                if(i < A.Number.Length)
                {
                    arr[i] = A.Number[i];
                }
                else
                {
                    arr[i] = 0;
                }
            }

            return new BigInteger(arr);
        }

        /// <summary>
        /// add trailing zeros to the big integer (to the left)
        /// for example: if A = 29398, numberOfZeros = 5
        /// the funciton should return a big integer with the value: 0000029398
        /// </summary>
        /// <param name="A">big integer</param>
        /// <param name="numberOfZeros">the number of zeros to add</param>
        /// <returns>the big integer after adding trailing zeros</returns>
        public static BigInteger AddLeadingZeros(BigInteger A, int numberOfZeros)
        {
            byte[] arr = new byte[A.Number.Length + numberOfZeros];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < numberOfZeros)
                {
                    arr[i] = 0;
                }
                else
                {
                    arr[i] = A.Number[i - numberOfZeros];
                }
            }

            return new BigInteger(arr);
        }

        /// <summary>
        /// remove trailing zeros from the big integer
        /// for example: if A = 0000293
        /// the funciton should return 293
        /// </summary>
        /// <param name="A">a big integer, to remove the trailing zeros from</param>
        /// <returns>the number after removing trailing zeros</returns>
        public static BigInteger RemoveLeadingZeros(BigInteger A)
        {
            BigInteger res;
            int firstNonZeroIndex = -1;
            for (int i = 0; i < A.Number.Length; i++)
            {
                if (A.Number[i] != 0)
                {
                    firstNonZeroIndex = i;
                    break;
                }
            }

            if (firstNonZeroIndex == -1) // the number is zero
            {
                res = new BigInteger();
            }
            else
            {
                byte[] arr = new byte[A.Number.Length - firstNonZeroIndex];
                for (int i = firstNonZeroIndex; i < A.Number.Length; i++)
                {
                    arr[i - firstNonZeroIndex] = A.Number[i];
                }
                res = new BigInteger(arr);
            }

            return res;
        }

        public int CompareTo(BigInteger other)
        {
            BigInteger A = RemoveLeadingZeros(this);
            this.Number = A.Number;
            other = RemoveLeadingZeros(other);
            if (other.Sign == true && this.Sign == true)
            {
                if (this.Number.Length < other.Number.Length)
                {
                    return 1;
                }
                else if (this.Number.Length > other.Number.Length)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < this.Number.Length; i++)
                    {
                        if (this.Number[i] < other.Number[i])
                        {
                            return 1;
                        }
                        else if (this.Number[i] > other.Number[i])
                        {
                            return -1;
                        }
                    }

                    return 0;
                }
            }
            else if (other.Sign == true && this.Sign == false)
            {
                return 1;
            }
            else if (other.Sign == false && this.Sign == true)
            {
                return -1;
            }
            else // both are false (positive)
            {
                if(this.Number.Length < other.Number.Length)
                {
                    return -1;
                }
                else if(this.Number.Length > other.Number.Length)
                {
                    return 1;
                }
                else
                {
                    for(int i = 0; i < this.Number.Length; i++)
                    {
                        if(this.Number[i] < other.Number[i])
                        {
                            return -1;
                        }
                        else if (this.Number[i] > other.Number[i])
                        {
                            return 1;
                        }
                    }

                    return 0;
                }
            }
        }

        public bool Equals(BigInteger other)
        {
            Number = RemoveLeadingZeros(new BigInteger(Number)).Number;
            other = RemoveLeadingZeros(other);
            if(Sign != other.Sign || other.Number.Length != Number.Length)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < Number.Length; i++)
                {
                    if(Number[i] != other.Number[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
