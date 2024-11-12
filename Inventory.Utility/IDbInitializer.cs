using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inventory.Utility
{
    public interface IDbInitializer
    {
        Task CreateSuperAdmin();
        Task SendMail(string FromEmail,string FromName,string Message, string toEmail, string toName,string subject, string smtpUser, string smtpPassword, string smptHost,string smtpPort,bool smtpSSL);
        Task<string> UploadFile(List<IFormFile> files,
            IWebHostEnvironment env, string Directory);
    }
}
