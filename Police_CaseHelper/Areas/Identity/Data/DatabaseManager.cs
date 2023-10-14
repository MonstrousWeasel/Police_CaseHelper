using Police_CaseHelper.Models;

namespace Police_CaseHelper.Areas.Identity.Data
{
    public class DatabaseManager
    {
        public static IEnumerable<UserCases> GetUserCases { get; set; }
        public static string GetUserName {  get; set; }
    }
}
