--select *  from Surveys 
--inner join Questions on Surveys.ID = Questions.SurveyID 

--select  YEAR(EndDate), MONTH(EndDate) ,COUNT(YEAR(EndDate)) from Surveys  group by EndDate

--select * from Questions
--select * from surveys;
--select CONVERT(date, EndDate) as Ngay, count(*) as SoLuongSurvey from Surveys Group By CONVERT(date, EndDate);
--select CONVERT(date, s.CreatedAt) as Ngay, count(us.ApplicationUserID) as SoLuongNguoiDung  from Surveys as s join UserSurveys as us on s.ID = us.SurveyID Group By CONVERT(date, CreatedAt);