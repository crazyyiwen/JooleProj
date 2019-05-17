/*
 * Yiwen Zhao 
 *  5/6/2019
 *  UserLoginController.cs
 *  
 */
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Services;
using System.Collections;
using Repositories.Repositories;
using Services.Models;
using System.Data.Entity;

namespace Joole_MVC_Team1.Controllers
{
    public class UserLoginController : Controller
    {
        // UserLogin
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(SignUpInfoService logindata)
        {

            /***********************************************************************************/
            // if any input is null --- alert !
            if ((logindata.UserLoginName == null) || (logindata.UserLoginPassword == null))
            {
                if ((logindata.UserLoginName == null) && (logindata.UserLoginPassword == null))
                {
                    // empty is not allowed, add the alert info
                    ModelState.AddModelError("UserLoginName", "User Name required !");
                    ModelState.AddModelError("UserLoginPassword", "Password required !");
                    if (!ModelState.IsValid)
                    {
                        return View(/*logindata*/);
                    }
                    return View();
                }
                else if((logindata.UserLoginName != null) && (logindata.UserLoginPassword == null))
                {
                    ModelState.AddModelError("UserLoginPassword", "Password required !");
                    if (!ModelState.IsValid)
                    {
                        return View(/*logindata*/);
                    }
                    return View();
                }
                else
                {
                    ModelState.AddModelError("UserLoginName", "User Name required !");
                    if (!ModelState.IsValid)
                    {
                        return View(/*logindata*/);
                    }
                    return View();
                }
                
            }
            /***********************************************************************************/

            /***********************************************************************************/
            // both inputs are full, case condition to deal with
            Services.Models.LoginService LoginTrueOrFalse = new Services.Models.LoginService();
            Tuple<bool, bool> LoginDetermine = LoginTrueOrFalse.LoginServices(logindata.UserLoginName, logindata.UserLoginPassword);
            //based on the return bool value to choose which page to go
            if (LoginDetermine.Item1 == true && LoginDetermine.Item2 == false)
            {
                // login fail
                ModelState.AddModelError("UserLoginPassword", "Password not correct !");
                if (!ModelState.IsValid)
                {
                    return View(/*logindata*/);
                }
                return View();
            }
            else if (LoginDetermine.Item1 == false && LoginDetermine.Item2 == false)
            {
                ModelState.AddModelError("UserLoginPassword", "User not exist !");
                if (!ModelState.IsValid)
                {
                    return View(/*logindata*/);
                }
                return View();
            }
            else if(LoginDetermine.Item1 == true && LoginDetermine.Item2 == true)
            {
                // this part should be the redirection page, you can go anywhere
                /* 
                 */
                return RedirectToAction("SearchPage", "Search");
            }
            /***********************************************************************************/
            return View();
        }
        [HttpPost]
        public ActionResult SignUpPage(SignUpInfoService inputdata)
        {
            
            InsertDataToDatabase IDToD = new InsertDataToDatabase(inputdata.Source ,inputdata.UserName, inputdata.EmailAddress, inputdata.Password);
            IDToD.InsertAction();
            // need to return to Login page
            return RedirectToAction("LoginPage", "UserLogin");

        }
    }
}