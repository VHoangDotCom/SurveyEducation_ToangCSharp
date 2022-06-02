# SurveyEducation_ToangCSharp

    STEP BY STEP - PROJECT

 Create API + Database

1. Create Project (WebApplication -> Web API -> Individuals Authen -> Set Docker )

2. Create Model follow Database design ( Category, Survey, Question, Answer,...)

3. Create DBCOntext -> Add Connection String ( If you using Individuals Authen => no need )
  3,a : Add DBSet<Entity> into IdentityModels.ApplicationDbContext
  3,b : Add more Attibute in to User : IdentityModels.ApplicationUser

4. Create DB on the cloud ( Azure DB ):
  - Create Resource Group
  - Enter DB Name : SurveySystem
  - Select Server ( Singapore recommended )
  - Server name : education-survey
  - Location : (US) East US ( optional)
  - Server admin login : survey2k1
  - Password : Hatethisshit123
  - Choose Locally-redundant backup storage

Next
  - No access
  - + Default - Uses Redirect policy for all client connections originating inside of Azure and Proxy for all client connections originating outside Azure
    ( Admin has the role to add Client to database )
     + Redirect - Clients establish connections directly to the node hosting the database ( everyone can access to DB )
    => recommend first one
  - Security : pass
  - Additional settings : None
  - Tags : pass
  - Review and Create : Create

Notification:
  - Pin to Dashboard

5. Connect To Azure : 
  Open MS SQL
   Server name : education-survey.database.windows.net
   SQL Server Authentication
   Login : survey2k1
   Password : Hatethisshit123
=> Connect
   Connect in Visual

6. Connection String ( Update DefaultConnection)
<connectionStrings>
    <add name="SurveyDB" connectionString="Data Source=education-survey.database.windows.net;Initial Catalog=SurveySystem;User ID=survey2k1;Password=Hatethisshit123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient" />
  </connectionStrings>

7. Execute 3 statements : 
enable-migrations ( if you have error : try to run this : Enable-Migrations -ContextTypeName EducationSurveyAPI.Models.ApplicationDbContext )
add-migration InitDB
update-database


  Create Dashboard + OAuth 2 ( Authentication + Authorization )

1. Create another Project for CRUD (Instead of Web API => MVC )
Add Models + DBContext + ConnectionString

2. Add Controller ( View Controller ) + Search Ajax + PageList (Index +IndexAjax)
  Keyword :
 Microsoft.jQuery.Unobtrusive-ajax
 Install-Package PagedList.Mvc
 Link : link: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
 
3.Login by GG Account 
Create Google Prject (link: https://docs.microsoft.com/en-us/aspnet/mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on
 ( link GG App for OAuth 2 : https://console.cloud.google.com/apis/dashboard?project=my-project-vhoang
 Search Credentials => Create Goolge Project Oath (if not exists)
 Search Credentials => Create Project
 CustomerID : 633720633677-05hnu4djcu6ad5hntnsd7l7lmq3vhsa0.apps.googleusercontent.com
 Customer secret code : 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

4. App_Start/Startup.Auth.cs
 Disable comment from 61->65 (ClientId , ClientSecret in Json File)

5. Add some Entity to User
Model/IdentityModel.cs =>  public class ApplicationUser : IdentityUser

6. Set entity in Login
Model/AccountViewModel.cs =>  public class ExternalLoginConfirmationViewModel
Views/Account/ExternalLoginConfirmationViewModel.cshtml => add entity

7. Run 3 statements
Enable-Migrations
Add-Migration Init
Update-Database

8. Login by Facebook
https://developers.facebook.com/
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/facebook-logins?view=aspnetcore-6.0

Ứng dụng của tôi -> Tạo ứng dụng -> Chọn thể loại -> Nhập thông tin Project
-> Đăng nhập bằng Facebook -> Web -> URL(localhost)

9. App_Start/Startup.Auth.cs
 Disable comment from 56-59(appId , appSecret)
 1111416416347615 | eb3dd10ae3cbbb91cad544e49c4ae9cd

10. Secure MVC with login, email confirmation, password reset
https://docs.microsoft.com/en-us/aspnet/mvc/overview/security/create-an-aspnet-mvc-5-web-app-with-email-confirmation-and-password-reset
 Install-Package SendGrid

11. Authorization
Add AspNetRoles in DB
Add AspNetUserRoles in DB
Add  [Authorize(Roles = "User")] above function you want to authorize
luong Authorize : https://devblogs.microsoft.com/dotnet/understanding-owin-forms-authentication-in-mvc-5/


12. Add file aspnet-mvc.gitignore into project
   
    Send mail demo
1. Create new MVC project

2. Add this code into Web.config
<system.net>
		<mailSettings>
			<smtp>
				<network host="smtp.gmail.com"
						 port="587"
			             userName="hoangnvth2010033@fpt.edu.vn"
			             password="******"
			             enableSsl="true"		
						 />
			</smtp>
		</mailSettings>
	</system.net>

3. Create EmailController
 Add this code into it : 
  public class EmailController : Controller
    {
        //GET: Email
        public ActionResult SendEmail()
        {
            return View();
        }

     
        // this is post request
        [HttpPost]
        public ActionResult SendEmail(string useremail)
        {
            string subject = "THis is just a demo email";
            string body = "a body for email an email... you can write any thong,...";
            
            WebMail.Send(useremail, subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.msg = "email sent successfully...";
            return View();
        }
    }

4. Create View in [HttpPost] SendEmail

@{
    ViewBag.Title = "SendEmail";
}

<h2>SendEmail</h2>
<hr />
@if (ViewBag.msg != null)
{
    <div class="alert alert-success">@ViewBag.msg</div>
}

@using (Html.BeginForm())
{
    <div class="input-group col-md-3">
        <input type="text" name="useremail" class="form-control" />
        <div class="input-group-btn">
            <button class="btn btn-success" type="submit">
                <i class="glyphicon glyphicon-send"></i>
            </button>
        </div>
    </div>
}

5. Enter your Google Account
Turn on  Less secure apps to access Gmail
 => run project Email/SendEmails


   Send Mail + SMS (Twillio )

1. Add code to App_Start/IdentityConfig.cs
( Need to fix bug )

2. Add SendEmailConfirmationTokenAsync in Controllers\AccountController.cs
SendGrid Account : viethoang2001gun@gmail.com
emgathoi12345678

3. SMS and Email 2-Factor Authentication (with Twilio)
https://docs.microsoft.com/en-us/aspnet/mvc/overview/security/aspnet-mvc-5-app-with-sms-and-email-two-factor-authentication
Twilio account : viethoang2001gun@gmail.com
emgathoi12345678
Twilio : https://console.twilio.com/?frameUrl=%2Fconsole%3Fx-target-region%3Dus1&newCustomer=true
  Account SID : AC579f08bbb53ee9293d8d561ebc600689
  Auth Token : e5b7210aaf260f747ce6652ebbf8a09d
  Phone Number: +17622525326

4. Install-Package Twilio

5. AddKey in Web.config

6. Configure the SmsService class in the App_Start\IdentityConfig.cs file.
Bug ( Username in Init)
