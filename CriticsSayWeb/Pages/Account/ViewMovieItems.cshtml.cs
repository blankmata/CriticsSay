using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace CriticsSayWeb.Pages.Account
{
    public class ViewMovieItemsModel : PageModel
    {
        public List<SelectListItem> Movies { get; set; } = new List<SelectListItem>();

        public List<Pages_Account_ViewMovieItems> MovieItems { get; set; } = new List<Pages_Account_ViewMovieItems>();
        
        public int SelectedCategoryId {  get; set; }
        public void OnGet()
        {
            //PopulateCategoryDDL();
        }

        /*private void PopulateCategoryDDL()
        {
            string cmdText = "SELECT CategoryId, CategoryName FROM Category";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var category = new SelectListItem();
                    category.Value = reader.GetInt32(0).ToString();
                    category.Text = reader.GetString(1);
                    Categories.Add(category);
                }
            }
        }*/
    }
}
