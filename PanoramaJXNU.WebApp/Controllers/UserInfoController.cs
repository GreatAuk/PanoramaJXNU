using PanoramaJXNU.BLL;
using PanoramaJXNU.IBLL;
using PanoramaJXNU.Model;
using PanoramaJXNU.Model.EnumType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/

        //实例化BaseService对象
        //public static IBaseService<UserInfo> UserInfoService = new UserInfoService();

        IBLL.IUserInfoService UserInfoService { get; set; }
        IBLL.ITopicService TopicService { get; set; }
        IBLL.ICommentService CommentService { get; set; }
        IBLL.IFocusService FocusService { get; set; }

        LeaveMsgService LeaveMsgService = new LeaveMsgService();
        #region 个人中心首页
        public ActionResult Index()
        {
            ViewBag.headImg = ((UserInfo)Session["UserInfo"]).HeadImg;
            ViewBag.Signature = ((UserInfo)Session["UserInfo"]).Signature;
            ViewBag.sex = ((UserInfo)Session["UserInfo"]).Gender;
            return View();
        } 
        #endregion

        #region 我的设置（分布视图)
        public ActionResult Set()
        {
            int UserId = ((UserInfo)Session["UserInfo"]).UserId;
            UserInfo user = UserInfoService.LoadEntities(c => c.UserId == UserId).FirstOrDefault();
            return PartialView(user);
        }
        #endregion

        #region 我的评论（分布视图)
        public ActionResult MyComment()
        {
            int UserId = ((UserInfo)Session["UserInfo"]).UserId;
            List<Comment> list = CommentService.LoadEntities(c=>c.UserId==UserId).ToList();
            return PartialView(list);
        }
        #endregion

        #region 我的话题（分布视图)
        public ActionResult MyTopic()
        {
            int UserId = ((UserInfo)Session["UserInfo"]).UserId;
            List<Topic> list = TopicService.LoadEntities(c => c.UserId == UserId).ToList();
            return PartialView(list);
        }
        #endregion

        #region 我的消息（分布视图)
        public ActionResult MyMessage()
        {
            int UserId = ((UserInfo)Session["UserInfo"]).UserId;
            var list = CommentService.LoadEntities(c => c.TopicUserId == UserId).ToList();
            return PartialView(list);
        }
        #endregion

        #region 我的留言（分布视图)
        public ActionResult MyLeaMsg()
        {
            string username = ((UserInfo)Session["UserInfo"]).UserName;
            var list= LeaveMsgService.LoadEntities(c => c.Receiver == username).ToList();
            return PartialView(list);
        }
        #endregion

        #region 头像上传
        public ActionResult UploadAvatar()
        {
            int filecount = Request.Files.Count;//获得MIME文件流 的文件数量
            Stream[] resStreamArray = new Stream[filecount];//建立文件流数组
            string[] strFilePathArray = new string[filecount];//建立服务器文件地址数组
            long[] iBufferSizeArray = new long[filecount];//建立文件流字节长度
           
            for (int i = 0; i < filecount; i++)
            {
                resStreamArray[i] = Request.Files.Get(i).InputStream;
                //这里设定保存后的名称，
                strFilePathArray[i] = Server.MapPath("~/Content/head/" + DateTime.Now.ToString("yyMMddhhmmss") + Request.Files.Get(i).FileName.Substring(0, 1) + ".png");

                if (System.IO.File.Exists(strFilePathArray[i]))//存在同名文件则删除
                {
                    System.IO.File.Delete(strFilePathArray[i]);
                }
                
                iBufferSizeArray[i] = Request.Files.Get(i).InputStream.Length;
                FileStream fileStream = System.IO.File.Create(strFilePathArray[i]);//创建新文件
                byte[] buffer = new byte[iBufferSizeArray[i]];
                int iReadLength = 0;
                //读取返回流
                iReadLength = resStreamArray[i].Read(buffer, 0, buffer.Length);
                while (iReadLength > 0)
                {
                    //写入文件流中
                    fileStream.Write(buffer, 0, iReadLength);
                    iReadLength = resStreamArray[i].Read(buffer, 0, buffer.Length);
                }
                fileStream.Flush();
                resStreamArray[i].Close();
                fileStream.Close();
            }

            return Content("ok");
        }
        #endregion

        #region 修改头像
        public ActionResult ChangeHead()
        {
            UserInfo UserNow = ((UserInfo)Session["UserInfo"]);
            UserInfo user = UserInfoService.LoadEntities(c => c.UserId == UserNow.UserId).FirstOrDefault();
            user.HeadImg = "/Content/head/" + DateTime.Now.ToString("yyMMddhhmmss") + "b.png";
            UserInfoService.EditEntity(user);
            UserNow.HeadImg = user.HeadImg;
            Session["UserInfo"] = UserNow;
            return Content("ok");
        } 
        #endregion

        #region 修改密码
        public ActionResult ChangePwd()
        {
            string newpwd = Request["newpwd"];
            string oldpwd = Request["oldpwd"];

            int NowUserId=((UserInfo)Session["UserInfo"]).UserId;
            if (UserInfoService.LoadEntities(c => c.PWord == oldpwd&&c.UserId==NowUserId) == null)
            {
                return Content("请输入正确的原始密码！");
            }
            UserInfo NowUser = UserInfoService.LoadEntities(c=>c.UserId==NowUserId).FirstOrDefault();
            NowUser.PWord=newpwd;
            UserInfoService.EditEntity(NowUser);
            return Content("更加成功！");
        }
        #endregion

        #region 修改个人信息
        public ActionResult ChangePersonMsg(string username, string city ,string signature)
        {
            int NowUserId = ((UserInfo)Session["UserInfo"]).UserId;
            UserInfo NowUser = UserInfoService.LoadEntities(c => c.UserId == NowUserId).FirstOrDefault();
            NowUser.UserName = username;
            NowUser.City = city;
            NowUser.Signature = signature;
            UserInfoService.EditEntity(NowUser);
            return Content("修改成功！");
        }
        #endregion

        #region 获取用户列表数据
        //public ActionResult GetUserInfoList()
        //{
        //    //涉及分页
        //    //1/接收page、rows值
        //    int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
        //    //在这里使用int.Parse转换格式如果传入一个字母将会导致异常，这里使用它是因为会用日志来处理异常
        //    int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
        //    int totalCount;
        //    short delFlag = (short)DelFlagEnumType.Normal;//因为DelFlage是0或者1，所以使用枚举类型
        //    //调用分页方法
        //    var UserInfoList = UserInfoService.LoadPageEntities<int>(
        //        pageIndex,
        //        pageSize,
        //        out totalCount,
        //        c => c.DelFlag == delFlag,//查询条件：将DelFlag==0的数据查找出来
        //        c => c.UserId,//排序方式：按照主键ID来排序
        //        true);//升序

        //    //因为userInfoList里面有所有数据列的数据，这里我们并不需要所有列，所以下面进行部分列查询
        //    var temp = from u in UserInfoList
        //               select new
        //               {
        //                   ID = u.UserId,
        //                   UName = u.UserName,
        //                   UPwd = u.PWord,
        //                   UEmail = u.Email,
        //                   Gender = u.Gender,
        //                   RegTime = u.RegTime
        //               };

        //    //将部分列和总的记录数totalCount一起生成Json格式数据返回
        //    return Json(new { rows = temp, total = totalCount });//在里面构建匿名类
        //    //rows与total是框架已经规定的，用于传值
        //}
        #endregion

        #region 人物面板
        public ActionResult PersonPanel(string commentuser)
        {
            UserInfo user = UserInfoService.LoadEntities(c => c.UserName == commentuser).FirstOrDefault();
            string city = user.City;
            string sex = user.Gender;
            string headimg = user.HeadImg;
            string signature = user.Signature;
            int topicCount= TopicService.LoadEntities(c => c.UserName == user.UserName).Count();
            int replyCount = CommentService.LoadEntities(c => c.UserName == user.UserName).Count();
            int focusCount = FocusService.LoadEntities(c => c.UserName == user.UserName).Count();
            int fsCount = FocusService.LoadEntities(c => c.FriendName == user.UserName).Count();
            return Content("city:" + city + ";sex:" + sex + ";haedimg:" + headimg + ";topicCount:" + topicCount + ";replyCount:" + replyCount + ";focusCount:" + focusCount + ";fsCount:" + fsCount + ";signature:" + signature);
        }
        #endregion

        //#region 批量删除数据
        //public ActionResult DeleteUserInfos()
        //{
        //    //拿到ＩＤ值
        //    string strid = Request["strID"];
        //    string[] strids = strid.Split(',');
        //    //将字符串数组转成整型,加到List集合中
        //    List<int> list = new List<int>();
        //    foreach (var id in strids)
        //    {
        //        list.Add(Convert.ToInt32(id));
        //    }
        //    if (UserInfoService.DeleteEntities(list))
        //    {
        //        return Content("OK");
        //    }
        //    else
        //    {
        //        return Content("not");
        //    }
        //}
        //#endregion
        //#region 添加用户
        //public ActionResult AddUserInfo(UserInfoSet userInfo)
        //{
        //    //获取到在表单填写的数据
        //    userInfo.DelFlag = 0;
        //    userInfo.SubTime = DateTime.Now;
        //    userInfo.ModifiedOn = DateTime.Now;
        //    if (userInfo.Sort == null)
        //    {
        //        userInfo.Sort = "";
        //    }
        //    if (userInfo.Remark == null)
        //    {
        //        userInfo.Remark = "";
        //    }
        //    //调用业务逻辑层的添加方法
        //    UserInfoService.AddEntity(userInfo);

        //    return Content("OK");

        //    ;

        //}
        //#endregion
        //#region 展示修改数据
        //public ActionResult ShowEditUserInfo()
        //{
        //    //将id传递过来
        //    int id = int.Parse(Request["id"]);
        //    //将修改后的数据传递过来

        //    //将id相符合的用户信息查询出来
        //    var userInfo = UserInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
        //    //返回json数据
        //    return Json(userInfo, JsonRequestBehavior.AllowGet);
        //}
        //#endregion
        //#region 修改数据
        //public ActionResult EditUserInfo(UserInfoSet userInfo)
        //{
        //    userInfo.SubTime = DateTime.Now;
        //    userInfo.ModifiedOn = DateTime.Now;
        //    userInfo.Sort = "";
        //    userInfo.DelFlag = 0;
        //    if (userInfo.Sort == null)
        //    {
        //        userInfo.Sort = "";
        //    }
        //    if (userInfo.Remark == null)
        //    {
        //        userInfo.Remark = "";
        //    }
        //    UserInfoService.EditEntity(userInfo);
        //    return Content("OK");
        //}
        //#endregion

       
	}
}