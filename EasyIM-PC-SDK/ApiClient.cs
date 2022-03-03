﻿using EasyIM_PC_SDK.Api;
using EasyIM_PC_SDK.Result;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EasyIM_PC_SDK
{
    /*
     * ========================================================================
     * Copyright Notice  2010-2022 Helloes All rights reserved .
     * ========================================================================
     * 机器名称：DESKTOP-KBNKUO5 
     * 文件名：  ApiClient 
     * 版本号：  V1.0.0.0 
     * 创建人：  kools 
     * 创建时间：2022/3/3 13:48:21 
     * 描述    :
     * =====================================================================
     * 修改时间：2022/3/3 13:48:21 
     * 修改人  ：kools
     * 版本号  ：V1.0.0.0 
     * 描述    ：
	*/
    public class ApiClient
    {
        public string Token { get; set; }
        public string AccessKeyId { get; set; }

        public ApiClient(string accessKeyId) 
        {
            AccessKeyId = accessKeyId;
        }

        public string Execute(string url, string jsonStr) 
        {
            if (Token == null)
            {
                Token=new AuthenticationApi().GetToken(AccessKeyId);
            }
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("token", Token);
            HttpContent httpContent = new StringContent(jsonStr);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = httpClient.PostAsync(new Uri(url), httpContent).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}