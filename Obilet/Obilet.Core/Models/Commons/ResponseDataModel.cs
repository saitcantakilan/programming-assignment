using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Obilet.Core.Enums.CommonEnum;

namespace Obilet.Core.Models.Commons
{
    public class ResponseResultModel<T>
    {
        /// <summary>
        /// İşlemin sonucunu belirten enum değeri.
        /// </summary>
        public ResponseResultTypes ResponseDataType { get; set; }

        /// <summary>
        /// İşlemle ilgili bir mesajı içeren metin.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// İşlem sonucu olarak döndürülen veriyi içeren nesne.
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Hata durumunu ayarlar ve ResponseResultModel nesnesini döndürür.
        /// </summary>
        /// <param name="t">Sonuç verisi.</param>
        /// <param name="message">Hata mesajı.</param>
        /// <returns>Oluşturulan ResponseResultModel nesnesi.</returns>
        public ResponseResultModel<T> Error(T t, string message)
        {
            Message = message;
            ResponseDataType = ResponseResultTypes.Error;
            Result = t;
            return this;
        }

        /// <summary>
        /// Başarılı işlem durumunu ayarlar ve ResponseResultModel nesnesini döndürür.
        /// </summary>
        /// <param name="t">Sonuç verisi.</param>
        /// <returns>Oluşturulan ResponseResultModel nesnesi.</returns>
        public ResponseResultModel<T> Success(T t)
        {
            Message = ResponseResultTypes.Success.ToString();
            ResponseDataType = ResponseResultTypes.Success;
            Result = t;
            return this;
        }
    }
}
