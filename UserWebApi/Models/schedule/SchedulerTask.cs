using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserWebApi.Models.schedule
{
    public class SchedulerTask
    {
       // private static readonly string ScheduleCronExpression = "0 */5 * ? * *";
        private static readonly string ScheduleCronExpression = "0 * * ? * *";
        // private static readonly string ScheduleCronExpression = "* * * ? * *";
        //https://www.freeformatter.com/cron-expression-generator-quartz.html
        public static async System.Threading.Tasks.Task StartAsync()
        {
            try
            {
                var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                if (!scheduler.IsStarted)
                {
                    await scheduler.Start();
                }
                var job1 = JobBuilder.Create<MyTask>().WithIdentity("ExecuteTaskServiceCallJob1", "group1").Build();
                var trigger1 = TriggerBuilder.Create().WithIdentity("ExecuteTaskServiceCallTrigger1", "group1").WithCronSchedule(ScheduleCronExpression).Build();
                await scheduler.ScheduleJob(job1, trigger1);
            }
            catch (Exception ex) { }
        }
    }
}
