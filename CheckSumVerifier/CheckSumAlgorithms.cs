using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CheckSumVerifier
{
    public static class CheckSumAlgorithms
    {
        public static readonly HashAlgorithm MD5 = new MD5CryptoServiceProvider();
        public static readonly HashAlgorithm SHA1 = new SHA1Managed();
        public static readonly HashAlgorithm SHA256 = new SHA256Managed();
        public static readonly HashAlgorithm SHA384 = new SHA384Managed();
        public static readonly HashAlgorithm SHA512 = new SHA512Managed();
        public static readonly HashAlgorithm RIPEMD160 = new RIPEMD160Managed();

        
        public static string GetChecksum(string filePath, string algorithmType)
        {
            string checksum = string.Empty;
            switch (algorithmType.Trim().ToUpper())
            {
                case "MD5":
                    using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
                    {
                        byte[] hash = MD5.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                case "SHA1":
                    using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
                    {
                        byte[] hash = SHA1.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                case "SHA256":
                    using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
                    {
                        byte[] hash = SHA256.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                case "SHA384":
                    using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
                    {
                        byte[] hash = SHA384.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                case "RIPEMD160":
                    using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
                    {
                        byte[] hash = RIPEMD160.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                default:
                     using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
                    {
                        byte[] hash = MD5.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
            }
            return checksum;

        }

        public static string GetChecksumFromString(string hashValue, string algorithmType)
        {
            string checksum = string.Empty;
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(hashValue);
            byte[] hash = null;
            switch (algorithmType.Trim().ToUpper())
            {
                case "MD5":

                    hash = MD5.ComputeHash(inputBytes);
               
                    break;
                case "SHA1":
                    hash = SHA1.ComputeHash(inputBytes);
               
                    break;
                case "SHA256":
                    hash = SHA256.ComputeHash(inputBytes);
                  
                    break;
                case "SHA384":
                    hash = SHA384.ComputeHash(inputBytes);
                  
                    break;
                case "RIPEMD160":
                    hash = RIPEMD160.ComputeHash(inputBytes);
                  
                    break;
                default:
                    hash = MD5.ComputeHash(inputBytes);
                 
                    break;
            }

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            checksum = sb.ToString();
            return checksum;

        }

        public static string GetChecksum(Stream fileStream, string algorithmType)
        {
            string checksum = string.Empty;
            switch (algorithmType.Trim().ToUpper())
            {
                case "MD5":
                    using (var stream = new BufferedStream(fileStream, 1200000))
                    {
                        byte[] hash = MD5.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                case "SHA1":
                    using (var stream = new BufferedStream(fileStream, 1200000))
                    {
                        byte[] hash = SHA1.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                case "SHA256":
                    using (var stream = new BufferedStream(fileStream, 1200000))
                    {
                        byte[] hash = SHA256.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                case "SHA384":
                    using (var stream = new BufferedStream(fileStream, 1200000))
                    {
                        byte[] hash = SHA384.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                case "RIPEMD160":
                    using (var stream = new BufferedStream(fileStream, 1200000))
                    {
                        byte[] hash = RIPEMD160.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
                default:
                    using (var stream = new BufferedStream(fileStream, 1200000))
                    {
                        byte[] hash = MD5.ComputeHash(stream);
                        checksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    break;
            }
            return checksum;

        }
    }


}
