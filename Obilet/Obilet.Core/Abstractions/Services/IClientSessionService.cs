using Obilet.Core.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Abstractions.Services
{
    public interface IClientSessionService
    {
        /// <summary>
        /// Ziyaretçi oturumunu alır. Eğer oturum çerezi varsa çerezden alır, yoksa tarayıcı ve bağlantı bilgilerini kullanarak bir oturum oluşturur.
        /// </summary>
        /// <returns>Oturum bilgilerini içeren bir ClientSessionModel nesnesi.</returns>
        Task<ClientSessionModel> GetSession();
    }
}
