using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tests.Unit.Benchmark
{
    [MemoryDiagnoser]
    public class JobDispatchBenchmark
    {
        //private StdScheduler scheduler;
        //private JobRunShell shell;

        [GlobalSetup]
        public void Setup()
        {
            //scheduler = (StdScheduler)new StdSchedulerFactory().GetScheduler().GetAwaiter().GetResult();
            //var job = JobBuilder.Create<NoOpJob>().Build();
            //var trigger = (IOperableTrigger)TriggerBuilder.Create()
            //    .ForJob(job.Key)
            //    .WithSimpleSchedule()
            //    .StartNow()
            //    .Build();

            //trigger.FireInstanceId = "fire-instance-id";
            //trigger.SetNextFireTimeUtc(DateTimeOffset.UtcNow.AddSeconds(10));
            //var bundle = new TriggerFiredBundle(job, trigger, null, false, DateTimeOffset.UtcNow, null, null, null);
            //shell = new JobRunShell(scheduler, bundle);
        }

        [Benchmark]
        public async Task Run()
        {
            //await shell.Initialize(scheduler.sched);
            //await shell.Run();
        }
    }
}
