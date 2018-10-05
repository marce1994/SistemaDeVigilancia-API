using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;
namespace SistemaDeVigilancia.Service
{
    public class TelegramService
    {
        TelegramConfiguration configuration;
        ILogger logger;
        
        public TelegramService(IOptions<TelegramConfiguration> configuration, ILogger logger)
        {
            this.logger = logger;
            this.configuration = configuration.Value;
        }
        
        public bool SendMessage(string msg, string sendTo)
        {
            try
            {
                msg = WebUtility.UrlEncode(msg);

                using (var httpClient = new HttpClient())
                {
                    var res = httpClient.GetAsync($"https://api.telegram.org/bot{configuration.Token}&text={msg}&parse_mode=HTML&disable_web_page_preview=true").Result;
                    if (res.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception($"No se pudo enviar el mensaje: {res.Content.ReadAsStringAsync().Result}");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return false;
            }
            return true;
        }

        public bool SetWebhook(string url)
        {
            try
            {
                url = $"url={url}";
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(url);
                    var res = httpClient.PostAsync($"https://api.telegram.org/bot{configuration.Token}/setWebhook", content).Result;
                    if (res.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception($"No se pudo setear el Webhook: {res.Content.ReadAsStringAsync().Result}");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return false;
            }
            return true;
        }

        public bool WebHook()
        {
            return true;
        }
    }
}
