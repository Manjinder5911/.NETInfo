// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography;

public class Program
{
    public static string HashPassword(string password, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes for SHA256
            Console.WriteLine(Convert.ToBase64String(hash));
            return Convert.ToBase64String(hash);
        }
    }

    public static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16]; // 128 bits
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }
        //returning string for generated salt
        return Convert.ToBase64String(saltBytes);
    }
    
    static void Main(string[] args)
    {
        // Generate a salt
        string salt = Program.GenerateSalt();
        Console.WriteLine("Generated Salt: " + salt);

        // Define a password
        string password = "MySecurePassword";

        // Hash the password using the generated salt
        string hashedPassword = Program.HashPassword(password, salt);
        Console.WriteLine("Hashed Password: " + hashedPassword);

      
    }
}



