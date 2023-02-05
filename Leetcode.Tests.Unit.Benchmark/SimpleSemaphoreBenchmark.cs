using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tests.Unit.Benchmark
{
    [MemoryDiagnoser]
    public class SimpleSemaphoreBenchmark
    {
        //private SimpleSemaphore semaphore;
        private Guid requestorId;

        [GlobalSetup]
        public void Setup()
        {
            //semaphore = new SimpleSemaphore();
            requestorId = Guid.NewGuid();
        }

        [Benchmark]
        public async Task ObtainAndRelease()
        {
            //await semaphore.ObtainLock(requestorId, null, JobStoreSupport.LockTriggerAccess, CancellationToken.None);
            //await semaphore.ReleaseLock(requestorId, JobStoreSupport.LockTriggerAccess, CancellationToken.None);
        }
    }
}
