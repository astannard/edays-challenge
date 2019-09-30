using System;
namespace ServiceLayer.Models
{
    public class DailyMessage
    {

        public string EnGb { get; set; }
        public string Fr { get; set; }
        public string De { get; set; }
        public string ImageUrl { get; set; }
        public string GetMessage(Language language)
        {
            switch (language)
            {
                case Language.english:
                        return EnGb;

                case Language.french:
                        return Fr;

                case Language.german:
                    return De;

                default:
                    return EnGb;
            }
        }
    }
}
