using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SimpleElGamalDS
{
    public struct ElGamalKeyStruct
    {
        public BigInteger P;
        public BigInteger G;
        public BigInteger Y;
        public BigInteger X;
    }

    public abstract class ElGamal : AsymmetricAlgorithm
    {
        public override void FromXmlString(string xmlString)
        {
            throw new NotImplementedException();
        }

        public override string KeyExchangeAlgorithm
        {
            get { throw new NotImplementedException(); }
        }

        public override string SignatureAlgorithm
        {
            get { throw new NotImplementedException(); }
        }

        public override string ToXmlString(bool includePrivateParameters)
        {
            throw new NotImplementedException();
        }
    }

    public class ElGamalManaged : ElGamal
    {
        private ElGamalKeyStruct keyStruct;

        public ElGamalManaged() 
        {
            // create the key struct
            keyStruct = new ElGamalKeyStruct();
            // set all of the big integers to zero
            keyStruct.P = new BigInteger(0);
            keyStruct.G = new BigInteger(0);
            keyStruct.Y = new BigInteger(0);
            keyStruct.X = new BigInteger(0);
            // set the default key size value
            KeySizeValue = 512;
            // set the range of legal keys
            LegalKeySizesValue = new KeySizes[] { new KeySizes(384, 1088, 8) };
        }

        private bool NeedToGenerateKey()
        {
            return keyStruct.P == 0 && keyStruct.G == 0 && keyStruct.Y == 0;
        }
        public ElGamalKeyStruct KeyStruct
        {
            get
            {
                if (NeedToGenerateKey())
                {
                    CreateKeyPair(KeySizeValue);
                }
                return keyStruct;
            }
            set
            {
                keyStruct = value;
            }
        }

        private void CreateKeyPair(int keyStrenght)
        {
            // create the random number generator
            Random random = new Random();

            // create the large prime number, P
            keyStruct.P = BigInteger.genPseudoPrime(keyStrenght, 16, random);

            // create the two random numbers, which are smaller than P

            if (keyStruct.X == 0)
            {
                keyStruct.X = new BigInteger();
                keyStruct.X.genRandomBits(keyStrenght - 1, random);
            }

            keyStruct.G = new BigInteger();
            keyStruct.G.genRandomBits(keyStrenght - 1, random);

            // compute Y
            keyStruct.Y = keyStruct.G.modPow(keyStruct.X, keyStruct.P);
        }

        public byte[] Sign(byte[] hashCode)
        {
            if (NeedToGenerateKey())
            {
                CreateKeyPair(KeySizeValue);
            }
            return ElGamalSignature.CreateSignature(hashCode, keyStruct);
        }

        public  bool VerifySignature(byte[] hashCode, byte[] signature)
        {
            if (NeedToGenerateKey())
            {
                CreateKeyPair(KeySizeValue);
            }
            return ElGamalSignature.VerifySignature(hashCode, signature, keyStruct);
        }
    }


    class ElGamalSignature
    {
        public static BigInteger mod(BigInteger pBase, BigInteger pVal)
        {
            BigInteger result = pBase % pVal;
            if (result < 0)
            {
                result += pVal;
            }
            return result;
        }

        public static byte[] CreateSignature(byte[] data,   ElGamalKeyStruct keyStruct) 
        {
            // define P -1
            BigInteger minusOne = keyStruct.P - 1;
            // create K, which is the random number        
            BigInteger K;          
            do 
            {
                K = new BigInteger();
                K.genRandomBits(keyStruct.P.bitCount() -1, new Random());
            } 
            while (K.gcd(minusOne) != 1);

            // compute the values A and B
            BigInteger A = keyStruct.G.modPow(K, keyStruct.P);

            var p1 = K.modInverse(minusOne);

            var a1 = new BigInteger(data);
            var a2 = keyStruct.X * A;
            var p2 = a1 - a2;
            var t1 = p1 * p2;
            var t2 = mod(t1, minusOne);

            BigInteger B = mod(t2, minusOne);
            // copy the bytes from A and B into the result array
            byte[] aBytes = A.getBytes();
            byte[] bBytes = B.getBytes();
            // define the result size
            int resultSize = (((keyStruct.P.bitCount() + 7) / 8) * 2);
            // create an array to contain the ciphertext
            byte[] result = new byte[resultSize];
            // populate the arrays
            Array.Copy(aBytes, 0, result, resultSize / 2 - aBytes.Length, aBytes.Length);        
            Array.Copy(bBytes, 0, result, resultSize - bBytes.Length, bBytes.Length);

            // return the result array
            return result;
        }

         public static bool VerifySignature(byte[] data, byte[] signature,ElGamalKeyStruct keyStruct) 
         {
                  // define the result size
            int resultSize = signature.Length/2;

            // extract the byte arrays that represent A and B
            byte[] aBytes = new byte[resultSize];
            Array.Copy(signature, 0, aBytes, 0, aBytes.Length);
            byte[] bBytes = new Byte[resultSize];
            Array.Copy(signature, resultSize, bBytes, 0, bBytes.Length);

            // create big integers from the byte arrays
            BigInteger A = new BigInteger(aBytes);
            BigInteger B = new BigInteger(bBytes);
            // create the two results
            BigInteger result1 =  mod(keyStruct.Y.modPow(A, keyStruct.P) * A.modPow(B, keyStruct.P), keyStruct.P);

            BigInteger result2 =  keyStruct.G.modPow(new BigInteger(data), keyStruct.P);

            // return true if the two results are the same

            return result1 == result2;
        }


    }

    public class ElGamalSignatureFormatHelper
    {
        private static byte[] MD5_BYTES
               = new byte[] {0x30, 0x20, 0x30, 0x0C, 0x06, 0x08, 0x2A, 0x86,
                                     0x48, 0x86, 0xF7, 0x0D, 0x02, 0x05, 0x05, 0x00,
                                     0x04, 0x10};

        private static byte[] SHA1_BYTES
            = new byte[] {0x30, 0x21, 0x30, 0x09, 0x06, 0x05, 0x2b, 0x0E, 0x03, 
                                     0x02, 0x1A, 0x05, 0x00, 0x04, 0x14};

        private static byte[] SHA256_BYTES
            = new byte[] {0x30, 0x31, 0x30, 0x0d, 0x06, 0x09, 0x60, 0x86,
                                     0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x01, 0x05,
                                     0x00, 0x04, 0x20};

        private static byte[] SHA384_BYTES
            = new byte[] {0x30, 0x41, 0x30, 0x0d, 0x06, 0x09, 0x60, 0x86,
                                     0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x02, 0x05,
                                     0x00, 0x04, 0x30};

        private static byte[] SHA512_BYTES
            = new byte[] {0x30, 0x51, 0x30, 0x0d, 0x06, 0x09, 0x60, 0x86,
                                     0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x03, 0x05,
                                     0x00, 0x04, 0x40};

        private static byte[] GetHashAlgorithmID(HashAlgorithm hash)
        {
            if (hash is MD5)
            {
                return MD5_BYTES;
            }
            else if (hash is SHA1)
            {
                return SHA1_BYTES;
            }
            else if (hash is SHA256)
            {
                return SHA256_BYTES;
            }
            else if (hash is SHA384)
            {
                return SHA384_BYTES;
            }
            else if (hash is SHA512)
            {
                return SHA512_BYTES;
            }
            else
            {
                throw new ArgumentException("Unknown hashing algorithm", "p_hash");
            }
        }

        public static byte[] CreateEMSA_PKCS1_v1_5_ENCODE(byte[] hashCode, HashAlgorithm hashAlg, int keyLenght)
        {

            //  Concatenate the algorithm ID for the hash algorithm 
            // and the hash code to form T
            byte[] algoritmId = GetHashAlgorithmID(hashAlg);
            byte[] T = new byte[hashCode.Length + algoritmId.Length];
            Array.Copy(algoritmId, 0, T, 0, algoritmId.Length);
            Array.Copy(hashCode, 0, T, algoritmId.Length, hashCode.Length);

            // Generate an octet string PS consisting of p_key_length - T.Length - 
            // 3 octets with hexadecimal value 0xff. 
            // The length of PS will be at least 8 octets.
            int PSLenght = keyLenght - T.Length - 3;
            byte[] PS = new byte[PSLenght < 0 ? 8 : PSLenght];
            for (int i = 0; i < PS.Length; i++)
            {
                PS[i] = 0xFF;
            }
            // Concatenate PS, the DER encoding T, and other padding to form the 
            // encoded message EM as EM = 0x00 || 0x01 || PS || 0x00 || T .
            byte[] EM = new byte[3 + PS.Length + T.Length];
            EM[0] = 0x00;
            EM[1] = 0x01;
            Array.Copy(PS, 0, EM, 2, PS.Length);
            EM[PS.Length + 2] = 0x00;
            Array.Copy(T, 0, EM, PS.Length + 3, T.Length);
            // Output EM.
            return EM;

        }

    }

    public class ElGamalPKCS1SignatureFormatter : AsymmetricSignatureFormatter
    {
        private string hashName;    // the hash algorithm to use
        private ElGamalManaged key;          // the ElGamal algorithm

        public override void SetHashAlgorithm(string name)
        {
            hashName = name;
        }

        public override void SetKey(AsymmetricAlgorithm _key)
        {
            if (_key is ElGamalManaged)
                key = _key as ElGamalManaged;
            else
                throw new ArgumentException("Key is not an instance of ElGamalManaged", "key");
        }

        public override byte[] CreateSignature(byte[] data)
        {
            if (hashName == null || key == null)
                throw new CryptographicException("Key and Hash Algorithm must be set");
            else
            {
                // create the hashing algorithm
                HashAlgorithm hashAlg = HashAlgorithm.Create(hashName);
                // create a PKCS1 formatted block from the data
                byte[] pkcs1 = ElGamalSignatureFormatHelper.CreateEMSA_PKCS1_v1_5_ENCODE(data, hashAlg, key.KeyStruct.P.bitCount());
                // create and return the signature
                return key.Sign(pkcs1);
            }
        }
    }

    public class ElGamalPKCS1SignatureDeformatter : AsymmetricSignatureDeformatter
    {
        private string               hashName;    // the hash algorithm to use
        private ElGamalManaged       key;          // the ElGamal algorithm

        public override void SetHashAlgorithm(string name) 
        {
            hashName = name;
        }

        public override void SetKey(AsymmetricAlgorithm _key) 
        {
            if (_key is ElGamalManaged)
                key = _key as ElGamalManaged;
            else 
                throw new ArgumentException("Key is not an instance of ElGamalManaged", "key");
        }

        public override bool VerifySignature(byte[] data, byte[] signature) 
        {
            if (hashName == null || key == null) 
                throw new CryptographicException("Key and Hash Algorithm must be set");
            else 
            {
                // create the hashing algorithm
                HashAlgorithm hashAlg = HashAlgorithm.Create(hashName);
                // create a PKCS1 formatted block from the data
                byte[] pkcs = ElGamalSignatureFormatHelper.CreateEMSA_PKCS1_v1_5_ENCODE( data, hashAlg, key.KeyStruct.P.bitCount(  ));

                // create and return the signature
                return key.VerifySignature(pkcs, signature);
            }
        }
    }
}

