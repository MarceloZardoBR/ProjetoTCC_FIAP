using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CryptSharp;

namespace DotNetAppSqlDb.Business
{
    public class CriptografiaSenha
    {
        public static string Codifica(string senha)
        {
            return Crypter.MD5.Crypt(senha);
        }

        public static bool Compara(string senha, string hash)
        {
            return Crypter.CheckPassword(senha, hash);
        }
    }
}