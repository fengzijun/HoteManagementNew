using HoteManagement.Caching;
using HoteManagement.Infrastructure;
using HoteManagement.Service.Core;
using HoteManagement.Service.Model;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HoteManagement.Web.Core
{
    [ExceptionHandling]
    [ErrorModelFilter]
    public class BaseController : Controller
    {
     
        protected readonly ILogger logger;
        protected readonly IWebHelper webHelper;
        protected readonly ICacheManager cacheManager;
        protected readonly IService generateService;

        public BaseController()
        {
          
            logger = EngineContext.Current.Resolve<ILogger>();
            webHelper = EngineContext.Current.Resolve<IWebHelper>();
            cacheManager = EngineContext.Current.Resolve<ICacheManager>();
            generateService = EngineContext.Current.Resolve<IService>();
            GetMenus();
        }


        protected byte[] CreateCheckCodeImage(string[] checkCode)
        {
            if (checkCode == null || checkCode.Length <= 0)
                return null;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 32.5)), 30);
            System.Drawing.Graphics g = Graphics.FromImage(image);

          
            Random random = new Random();
            //清空图片背景色 
            g.Clear(Color.White);

            //画图片的背景噪音线 
            for (int i = 0; i < 20; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            //定义颜色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            //定义字体
            string[] f = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

            for (int k = 0; k <= checkCode.Length - 1; k++)
            {
                int cindex = random.Next(7);
                int findex = random.Next(5);

                Font drawFont = new Font(f[findex], 18, (System.Drawing.FontStyle.Bold));



                SolidBrush drawBrush = new SolidBrush(c[cindex]);

                float x = 5.0F;
                float y = 0.0F;
                float width = 20.0F;
                float height = 25.0F;
                int sjx = random.Next(10);
                int sjy = random.Next(image.Height - (int)height);

                RectangleF drawRect = new RectangleF(x + sjx + (k * 25), y + sjy, width, height);

                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;

                g.DrawString(checkCode[k], drawFont, drawBrush, drawRect, drawFormat);
            }

            //画图片的前景噪音点 
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            //画图片的边框线 
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
          
        }


        public UserInfoDto UserInfo { get {
                try
                {
                    
                    HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (authCookie != null)
                    {

                        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        if (authTicket == null || string.IsNullOrEmpty(authTicket.UserData))
                            return null;
                        UserInfoDto user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfoDto>(authTicket.UserData);

                        return user;

                    }

                    return null;
                }
                catch
                {
                    return null;
                }


            }
        }


        public void GetMenus()
        {
            //if (UserInfo == null)
            //    return;
            //var menus = cacheManager.Get<UserMenus>(Const.MENUKEY, () =>
            //{
            //    return userService.GetAccountMenus(UserInfo.Id);
            //}, 60*60*5);


            //var temp = cacheManager.Get<HoteManagement.Service.Model.UserMenus>(HoteManagement.Web.Core.Const.MENUKEY);

        }

        public void PrepareHotelList(string name,int? parentid, int? istop, int? isdeleted, int? ischain,bool hasselected)
        {
            //var models = generateService.GetHotelList(name, parentid, istop, isdeleted, ischain);
            //List<SelectListItem> list = new List<SelectListItem>();
            //foreach (var item in models)
            //{
            //    list.Add(new SelectListItem { Text = item.HotelName, Value = item.Id.ToString() });

            //}
            //if(hasselected)
            //    list.Insert(0, new SelectListItem { Value = "0", Text = "请选择" });
            //ViewBag.Hotellist = list;
        }

        public void PrepareRoleList(int? hotelid, bool hasselected)
        {
            //var models = generateService.GetAccounts_RolesList(hotelid);
            //List<SelectListItem> list = new List<SelectListItem>();
            //foreach (var item in models)
            //{
            //    list.Add(new SelectListItem { Text = item.title, Value = item.Id.ToString() });

            //}
            //if (hasselected)
            //    list.Insert(0, new SelectListItem { Value = "0", Text = "请选择" });

            //foreach (var item in list)
            //{
            //    int id = int.Parse(item.Value);
            //    var model = models.Where(s => s.Id == id).FirstOrDefault();
            //    if (model != null)
            //    {
            //        if (!hotelid.HasValue && model.UserHotel != null)
            //        {
            //            item.Text = item.Text + "(" + model.UserHotel.HotelName + ")";
            //        }

            //        item.Value = item.Value + "_" + (model.UserHotel == null ? "0" : model.UserHotel.Id.ToString());
            //    }
            //}

            //ViewBag.Rolelist = list;
        }

        public int? CheckHotelid(int? hotelid)
        {
            //if (hotelid.HasValue && hotelid.Value != 0)
            //    return hotelid;

            //if (!hotelid.HasValue)
            //    return UserInfo.hotelid;

            //if (hotelid.HasValue && hotelid.Value == 0)
            //    return UserInfo.hotelid;

            return 0;
        }

    }
}