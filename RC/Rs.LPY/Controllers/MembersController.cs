using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.LPY.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 待付款
        /// </summary>
        /// <returns></returns>
        public IActionResult NoPay()
        {
            return View();
        }
        /// <summary>
        /// 我的消息
        /// </summary>
        /// <returns></returns>
        public IActionResult Messages()
        {
            return View();
        }
        /// <summary>
        /// 待签收订单
        /// </summary>
        /// <returns></returns>
        public IActionResult NotSign()
        {
            return View();
        }
        /// <summary>
        /// 我的订单
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderList()
        {
            return View();
        }
        /// <summary>
        /// 我的帐户
        /// </summary>
        /// <returns></returns>
        public IActionResult Accounts()
        {
            return View();
        }
        /// <summary>
        /// 我的积分
        /// </summary>
        /// <returns></returns>
        public IActionResult Integras()
        {
            return View();
        }
        /// <summary>
        /// 电子礼品卡
        /// </summary>
        /// <returns></returns>
        public IActionResult Egiftcards()
        {
            return View();
        }
    }
}
