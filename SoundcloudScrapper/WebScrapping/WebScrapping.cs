using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrapySharp.Network;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.Configuration;

namespace SoundcloudScrapper.WebScrapping
{
    public static class WebScrapping { 
         private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public static void ScrapHTML()
        {
            try
            {
                var getHtmlWeb = new HtmlWeb();
                String strurl = ConfigurationSettings.AppSettings["groupurl"].ToString();
                //<h3><a href="/groups/its-a-trap" title="It's a trap!">It's a trap!</a>

                var document = getHtmlWeb.Load(strurl).DocumentNode.SelectNodes("//div");//.FindFirst("main-content;
                foreach (var aTag in document)
                {
                    if (aTag.Id == "main-content-inner")
                    {
                        var childNode = aTag.ChildNodes;
                        int i = 0;
                        foreach ( var node in childNode)
                        {
                            log.Info("index " +i++ +" - " +node.InnerHtml);
                        }
                      
                    }


                }

                    //  GetElementbyId("main-content");


                    //var aTags = document.DocumentNode.SelectNodes("//a");

                    /*ScrapingBrowser Browser = new ScrapingBrowser();
                    Browser.AllowAutoRedirect = true; // Browser has settings you can access in setup
                    Browser.AllowMetaRedirect = true;
                   // Browser.Timeout = 60000;
                    String strurl = ConfigurationSettings.AppSettings["groupurl"].ToString();
                    strurl = "https://soundcloud.com/";
                    WebPage PageResult = Browser.NavigateToPage(new Uri(strurl));
                    HtmlNode TitleNode = PageResult.Html.FirstChild;
                    */
                    //string PageTitle = TitleNode.InnerText;
                }
            catch (Exception ex)
            {
                log.Info("ScrapHTML Exception " + ex.Message);
            }
            
        }
}
}
