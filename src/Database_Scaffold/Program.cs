// See https://aka.ms/new-console-template for more information
using Database_Scaffold.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Ok");

var context = new FukuiContext();

//var sources = context.UserMsts.AsNoTracking();

//foreach(var user in sources)
//{
//  Console.WriteLine($"{user.UserName}: {user.Password} with id: {user.LoginId}");
//}

context.UserMsts.Add(new UserMst
{
  LoginId = "minh123",
  Password = "hahasdhf",
  AvailFlg = 0,
  DeleteFlg = 0,
  UpdateDate = DateTime.Now,
  RegistDate = DateTime.Now,
  LastLoginDate = DateTime.Now,
  UserName = "minh"
});

context.SaveChanges();

Console.WriteLine("Done");