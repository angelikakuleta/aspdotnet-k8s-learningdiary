﻿using Newtonsoft.Json;
using System.Net.Http;

namespace LearningDiary.WebUI.Extensions
{
    public static class HttpResponseExtensions
    {
        public static T ContentAsType<T>(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ?
                default(T) :
                JsonConvert.DeserializeObject<T>(data);
        }
    }
}
