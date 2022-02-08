using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserWebApi.Services;

namespace UserWebApi.Models.schedule
{
    public class MyTask : IJob
    {
        private UserServices _userServices;

        public MyTask(UserServices userServices)
        {
            _userServices = userServices;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var task = Task.Run(() => _userServices.AddUsers()) ;
           return task;
        }
    }
}
