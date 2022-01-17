using NETCore.Encrypt;
using NETCore.Encrypt.Internal;

namespace API.Helpers
{
    public class Security
    {

        private static AESKey _aesKey = EncryptProvider.CreateAesKey();

        private readonly string Key = "QWRAetyuis230mjklpoghytrfvbcdazx";
        private readonly string Iv = "l8RlU1MTgnp9vapv";
       

        public string Encriptar(string pass)
        {
            return EncryptProvider.AESEncrypt(pass, Key,Iv);
        }


        public string Desencriptar(string pass)
        {
            return EncryptProvider.AESDecrypt(pass, Key, Iv);
        }


    }
}
