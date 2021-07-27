using SBLibrary.Data.IDAO;
using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;

namespace SBLibrary.Data.DAO
{
    public class UserDAO : IUserDAO
    {
        private SBLibraryContext context;
        public UserDAO()
        {
            context = new SBLibraryContext();
        }

        //create user
        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUser(string email)
        {
            List<User> users = new List<User>();
            try
            {
                users = GetUsers().ToList();
                return users.FirstOrDefault(x => x.Email == email);
            }
            catch
            {
                throw;
            }
        }

          //call .Add and save to db
        public void CreateUsers(User user)
        {
                    try
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                    catch
                    {
                        throw;
                    }
                }

        public string ChangePassword(ChangePassword resetmodel)
        {

            User currectUser = GetUser(resetmodel.EmailID);
            if(currectUser != null && currectUser.Password == resetmodel.CurrentPassword)
            {
                currectUser.Password = resetmodel.NewPassword;
                currectUser.Confirmpwd = resetmodel.NewPassword;

                //var user = db.Users.Add(new User {UserID= currectUser.UserID, Email= currectUser.Email, Password= currectUser.Password,
                //FirstName=currectUser.FirstName, LastName= currectUser.LastName, Mobile= currectUser.Mobile
                //});
                //User user = context.Users.Add(currectUser);
                context.SaveChanges();

                context.Entry(currectUser).CurrentValues.SetValues(resetmodel);
                return "";
            }
            else
            {
                return "The Current Password did not match with the records..";
            }
            

            
            

            Console.WriteLine("done ... ");
        }

        public void ForgotPassword(string EmailID)
        {
            string resetCode = Guid.NewGuid().ToString();
           // var verifyUrl = "/Account/ResetPassword/" + resetCode;
           // var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            using (var context = new SBLibraryContext())
            {
                var getUser = (from s in context.Users where s.Email == EmailID select s).FirstOrDefault();
                if (getUser != null)
                {
                    getUser.ResetCode = resetCode;
                    getUser.Password = resetCode;

                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 

                    context.Configuration.ValidateOnSaveEnabled = false;

                    User user = context.Users.Add(getUser);

                    context.SaveChanges();

                    var subject = "Password Reset Request";

                    var body = "Hi " + getUser.FirstName + ", " +
                        "<br/>You recently requested a Temp password for your account by clicking on Forgot Password.<br/>" +
                        " <br/>Kindly Use the this Temp Password to login : " + resetCode +
                        "<br/> We request you to change the password post logging in with the Temp Password";

                    SendEmail(getUser.Email, body, subject);
                }
            }
        }


        private void SendEmail(string emailAddress, string body, string subject)
        {

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sblibrary47@gmail.com", "Reset@123")
            };
            using (var message = new MailMessage("sblibrary47@gmail.com", emailAddress)
            {
                Subject = subject,
                Body = body
            }
            )

            {
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
        }
    }
}
