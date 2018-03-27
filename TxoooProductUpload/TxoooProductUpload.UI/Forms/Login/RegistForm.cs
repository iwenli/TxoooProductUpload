using Iwenli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Txooo;
using TxoooProductUpload.UI.Common;
using TxoooProductUpload.UI.Service.Cache.ReisterCache;
using TxoooProductUpload.UI.Service.Entities;

namespace TxoooProductUpload.UI.Forms.Login
{
    public partial class RegistForm : BaseForm
    {

        /// <summary>
        /// 全局注册任务数据
        /// </summary>
        RegisterCahceData registerCache;
        /// <summary>
        /// 注册请求封装
        /// </summary>
        PassportService ppService = new PassportService();

        public RegistForm()
        {
            InitializeComponent();
            LogControl = txtLog;

            #region 全局上下文初始化
            RegisterCacheContext.Instance.Init();
            registerCache = RegisterCacheContext.Instance.Data;
            #endregion

            btnGo.Click += BtnGo_Click;
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            try
            {
                var shareMobile = Convert.ToInt64(txtShareMobile.Text.IsNullOrEmpty() ? "19999955555" : txtShareMobile.Text);
                var startMobile = Convert.ToInt64(txtStartMobile.Text.IsNullOrEmpty() ? "19999900000" : txtStartMobile.Text);
                var maxLevel = Convert.ToInt32(txtMaxLevel.Text.IsNullOrEmpty() ? "7" : txtMaxLevel.Text);
                var userCount = Convert.ToInt32(txtUserCount.Text.IsNullOrEmpty() ? "3" : txtUserCount.Text);
                var password = txtPwd.Text.IsNullOrEmpty() ? "123456789" : txtPwd.Text;

                if (startMobile.ToString().Substring(0, 6) != "199999")
                {
                    AppendLog("号码{0}非测试号段", startMobile);
                    return;
                }
                ApiList.IsTest = true;
                //先判断是否有缓存数据,如果没有，重新生成检测集合
                if (registerCache.CanUseQueue.Count == 0 && registerCache.WaitCheckQueue.Count == 0)
                {
                    while (startMobile < 20000000000)
                    {
                        registerCache.WaitCheckQueue.Enqueue(new RegisterInfo()
                        {
                            Mobile = startMobile++
                        });
                    }
                    //检测手机任务
                    CheckUserMobile();
                }
                //封装用户注册数据
                GenerateRegistData(shareMobile, userCount, password, 1, maxLevel);
                //注册用户任务
                //Register();
            }
            catch (Exception ex)
            {
                RegisterCacheContext.Instance.Save();
                AppendLogError(ex.Message);
            }
            finally
            {
                btnGo.Enabled = true;
            }
        }

