using System;
using System.Linq;
using System.Threading.Tasks;

namespace nlog_load_test
{
    public class LoadTest
    {
        private readonly int _tasks;
        private readonly int _parallelism;
        private readonly  Logger _logger = new Logger();

        public LoadTest(int tasks, int parallelism = 10)
        {
            _tasks = tasks;
            _parallelism = parallelism;
        }

        public void Run()
        {
            var numberOfTasks = _tasks / _parallelism;
            var progress = 0;

            for (int i = 0; i < numberOfTasks; ++i)
            {
                var tasks = Enumerable.Range(0, _parallelism)
                    .Select(n => Task.Factory.StartNew(() => _logger.Log(), TaskCreationOptions.LongRunning))
                    .ToArray();

                Task.WaitAll(tasks);
                var currentProgress = Convert.ToInt32((double) i / numberOfTasks * 100);
                if (currentProgress != progress)
                {
                    progress = currentProgress;
                    Console.WriteLine("Progress: {0}%", progress);
                }
            }
        }
    }
}
