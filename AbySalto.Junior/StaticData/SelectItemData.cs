using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbySalto.Junior.StaticData
{
    public class SelectItemData
    {
        public static List<SelectListItem> statuses = new List<SelectListItem> {
                new SelectListItem { Value = "Na čekanju", Text = "Na čekanju" },
                new SelectListItem { Value = "U pripremi", Text = "U pripremi" },
                new SelectListItem { Value = "Završena", Text = "Završena" }
            };

        public static List<SelectListItem> paymentMethods = new List<SelectListItem> {
                new SelectListItem { Value = "Gotovina", Text = "Gotovina" },
                new SelectListItem { Value = "Kartica", Text = "Kartica" }
            };

        public static List<SelectListItem> currencies = new List<SelectListItem> {
                new SelectListItem { Value = "EUR", Text = "EUR (Euro)" },
                new SelectListItem { Value = "USD", Text = "USD (Američki dolar)" },
                new SelectListItem { Value = "CHF", Text = "CHF (Švicarski franak)" },
                new SelectListItem { Value = "GBP", Text = "GBP (Britanska funta)" },
                new SelectListItem { Value = "CAD", Text = "CAD (Kanadski dolar)" },
                new SelectListItem { Value = "AUD", Text = "AUD (Australski dolar)" }
            };
    }
}
