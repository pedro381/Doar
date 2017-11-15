
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Doar.Entity.Entities
{
    public class Usuario : BaseDominio
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "CPF:")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Data de Nascimento:")]
        public DateTime Nascimento { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirmar Email:")]
        [NotMapped]
        public string EmailConfirmacao { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha:")]
        [NotMapped]
        public string SenhaConfirmacao { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }
        [Display(Name = "Receber Informações no Email?")]
        public bool ReceberEmail { get; set; }
        [Display(Name = "É Usuário Administrador?")]
        public bool IsAdmin { get; set; }
        public Endereco Endereco { get; set; }
        public int? EnderecoId { get; set; }

        public List<Doacao> Doacoes { get; set; }

        public static string GenerateAPassKey(string passphrase)
        {
            var passPhrase = passphrase;
            var saltValue = passphrase;
            var hashAlgorithm = "SHA1";
            var passwordIterations = 2;
            var keySize = 256;
            var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            var pdb = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
#pragma warning disable 618
            var key = pdb.GetBytes(keySize / 11);
#pragma warning restore 618
            return Convert.ToBase64String(key);
        }
        public static string Encrypt(string plainStr)
        {
            if (string.IsNullOrEmpty(plainStr)) return null;
            var aesEncryption = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.ISO10126
            };
            var keyInBytes = Encoding.UTF8.GetBytes(GenerateAPassKey("doar"));
            aesEncryption.Key = keyInBytes;
            var plainText = Encoding.UTF8.GetBytes(plainStr);
            var crypto = aesEncryption.CreateEncryptor();
            var cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public static string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return null;
            var aesEncryption = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.ISO10126
            };
            var keyInBytes = Encoding.UTF8.GetBytes(GenerateAPassKey("doar"));
            aesEncryption.Key = keyInBytes;
            var decrypto = aesEncryption.CreateDecryptor();
            var encryptedBytes = Convert.FromBase64CharArray(encryptedText.ToCharArray(), 0, encryptedText.Length);
            return Encoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
        }

    }
}