        /// <summary>
        /// 封装注册数据
        /// </summary>
        /// <param name="parentMobile"></param>
        /// <param name="userCount"></param>
        /// <param name="password"></param>
        /// <param name="level"></param>
        /// <param name="maxLevel"></param>
        async void GenerateRegistData(long parentMobile, int userCount, string password, int level, int maxLevel)
        {
            try
            {
                Thread.Sleep(1000);
                var shareCode = await ppService.GetShareCodeByTxId(parentMobile);
                for (int i = 0; i < userCount; i++)
                {
                    //获取可用手机号
                    var task = registerCache.CanUseQueue.Dequeue();// await GetCanUserMobile();
                    string mobileVerify = "";
                    try
                    {
                        //发送验证码
                        mobileVerify = await ppService.SendMobile(task.Mobile);
                    }
                    catch (Exception ex)
                    {
                        AppendLogError("验证码发送异常：{0}", ex.Message);
                        LogHelper.LogError(this, "验证码发送异常：{0}".FormatWith(ex.Message), ex);
                        continue;
                    }

                    var data = new
                    {
                        zyl = "zyl",
                        mobilecode = task.Mobile.ToString().Substring(6),
                        mobile_verify = mobileVerify,
                        Password = password,
                        sharecode = shareCode,
                        source = 1,//用户来源（1个人推广，2产品推广）
                        source_channel = 5,//来源渠道（0浏览器，1微信，2QQ，3微博，4App）  5pc
                        app_type = "pc-winform",
                        app_useragent = "{\"model\":\"pc\",\"display\":\"1.0.2\",\"systemName\":\"windows\",\"product\":\"Microsoft\",\"release\":\"10\",\"fingerprint\":\"252D2903-9F0B-42D2-BFC8-B9108B759672\",\"channel\":\"local\",\"device\":\"高额返利设备\"}"
                    };
                    long userId = 0;
                    try
                    {
                        userId = await ppService.Regist(data);
                    }
                    catch (Exception ex)
                    {
                        AppendLogError("注册请求异常：{0}", ex.Message);
                        LogHelper.LogError(this, "注册请求异常：{0}".FormatWith(ex.Message), ex);
                        continue;
                    }

                    if (userId > 0)
                    {
                        task.Level = level;
                        task.PassWord = password;
                        task.UserId = userId;
                        task.ParentUserId = parentMobile;
                        task.SendData = null;
                        lock (registerCache.SuccessList)
                        {
                            registerCache.SuccessList.Add(task);
                            AppendLog("号码{0}注册成功.".FormatWith(task.Mobile));
                            if (registerCache.SuccessList.Count % 20 == 0)
                            {
                                //每成功20个手动释放一下内存
                                GC.Collect();
                                //保存任务数据，防止什么时候宕机了任务进度回滚太多
                                lock (registerCache)
                                {
                                    RegisterCacheContext.Instance.Save();
                                }
                            }
                        }
                        LogHelper.LogInfo(this, "{0}----{1}----{2}----{3}----".FormatWith(
                            task.Level, task.Mobile, task.UserId, task.PassWord));
                    }
                    else
                    {
                        lock (registerCache)
                        {
                            registerCache.CanUseQueue.Enqueue(task);
                        }
                        AppendLogError("号码{0}注册失败，已添加到任务队列等待重试...".FormatWith(task.Mobile));
                    }
                    //registerCache.WaitRegisterQueue.Enqueue(task);

                    if (level < maxLevel)
                    {
                        GenerateRegistData(task.Mobile, userCount, password, level + 1, maxLevel);
                    }
                }
            }
            catch (Exception ex)
            {
                AppendLogError("注册全局异常：{0}", ex.Message);
                LogHelper.LogError(this, "注册全局异常：{0}".FormatWith(ex.Message), ex);
            }
        }

