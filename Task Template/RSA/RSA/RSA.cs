
namespace RSA
{
    class RSA
    {
        public static BigInteger Encrypt(BigInteger E, BigInteger M, BigInteger N)
        {
            return BigInteger.ModOfPower(M, E, N);
        }

        public static BigInteger Decrypt(BigInteger EofM, BigInteger D, BigInteger N)
        {
            return BigInteger.ModOfPower(EofM, D, N);
        }

    }
}
