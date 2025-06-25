using Microsoft.EntityFrameworkCore;
using QuickBite.Services.EmailAPI.Data;
using QuickBite.Services.EmailAPI.Message;
using QuickBite.Services.EmailAPI.Models;
using QuickBite.Services.EmailAPI.Models.DTO;
using QuickBite.Services.EmailAPI.Services.IServices;
using System;
using System.Text;

namespace QuickBite.Services.EmailAPI.Services
{
    public class EmailService: IEmailService
    {
        /*Strange way to add dbcontext? Explaination in Program.cs(16-20)*/
        private DbContextOptions<EmailDBContext> _dbOptions;

        public EmailService(DbContextOptions<EmailDBContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task EmailCartAndLog(CartDTO cartDTO)
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("<br/>Cart Email Requested ");
            message.AppendLine("<br/>Total " + cartDTO.CartHeader.CartTotal);
            message.Append("<br/>");
            message.Append("<ul>");
            foreach (var item in cartDTO.CartDetails)
            {
                message.Append("<li>");
                message.Append(item.Product.Name + " x " + item.Count);
                message.Append("</li>");
            }
            message.Append("</ul>");

            await LogAndEmail(message.ToString(), cartDTO.CartHeader.Email);
        }

        public async Task LogOrderPlaced(RewardsMessage rewardsDTO)
        {
            string message = "New Order Placed. <br/> Order ID : " + rewardsDTO.OrderId;
            await LogAndEmail(message, "quickbiteadmin@gmail.com");
        }

        public async Task RegisterUserEmailAndLog(string email)
        {
            string message = "User Registeration Successful. <br/> Email : " + email;
            await LogAndEmail(message, "quickbiteadmin@gmail.com");
        }

        private async Task<bool> LogAndEmail(string message, string email)
        {
            try
            {
                EmailLogger emailLog = new()
                {
                    Email = email,
                    EmailSent = DateTime.Now,
                    Message = message
                };
                await using var _db = new EmailDBContext(_dbOptions);
                await _db.EmailLoggers.AddAsync(emailLog);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
