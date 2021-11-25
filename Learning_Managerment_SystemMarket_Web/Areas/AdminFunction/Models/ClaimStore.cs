using System.Collections.Generic;
using System.Security.Claims;

namespace Learning_Managerment_SystemMarket_Web.Areas.AdminFunction.Models
{
    public static class ClaimStore
    {
        public static readonly List<Claim> AllClaims = new ()
        {
            new Claim("Role_Create","Role_Create"),
            new Claim("Role_Edit","Role_Edit"),
            new Claim("Role_Access","Role_Access"),
            new Claim("Role_Show","Role_Show"),
            new Claim("Role_Delete","Role_Delete"),
            new Claim("User_Create","User_Create"),
            new Claim("User_Edit","User_Edit"),
            new Claim("User_Access","User_Access"),
            new Claim("User_Show","User_Show"),
            new Claim("User_Delete","User_Delete"),
            new Claim("Language_Create","Language_Create"),
            new Claim("Language_Edit","Language_Edit"),
            new Claim("Language_Access","Language_Access"),
            new Claim("Language_Show","Language_Show"),
            new Claim("Language_Delete","Language_Delete"),
            new Claim("Category_Create","Category_Create"),
            new Claim("Category_Edit","Category_Edit"),
            new Claim("Category_Access","Category_Access"),
            new Claim("Category_Show","Category_Show"),
            new Claim("Category_Delete","Category_Delete"),
            new Claim("SubCategory_Create","SubCategory_Create"),
            new Claim("SubCategory_Edit","SubCategory_Edit"),
            new Claim("SubCategory_Access","SubCategory_Access"),
            new Claim("SubCategory_Show","SubCategory_Show"),
            new Claim("SubCategory_Delete","SubCategory_Delete"),
            new Claim("Instructor_Edit","Instructor_Edit"),
            new Claim("Instructor_Access","Instructor_Access"),
            new Claim("Instructor_Show","Instructor_Show"),
            new Claim("Course_Access","Course_Access"),
            new Claim("Course_Show","Course_Show"),
            new Claim("Verification_Access","Verification_Access"),
            new Claim("FAQ_Create","FAQ_Create"),
            new Claim("FAQ_Show","FAQ_Show"),
            new Claim("FAQ_Edit","FAQ_Edit"),
            new Claim("FAQ_Access","FAQ_Access"),
            new Claim("FAQ_Delete","FAQ_Delete"),
            new Claim("Student_Edit","Student_Edit"),
            new Claim("Student_Access","Student_Access"),
            new Claim("Student_Show","Student_Show"),
            new Claim("PayOut_Access","PayOut_Access"),
            new Claim("Setting_Access","Setting_Access"),
            new Claim("Report_Access","Report_Access"),
            new Claim("Notification_Access","Notification_Access"),
            new Claim("FeedBack_Access","FeedBack_Access"),
            new Claim("Lang_Access","Lang_Access"),
            new Claim("Lang_Create","Lang_Create"),
            new Claim("Lang_Delete","Lang_Delete"),
            new Claim("Lang_Edit","Lang_Edit")
        };
    }
}