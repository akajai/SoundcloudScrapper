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
    public static class WebScrapping
    {
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void ScrapHTML()
        {
            try
            {

             //   HtmlNode groupHTML = null;
                var getHtmlWeb = new HtmlWeb();
                String strurl = ConfigurationSettings.AppSettings["groupurl"].ToString();
                //<h3><a href="/groups/its-a-trap" title="It's a trap!">It's a trap!</a>
                MasterList masterList = new MasterList();
                masterList.group = new List<Groups>();

                var document = getHtmlWeb.Load(strurl).DocumentNode.SelectNodes("//div");//.FindFirst("main-content;
                foreach (var aTag in document)
                {
                    if (aTag.Id == "main-content-inner")
                    {
                        
                        long groupCount = aTag.ChildNodes[4].InnerHtml.ToHtmlNode().ChildNodes.Count / 2;
                       
                        log.Info(" -- --groupCount----" + groupCount);
                        for (int index_i = 0; index_i < groupCount; index_i++)
                        {
                            var groupHTML = aTag.ChildNodes[4].ChildNodes[index_i * 2].ChildNodes[2].InnerHtml;
                            //log.Info("   ---  4----index_i " + index_i + " -- " + groupHTML.ToHtmlNode().InnerText + " -- " + groupHTML.ToHDocument().Children[0].Attributes[0].ToString());
                            log.Info("   ---  1----index_i " + index_i + " -- " + aTag.ChildNodes[4].ChildNodes[index_i * 2].ChildNodes[2].ChildNodes[0].Attributes[0].Value);
                            log.Info("   ---  2----index_i " + index_i + " -- " + aTag.ChildNodes[4].ChildNodes[index_i * 2].ChildNodes[2].InnerText);
                            log.Info("   ---  3----index_i " + index_i + " -- " + aTag.ChildNodes[4].ChildNodes[(index_i * 2)].ChildNodes[4].ChildNodes[2].ChildNodes[0].ChildNodes[4].InnerText);

                            Groups groups = new Groups();
                            groups.groupURL = aTag.ChildNodes[4].ChildNodes[index_i * 2].ChildNodes[2].ChildNodes[0].Attributes[0].Value;
                            groups.groupName = aTag.ChildNodes[4].ChildNodes[index_i * 2].ChildNodes[2].InnerText;
                            groups.nummembers = long.Parse(aTag.ChildNodes[4].ChildNodes[(index_i * 2)].ChildNodes[4].ChildNodes[2].ChildNodes[0].ChildNodes[4].InnerText);

                            masterList.group.Add(groups);
                                
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                log.Info("ScrapHTML Exception " + ex.Message);
            }

        }
    }
}
