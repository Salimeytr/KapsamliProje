using KapsamliProje.Dal;
using KapsamliProje.Dto;
using KapsamliProje.Ent;
using KapsamliProje.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KapsamliProje.Repos.Concrete
{
    public class AuthRepos : IAuthRepos //implement ediyoruz
    {

        Users _users;
        Context _db;
        public AuthRepos(Users users, Context db)
        {

            _users = users;
            _db = db;
        }
        public void Register(string UserName, string Password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(Password, out passwordHash, out passwordSalt);
            _users.UserId = UserName;
            _users.PasswordHash = passwordHash;
            _users.PasswordSalt = passwordSalt;
            _users.Role = "User";
            _db.Add(_users); //kaydetme kodları
            _db.SaveChanges();

        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //out koyarsak girilen bilgiler kaybolmaz
        {
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public Users Login(string UserName, string Password)
        {
            //  throw new NotImplementedException();
            Users? user = _db.Set<Users>().Find(UserName);
            if (user == null)
            {
                return null;
            }
            else
            {
                if (!VerifyPassWord(Password, user.PasswordHash,
                    user.PasswordSalt))
                {
                    return null;
                }
                else
                {
                    return user;
                    //string SessionKeyName = "User";/*//Name altında the doctor diye değer saklıyor _age altında ise 73 dye değer saklıyor.*/

                    //HttpContext.Session.SetString(SessionKeyName, user.UserId);
                    ////string ve int olarak döndürebilmek için böyle değerler tanımlıyoruz.

                    //return RedirectToAction("Index", "Home");
                }

            }

        }
        private bool VerifyPassWord(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            var hmac = new HMACSHA512(userPasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userPasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }

       
    }

}
