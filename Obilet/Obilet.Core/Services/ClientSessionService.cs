using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Obilet.Core.Abstractions.Services;
using Obilet.Core.Models;
using Obilet.Core.Models.Commons;
using Obilet.Core.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace Obilet.Core.Services
{
    public class ClientSessionService : IClientSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IObiletService _obiletService;
        private readonly IOptions<AppOptions> _appOptions;
        private readonly ICookieService _cookieService;

        public ClientSessionService(IHttpContextAccessor httpContextAccessor, IObiletService obiletService, IOptions<AppOptions> appOptions, ICookieService cookieService)
        {
            _httpContextAccessor = httpContextAccessor;
            _obiletService = obiletService;
            _appOptions = appOptions;
            _cookieService = cookieService;
        }

        public async Task<ClientSessionModel> GetSession()
        {
            // Ziyaretçi oturumu için önce çerezleri kontrol et oturumu çerezde varsa çerezden al ve geri dön
            var clientSessionCookie = _cookieService.Get<ClientSessionModel>(typeof(ClientSessionModel).Name);
            if (clientSessionCookie != null)
                return clientSessionCookie;

            // Ziyaretçi oturumu çerezde yoksa, tarayıcı bilgilerini al
            var userAgentHeader = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
            var userAgentParser = Parser.GetDefault();
            ClientInfo clientInfo = userAgentParser.Parse(userAgentHeader);

            // Tarayıcı bilgilerini oluştur
            var browserInfo = new SessionBrowserModel
            {
                Name = clientInfo.UA.Family,
                Version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}"
            };

            // Bağlantı bilgilerini oluştur
            var connectionInfo = new SessionConnectionModel
            {
                IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                Port = _httpContextAccessor.HttpContext.Connection.RemotePort.ToString()
            };

            // Oturum isteği modelini oluştur
            var sessionRequestModel = new SessionRequestModel
            {
                Browser = browserInfo,
                Connection = connectionInfo,
                Type = 1
            };

            // Oturum isteğini servise gönder ve cevabı al
            var sessionResponseModel = await _obiletService.GetSessionAsync(sessionRequestModel);

            // Oturum modeli başarıyla döndüyse, çerez olarak sakla
            if (sessionResponseModel.ClientSession != null)
            {
                _cookieService.Set(typeof(ClientSessionModel).Name, sessionResponseModel.ClientSession, DateTime.Now.AddMinutes(30));
            }

            // Son olarak oturum modelini döndür
            return sessionResponseModel.ClientSession;
        }
    }
}
