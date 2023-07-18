using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using NeDersinV2.API.HateoasModels;
using System.Reflection;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.API.Models;
using NeDersinV2.Returns.Concrete;
using System.Text;

namespace NeDersinV2.API.StaticMethods
{
    static public class StaticHelperMethods
    {
        static public Dictionary<string, string> GetPropertyDict(Type type)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (PropertyInfo item in type.GetProperties())
            {
                dict.Add(item.Name, item.PropertyType.ToString());
            }
            return dict;
        }

        /// <summary>
        /// Eğer modelstate isvalid doğru değilse attribute lerden hataları çekerek error döndürür
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ModelState"></param>
        /// <param name="hateoasModel"></param>
        /// <returns></returns>
        static public BadRequestObjectResult ReturnError<T>(ModelStateDictionary ModelState, HateoasModel hateoasModel)
        {
            string errorText = "";
            foreach (var key in ModelState.Keys)
            {
                errorText += ModelState[key]?.Errors.FirstOrDefault()?.ErrorMessage + "\n";
            }
            return new BadRequestObjectResult(new ActionReturnModel<T>(errorText, new ErrorReturnModel<T>(), hateoasModel));
        }


        /// <summary>
        /// IreturnType içini kontrol eder ve başarısız veya boş durumlara göre sonuçlar döner genel kontrol olduğu için çoğu yerde kullanılır ve işleri kolaylaştırır IReturnModel<IEnumerable<TSuccess>> veya IReturnModel<TSuccess>  şeklinde result alır.
        /// yalan yok biraz yama fonksiyonu oldu bu geliştirilirdi ama vakit kalmadı
        /// </summary>
        /// <typeparam name="TSuccess"> başarılı durumda hangi türde döneceğini söyleriz</typeparam>
        /// <typeparam name="TError"> başarısız durumda hangi tipte </typeparam>
        /// <param name="result">gelen IReturnModel tipi</param>
        /// <param name="hateoasModel">Hateoas Sınıfı</param>
        /// <returns></returns>
        static public IActionResult SolveResult<TSuccess, TError>(IReturnModel<TSuccess> result, HateoasModel hateoasModel, string message = "")
        {
            if (!result.Status)
            {
                return new BadRequestObjectResult(new ActionReturnModel<TError>
                    (
                        message + result.Message + result.Exception?.Message,
                        new ErrorReturnModel<TError>(),
                        hateoasModel
                    ));
            }
            return result.Data != null ?
                new OkObjectResult(new ActionReturnModel<TSuccess>
                (
                    message + result.Message,
                    result,
                    hateoasModel
                ))
            :
                new BadRequestObjectResult(new ActionReturnModel<TError>
                (
                    message + result.Message + result.Exception?.Message,
                    new ErrorReturnModel<TError>(),
                    hateoasModel
                ));
        }
        /// <summary>
        /// IreturnType içini kontrol eder ve başarısız veya boş durumlara göre sonuçlar döner genel kontrol olduğu için çoğu yerde kullanılır ve işleri kolaylaştırır IReturnModel<IEnumerable<TSuccess>> veya IReturnModel<TSuccess>  şeklinde result alır.
        /// yalan yok biraz yama fonksiyonu oldu bu geliştirilirdi ama vakit kalmadı
        /// </summary>
        /// <typeparam name="TSuccess"> başarılı durumda hangi türde döneceğini söyleriz</typeparam>
        /// <typeparam name="TError"> başarısız durumda hangi tipte </typeparam>
        /// <param name="result">gelen IReturnModel tipi</param>
        /// <param name="hateoasModel">Hateoas Sınıfı</param>
        /// <returns></returns>
        static public IActionResult SolveResult<TSuccess, TError>(IReturnModel<IEnumerable<TSuccess>> result, HateoasModel hateoasModel, string message = "")
        {
            if (!result.Status)
            {
                return new BadRequestObjectResult(new ActionReturnModel<TError>
                    (
                        message + result.Message + result.Exception?.Message,
                        new ErrorReturnModel<TError>(),
                        hateoasModel
                    ));
            }
            return result.Data != null ?
                new OkObjectResult(new ActionReturnModel<IEnumerable<TSuccess>>
                (
                    message + result.Message,
                    result,
                    hateoasModel
                ))
            :
                new BadRequestObjectResult(new ActionReturnModel<TError>
                (
                    message + result.Message + result.Exception?.Message,
                    new ErrorReturnModel<TError>(),
                    hateoasModel
                ));
        }
        /// <summary>
        /// IreturnType içini kontrol eder ve başarısız veya boş durumlara göre sonuçlar döner genel kontrol olduğu için çoğu yerde kullanılır ve işleri kolaylaştırır IReturnModel<IEnumerable<TSuccess>> veya IReturnModel<TSuccess>  şeklinde result alır.
        /// yalan yok biraz yama fonksiyonu oldu bu geliştirilirdi ama vakit kalmadı
        /// </summary>
        /// <typeparam name="TGeneral"> Hangi tipte işlem yapılacak</typeparam>
        /// <param name="result">gelen IReturnModel tipi</param>
        /// <param name="hateoasModel">Hateoas Sınıfı</param>
        /// <returns></returns>
        static public IActionResult SolveResult<TGeneral>(IReturnModel<TGeneral> result, HateoasModel hateoasModel, string message = "")
        {
            if (!result.Status)
            {
                return new BadRequestObjectResult(new ActionReturnModel<TGeneral>
                    (
                        message + result.Message + result.Exception?.Message,
                        new ErrorReturnModel<TGeneral>(),
                        hateoasModel
                    ));
            }
            return result.Data != null ?
                new OkObjectResult(new ActionReturnModel<TGeneral>
                (
                    message + result.Message,
                    result,
                    hateoasModel
                ))
            :
                new BadRequestObjectResult(new ActionReturnModel<TGeneral>
                (
                    message + result.Message + result.Exception?.Message,
                    new ErrorReturnModel<TGeneral>(),
                    hateoasModel
                ));
            }
        
        /// <summary>
        /// IreturnType içini kontrol eder ve başarısız veya boş durumlara göre sonuçlar döner genel kontrol olduğu için çoğu yerde kullanılır ve işleri kolaylaştırır IReturnModel<IEnumerable<TSuccess>> veya IReturnModel<TSuccess>  şeklinde result alır.
        /// yalan yok biraz yama fonksiyonu oldu bu geliştirilirdi ama vakit kalmadı
        /// </summary>
        /// <typeparam name="TGeneral"> Hangi tipte işlem yapılacak</typeparam>
        /// <param name="result">gelen IReturnModel tipi</param>
        /// <param name="hateoasModel">Hateoas Sınıfı</param>
        /// <returns></returns>
        static public IActionResult SolveResult<TGeneral>(IReturnModel<IEnumerable<TGeneral>> result, HateoasModel hateoasModel, string message = "")
        {
            if (!result.Status)
            {
                return new BadRequestObjectResult(new ActionReturnModel<TGeneral>
                    (
                        message + result.Message + result.Exception?.Message,
                        new ErrorReturnModel<TGeneral>(),
                        hateoasModel
                    ));
            }
            return result.Data != null ?
                new OkObjectResult(new ActionReturnModel<IEnumerable<TGeneral>>
                (
                    message + result.Message,
                    result,
                    hateoasModel
                ))
            :
                new BadRequestObjectResult(new ActionReturnModel<TGeneral>
                (
                    message + result.Message + result.Exception?.Message,
                    new ErrorReturnModel<TGeneral>(),
                    hateoasModel
                ));
        }


    }
}
