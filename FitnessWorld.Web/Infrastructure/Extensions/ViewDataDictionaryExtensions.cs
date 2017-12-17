using FitnessWorld.Web.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FitnessWorld.Web.Infrastructure.Extensions
{
    public static class ViewDataDictionaryExtensions
    {
        public static void AddSearchMessage(this ViewDataDictionary viewData, string message)
        {
            viewData[WebConstants.ViewDataSearchMessageKey] = message;
        }
    }
}
