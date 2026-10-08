using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aznews.Utilities
{
    public class Functions

    {
        public static string TitleSlugGeneration(string type, string? title, long id)
{
    return type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
}


public static string getCurrentDate()
{
    //Lấy ngày tháng năm hiện tại, định dạng theo dạng DateTime
    //trong bảng tblPost lưu tại cơ sở dữ liệu aznews trong SQL Server
    return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
}
    }
}