        #region 检测可注册手机号
        /// <summary>
        /// 检测可注册手机号
        /// </summary>
        void CheckUserMobile()
        {
            int taskCount = AppSetting.MaxThreadCount;
            var allCount = registerCache.WaitCheckQueue.Count;
            if (allCount <= 0) return;

            AppendLogWarning("[全局]检测可注册手机号...");
            AppendLogWarning("[全局]检测线程共开启{0}个...", taskCount);
            var cts = new CancellationTokenSource();
            if (taskCount > allCount)
            {
                taskCount = taskCount > allCount ? allCount : taskCount;
            }
            var tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = new Task(() => CheckUserMobileTask(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
                tasks[i].Start();
                AppendLogWarning("[全局]检测线程{0}正在启动...", i + 1);
            }
        }
        /// <summary>
        /// 检测可注册手机号任务
        /// </summary>
        async void CheckUserMobileTask(CancellationToken token)
        {
            try
            {
                RegisterInfo task;
                while (!token.IsCancellationRequested)
                {
                    task = null;
                    lock (registerCache)
                    {
                        if (registerCache.WaitCheckQueue.Count > 0)
                        {
                            task = registerCache.WaitCheckQueue.Dequeue();
                        }
                    }
                    //没有则退出
                    if (task == null)
                    {
                        break;
                    }
                    try
                    {
                        if (await ppService.CheckUserName(task.Mobile))
                        {
                            lock (registerCache.CanUseQueue)
                            {
                                registerCache.CanUseQueue.Enqueue(task);
                                AppendLog("号码{0}检测结果:{1}.".FormatWith(task.Mobile, "可用"));
                                if (registerCache.CanUseQueue.Count % 20 == 0)
                                {
                                    //每成功20个手动释放一下内存
                                    GC.Collect();
                                    //保存任务数据，防止什么时候宕机了任务进度回滚太多
                                    lock (registerCache)
                                    {
                                        RegisterCacheContext.Instance.Save();
                                    }
                                }
                            }
                        }
                        else
                        {
                            AppendLog("号码{0}检测结果:{1}.".FormatWith(task.Mobile, "不可用"));
                        }
                    }
                    catch (Exception ex)
                    {
                        lock (registerCache)
                        {
                            registerCache.WaitCheckQueue.Enqueue(task);
                        }
                        AppendLogError("号码{0}检测异常:{1}.".FormatWith(task.Mobile, ex.Message));
                        Iwenli.LogHelper.LogError(this, "号码{0}检测任务异常".FormatWith(task.Mobile), ex);
                    }
                    //等待100 在执行下一个
                    await Task.Delay(100, token);
                }
            }
            catch (Exception ex)
            {
                Iwenli.LogHelper.LogError(this, "号码检测任务全局异常", ex);
            }

        }
        #endregion

        #region 注册用户任务
        ///// <summary>
        ///// 注册用户任务
        ///// </summary>
        //void Register()
        //{
        //    int taskCount = AppSetting.MaxThreadCount;
        //    var allCount = registerCache.WaitRegisterQueue.Count;
        //    if (allCount <= 0) return;

        //    AppendLogWarning("[全局]开始提交注册请求...");
        //    AppendLogWarning("[全局]线程共开启{0}个...", taskCount);
        //    var cts = new CancellationTokenSource();
        //    if (taskCount > allCount)
        //    {
        //        taskCount = taskCount > allCount ? allCount : taskCount;
        //    }
        //    var tasks = new Task[taskCount];
        //    for (int i = 0; i < taskCount; i++)
        //    {
        //        tasks[i] = new Task(() => RegisterTask(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
        //        tasks[i].Start();
        //        AppendLogWarning("[全局]注册线程{0}正在启动...", i + 1);
        //    }
        //}
        ///// <summary>
        ///// 注册用户任务
        ///// </summary>
        //async void RegisterTask(CancellationToken token)
        //{
        //    try
        //    {
        //        RegisterInfo task;
        //        while (!token.IsCancellationRequested)
        //        {
        //            task = null;
        //            lock (registerCache)
        //            {
        //                if (registerCache.WaitRegisterQueue.Count > 0)
        //                {
        //                    task = registerCache.WaitRegisterQueue.Dequeue();
        //                }
        //            }
        //            //没有则退出
        //            if (task == null)
        //            {
        //                break;
        //            }
        //            try
        //            {
        //                var userId = await ppService.Regist(task.SendData);
        //                if (userId > 0)
        //                {
        //                    task.UserId = userId;
        //                    task.SendData = null;
        //                    lock (registerCache.SuccessList)
        //                    {
        //                        registerCache.SuccessList.Add(task);
        //                        AppendLog("号码{0}注册成功".FormatWith(task.Mobile));
        //                        if (registerCache.SuccessList.Count % 20 == 0)
        //                        {
        //                            //每成功20个手动释放一下内存
        //                            GC.Collect();
        //                            //保存任务数据，防止什么时候宕机了任务进度回滚太多
        //                            lock (registerCache)
        //                            {
        //                                RegisterCacheContext.Instance.Save();
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    lock (registerCache)
        //                    {
        //                        registerCache.WaitRegisterQueue.Enqueue(task);
        //                    }
        //                    AppendLogError("号码{0}注册失败，已添加到任务队列等待重试...".FormatWith(task.Mobile));
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                lock (registerCache)
        //                {
        //                    registerCache.WaitRegisterQueue.Enqueue(task);
        //                }
        //                AppendLogError("号码{0}注册异常：{1}，已添加到任务队列等待重试...".FormatWith(task.Mobile), ex.Message);
        //                Iwenli.LogHelper.LogError(this, "号码{0}检测任务异常".FormatWith(task.Mobile), ex);
        //            }
        //            //等待一分钟 在执行下一个
        //            await Task.Delay(100, token);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Iwenli.LogHelper.LogError(this, "号码注册任务全局异常", ex);
        //    }

        //}
        #endregion
    }
}
